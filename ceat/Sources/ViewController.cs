using System;

using AppKit;
using Foundation;

using ceat.Sources;
using ceat.Sources.Services;
using ceat.Sources.Models;
using System.Collections.Generic;

namespace ceat
{
    public partial class ViewController : NSViewController
    {
        // FIXME: Should be initialized at the `ViewController` entry-point
        readonly FileManagerWrapper FileManager = new FileManagerWrapper(new NSFileManager());
        private WorkMode ApplicationWorkMode;

        public ViewController(IntPtr handle) : base(handle) { }
        public override void ViewDidLoad() { base.ViewDidLoad(); }
        public override NSObject RepresentedObject
        {
            get { return base.RepresentedObject; }
            set { base.RepresentedObject = value; }
        }

        #region Xamarin.Mac Partial Methods
        partial void LoadDataClicked(NSButton sender)
        {
            var panel = new NSOpenPanel
            {
                CanChooseFiles = false,
                CanChooseDirectories = true,
                AllowsMultipleSelection = true
            };

            panel.BeginSheet(View.Window, (result) =>
            {
                if (result == 0 || panel.Url == null) return; // 0: pressed `Cancel`
                var dataSource = new LoadedDataOutlineDataSource(
                    new RootDirectory(
                        panel.Url.Path,
                        FileManager
                    )
                );
                var outlineViewDelegate = new LoadedDataOutlineDelegate(dataSource);

                LoadedDataOutlineView.DataSource = dataSource;
                LoadedDataOutlineView.Delegate = outlineViewDelegate;
                ProcessDataButton.Enabled = true;
            });
        }

        partial void ProcessDataClicked(NSButton sender)
        {
            //ProcessDataPreparing();
            ProcessDataPreparing_OOP();

            switch (ApplicationWorkMode)
            {
                case WorkMode.SemiAutomatic:
                    ShowModelsPairScreen();
                    break;
                case WorkMode.Automatic:
                    ShowCauseEffectMatrixScreen();
                    break;
            }
        }

        partial void ChangeWorkMode(NSButton sender)
        {
            switch (sender.Identifier)
            {
                case "Auto":
                    ApplicationWorkMode = WorkMode.Automatic;
                    break;
                case "SemiAuto":
                    ApplicationWorkMode = WorkMode.SemiAutomatic;
                    break;
            }
        }
        #endregion Xamarin.Mac Partial Methods

        #region Private Methods
        // TODO: Non-OO approach, look through at the `ProcessDataPreparing_OOP()`
        private void ProcessDataPreparing()
        {
            var dataSource = (LoadedDataOutlineDataSource)LoadedDataOutlineView.DataSource;
            double[,] UVPMatrix = new double[dataSource.RootDataDir.Directories.Count, dataSource.RootDataDir.Directories.Count];

            for (int i = 0; i < dataSource.RootDataDir.Directories.Count; i++)
            {
                for (int j = 0; j < dataSource.RootDataDir.Directories[i].ExcelFiles.Count; j++)
                {
                    var errorValue = new WorkedPointsErrorValue(dataSource.RootDataDir.Directories[i].ExcelFiles[j].ActiveSheet).Value;
                    int row = new OutputParameter(dataSource.RootDataDir.Directories[i].ExcelFiles[j].OutputParameter).IntegerValue;
                    int col = new InputParameter(dataSource.RootDataDir.Directories[i].ExcelFiles[j].InputParameters[0]).IntegerValue;
                    UVPMatrix[row - 1, col - 1] = errorValue;
                }
            }

            string[,] CAEMatrix = new string[dataSource.RootDataDir.Directories.Count, dataSource.RootDataDir.Directories.Count];
            for (int i = 0; i < dataSource.RootDataDir.Directories.Count; i++)
            {
                for (int j = 0; j < dataSource.RootDataDir.Directories.Count; j++)
                {
                    if (i != j)
                    {
                        var comparingResult = new AlgorithmService().CompareConcurencyModels(UVPMatrix[i, j], UVPMatrix[j, i]);
                        CAEMatrix[i, j] = Convert.ToString(comparingResult.Item1);
                        CAEMatrix[j, i] = Convert.ToString(comparingResult.Item2);
                    }
                    else
                    {
                        CAEMatrix[i, j] = "-";
                    }
                }
            }
        }

        private void ProcessDataPreparing_OOP() 
        {

            /// TODO: I'm not sure that `CausalRelationshipPairsSet` instance should be last 
            /// and it should have `Matrix` property. Maybe it'll be better to have `CausalRelationshipPairsMatrix` instance,
            /// which will obtain two (or more) constructor arguments: 
            /// CausalRelationshipPairsSet, dataSource->directories (or directories.Count only)
            var causalRelationshipPairsMatrix = new CausalRelationshipPairsSet(
                new UnexplainedVarianceProportionList(
                    ((LoadedDataOutlineDataSource)LoadedDataOutlineView.DataSource).RootDataDir.Directories
                ).Value
            ).Matrix;

            Console.WriteLine("Causal Relationship Pairs Matrix");
            for (int i = 0; i < causalRelationshipPairsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < causalRelationshipPairsMatrix.GetLength(1); j++)
                {
                    Console.Write($"{causalRelationshipPairsMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        void ShowModelsPairScreen()
        {
            // TODO: ...
        }

        void ShowCauseEffectMatrixScreen()
        {
            // TODO: ...
        }
        #endregion
    }
}
