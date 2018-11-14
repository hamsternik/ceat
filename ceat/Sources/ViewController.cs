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
        public readonly FileManagerWrapper FileManager = new FileManagerWrapper(new NSFileManager());
        public readonly AlgorithmService algorithmService = new AlgorithmService();
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
            var unexplainedVarianceProportionMatrix = new UnexplainedVarianceProportionMatrix(
                new UnexplainedVarianceProportionList(
                    ((LoadedDataOutlineDataSource)LoadedDataOutlineView.DataSource).RootDataDir.Directories
                ),
                ((LoadedDataOutlineDataSource)LoadedDataOutlineView.DataSource).RootDataDir.Directories.Count
            );

            switch (ApplicationWorkMode)
            {
                case WorkMode.SemiAutomatic:
                    ShowModelsPairScreen(unexplainedVarianceProportionMatrix);
                    break;
                case WorkMode.Automatic:
                    ShowCauseEffectMatrixScreen(unexplainedVarianceProportionMatrix);
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
        void ShowModelsPairScreen(UnexplainedVarianceProportionMatrix unexplainedVarianceProportionMatrix)
        {
            /// TODO: Show ModelsPair Screen with `UnexplainedVarianceProportionMatrix` dependency
        }

        void ShowCauseEffectMatrixScreen(UnexplainedVarianceProportionMatrix unexplainedVarianceProportionMatrix)
        {
            var causalRelationshipMatrix = new CausalRelationshipMatrix(
                unexplainedVarianceProportionMatrix,
                algorithmService
            );

            /// TODO: Show CauseEffectMatrix Screen with `CausalRelationshipPairsSet` dependency
        }
        #endregion
    }
}
