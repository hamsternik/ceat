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

        public ModelsComparingViewModel(
            UnexplainedVarianceProportionMatrix unexplainedVarianceProportionMatrix,
            CausalRelationshipMatrix causalRelationshipMatrix
        ) {
            this._UnexplainedVarianceProportionMatrix = unexplainedVarianceProportionMatrix;
            this._CausalRelationshipMatrix = causalRelationshipMatrix;
        }
    }
    #endregion View Model

    #region View Controller
    public partial class ModelsComparingViewController : NSViewController
    {
        public ModelsComparingViewController(IntPtr handle) : base(handle) { }
        public override void ViewDidLoad() { base.ViewDidLoad(); }
        public override void ViewWillAppear() { base.ViewWillAppear(); UpdateUI(); }

        public ModelsComparingViewModel ViewModel;
		public AlgorithmService Algorithms;

		int i = 0, j = 1;
		NSWindowController CauseEffectMatrixWindowController;

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

            if (j == ViewModel._UnexplainedVarianceProportionMatrix.Dimension.Columns)
            {
                j = 0;
                i += 1;
            }

            if (i == ViewModel._UnexplainedVarianceProportionMatrix.Dimension.Rows)
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
            viewController.ViewModel = new CauseEffectMatrixViewModel(
            	ViewModel._UnexplainedVarianceProportionMatrix, 
				ViewModel._CausalRelationshipMatrix
			);

            View.Window.Close();
            CauseEffectMatrixWindowController.ShowWindow(this);
        }

        #endregion Xamarin.Mac Partial Methods

        #region Xamarin.Mac Partial Methods

        void UpdateUI()
        {
			string xOut_i = $"x{ViewModel._UnexplainedVarianceProportionMatrix[i, j].OutputParameterIndex}";
			string xOut_j = $"x{ViewModel._UnexplainedVarianceProportionMatrix[j, i].OutputParameterIndex}";

			string summaryResult = Algorithms.MatchParametersRelationship(
				xOut_i,
				xOut_j,
				ViewModel._CausalRelationshipMatrix[i, j],
				ViewModel._CausalRelationshipMatrix[j, i]
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
