using AppKit;
using System;
using CoreFoundation;

using ceat.Sources.Models;
using ceat.Sources.Services;
using ceat.Sources.ViewControllers.CauseEffectMatrixScreen;

namespace ceat.Sources.ViewControllers.ModelsComparingScreen
{
    #region View Model
    public class ModelsComparingViewModel
    {
        public readonly UnexplainedVarianceProportionMatrix _UnexplainedVarianceProportionMatrix;
        public readonly CausalRelationshipMatrix _CausalRelationshipMatrix;
        public readonly AlgorithmService _AlgorithmService;

        public ModelsComparingViewModel(
            UnexplainedVarianceProportionMatrix unexplainedVarianceProportionMatrix,
            CausalRelationshipMatrix causalRelationshipMatrix,
            AlgorithmService algorithmService
        ) {
            this._UnexplainedVarianceProportionMatrix = unexplainedVarianceProportionMatrix;
            this._CausalRelationshipMatrix = causalRelationshipMatrix;
            this._AlgorithmService = algorithmService;
        }
    }
    #endregion View Model

    #region View Controller
    public partial class ModelsComparingViewController : AppKit.NSViewController
    {
        public ModelsComparingViewController(IntPtr handle) : base(handle) { }
        public override void ViewDidLoad() { base.ViewDidLoad(); }
        public override void ViewWillAppear() { base.ViewWillAppear(); UpdateUI(); }

        int i = 0, j = 1;
        NSWindowController CauseEffectMatrixWindowController;

        public ModelsComparingViewModel ViewModel;

        #region Xamarin.Mac Partial Methods

        partial void DrawPlot(NSButton sender)
        {
            throw new NotImplementedException();
        }

        partial void ShowNext(NSButton sender)
        {
            j += 1;

            if (j == i)
            {
                j += 1;
            }

            if (j == ViewModel._UnexplainedVarianceProportionMatrix.Columns)
            {
                j = 0;
                i += 1;
            }

            if (i == ViewModel._UnexplainedVarianceProportionMatrix.Rows)
            {
                i = 0;
                j = 1;
            }

            UpdateUI();
        }

        partial void ShowResults(NSButton sender)
        {
            CauseEffectMatrixWindowController = (NSWindowController) Storyboard.InstantiateControllerWithIdentifier("CauseEffectMatrixWindowController");
            var viewController = (CauseEffectMatrixViewController) CauseEffectMatrixWindowController.Window.ContentViewController;
            viewController.ViewModel = new CauseEffectMatrixViewModel(ViewModel._CausalRelationshipMatrix, ViewModel._AlgorithmService);

            View.Window.Close();
            CauseEffectMatrixWindowController.ShowWindow(this);
        }

        #endregion Xamarin.Mac Partial Methods

        #region Xamarin.Mac Partial Methods

        void UpdateUI()
        {
            string xOut_i = ViewModel._UnexplainedVarianceProportionMatrix[i, j].Ouput.StringValue;
            string xOut_j = ViewModel._UnexplainedVarianceProportionMatrix[j, i].Ouput.StringValue;

            string summaryResult = ViewModel._AlgorithmService.MatchParametersRelationship(
                xOut_i, 
                xOut_j, 
                ViewModel._CausalRelationshipMatrix[i, j], 
                ViewModel._CausalRelationshipMatrix[i, j]
            );

            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                X_i_findModelLabel.StringValue = $"{xOut_i} = {ViewModel._UnexplainedVarianceProportionMatrix[i, j].ModelFormula.Value}";
                X_j_findModelLabel.StringValue = $"{xOut_j} = {ViewModel._UnexplainedVarianceProportionMatrix[j, i].ModelFormula.Value}";
                Sigma_i_Label.StringValue = $"{xOut_i}({xOut_j}) Sigma = {ViewModel._UnexplainedVarianceProportionMatrix[i, j].WorkedPointsError.Value}";
                Sigma_j_Label.StringValue = $"{xOut_j}({xOut_i}) Sigma = {ViewModel._UnexplainedVarianceProportionMatrix[j, i].WorkedPointsError.Value}";
                SummaryResultLabel.StringValue = summaryResult;
            });
        }

        #endregion Xamarin.Mac Partial Methods
    }
    #endregion View Controller
}
