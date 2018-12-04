using System;
using AppKit;

using ceat.Sources.Models;
using ceat.Sources.Models.Parameters;
using ceat.Sources.ViewControllers.CauseEffectMatrixScreen.CauseEffectRelationships;
using ceat.Sources.ViewControllers.ExogenousProcesses;

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
					// TODO: Pass a real List<Parameter> instead of an empty one.
					new System.Collections.Generic.List<Parameter>().ToArray(),
					ViewModel.CRMatrix,
					ViewModel.UVPMatrix
				)
			);

			ExogenousProcessesWindowController.ShowWindow(this);
		}

        partial void ShowDependencyGraph(NSButton sender)
        {
            throw new NotImplementedException();
        }

        partial void ShowParametersRelationships(NSButton sender)
        {
            throw new NotImplementedException();
        }

        partial void DidEndEnterParameterTitle(NSTextField sender)
        {
            throw new NotImplementedException();
        }
    }
}
