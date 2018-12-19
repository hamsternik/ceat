using System;
using AppKit;
using System.Linq;

using ceat.Sources.Models;
using ceat.Sources.Models.Parameters;
using ceat.Sources.ViewControllers.CauseEffectMatrixScreen.CauseEffectRelationships;
using ceat.Sources.ViewControllers.ExogenousProcesses;
using ceat.Sources.ViewControllers.ParameterDependencies;

namespace ceat.Sources.ViewControllers.CauseEffectMatrixScreen
{
    public class CauseEffectMatrixViewModel
    {
		public readonly UnexplainedVarianceProportionMatrix UVPMatrix;
		public readonly CausalRelationshipMatrix CRMatrix;

		public CauseEffectMatrixViewModel(UnexplainedVarianceProportionMatrix uvpMatrix, CausalRelationshipMatrix crMatrix)
        {
			this.UVPMatrix = uvpMatrix;
			this.CRMatrix = crMatrix;
		}
    }

    public partial class CauseEffectMatrixViewController : NSViewController
    {
        public CauseEffectMatrixViewModel ViewModel;
		NSWindowController ExogenousProcessesWindowController;
		NSWindowController ParameterDependenciesWindowController;

		public CauseEffectMatrixViewController(IntPtr handle) : base(handle) {}
        public override void ViewDidLoad() { base.ViewDidLoad(); }

		public override void ViewWillAppear()
		{
			base.ViewWillAppear();

			CauseEffectRelationshipsTableView.DataSource = new CauseEffectRelationshipsDataSource(ViewModel.CRMatrix);
			CauseEffectRelationshipsTableView.Delegate = new CauseEffectRelationshipsDelegate(
				(CauseEffectRelationshipsDataSource)CauseEffectRelationshipsTableView.DataSource,
				CauseEffectRelationshipsTableView
			);
		}

		partial void ShowExogenousParameters(NSButton sender)
        {
			ExogenousProcessesWindowController = (NSWindowController)Storyboard.InstantiateControllerWithIdentifier("ExogenousProcessesWindowController");
			var viewController = (ExogenousProcessesViewController)ExogenousProcessesWindowController.Window.ContentViewController;

			viewController.ViewModel = new ExogenousProcessesViewModel(
				new ExogenousParameters(
					Enumerable.Range(0, ViewModel.UVPMatrix.Dimension.Rows)
						.Select(ViewModel.UVPMatrix.RowByIndex)
						.Select(uvpRow => uvpRow.First(elem => elem != null))
						.Select(uvp => uvp.Output)
						.ToArray(),
					ViewModel.CRMatrix,
					ViewModel.UVPMatrix
				)
			);

			ExogenousProcessesWindowController.ShowWindow(this);
		}

        partial void ShowDependencyGraph(NSButton sender)
        {
            // throw new NotImplementedException();
        }

        partial void ShowParametersRelationships(NSButton sender)
        {
			ParameterDependenciesWindowController = (NSWindowController)Storyboard.InstantiateControllerWithIdentifier("ParameterDependenciesWindowController");
			var viewController = (ParameterDependenciesViewController)ExogenousProcessesWindowController.Window.ContentViewController;

			//viewController.ViewModel = new ParameterDependenciesViewModel(
				//new ExogenousParameters(
				//	Enumerable.Range(0, ViewModel.UVPMatrix.Dimension.Rows)
				//		.Select(ViewModel.UVPMatrix.RowByIndex)
				//		.Select(uvpRow => uvpRow.First(elem => elem != null))
				//		.Select(uvp => uvp.Output)
				//		.ToArray(),
				//	ViewModel.CRMatrix,
				//	ViewModel.UVPMatrix
				//)
			//);
		}

        partial void DidEndEnterParameterTitle(NSTextField sender)
        {
            //throw new NotImplementedException();
        }
    }
}
