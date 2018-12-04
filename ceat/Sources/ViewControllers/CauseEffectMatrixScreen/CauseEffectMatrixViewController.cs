using System;
using AppKit;

using ceat.Sources.Models;
using ceat.Sources.ViewControllers.CauseEffectMatrixScreen.CauseEffectRelationships;
using ceat.Sources.ViewControllers.ExogenousProcesses;

namespace ceat.Sources.ViewControllers.CauseEffectMatrixScreen
{
    public class CauseEffectMatrixViewModel
    {
        public readonly CausalRelationshipMatrix Matrix;
        
        public CauseEffectMatrixViewModel(CausalRelationshipMatrix matrix) 
        {
            this.Matrix = matrix;
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

			CauseEffectRelationshipsTableView.DataSource = new CauseEffectRelationshipsDataSource(ViewModel.Matrix);
			CauseEffectRelationshipsTableView.Delegate = new CauseEffectRelationshipsDelegate(
				(CauseEffectRelationshipsDataSource)CauseEffectRelationshipsTableView.DataSource,
				CauseEffectRelationshipsTableView
			);
		}

		partial void ShowExogenousParameters(NSButton sender)
        {
			// ExogenousProcessesViewController
			ExogenousProcessesWindowController = (NSWindowController)Storyboard.InstantiateControllerWithIdentifier("ExogenousProcessesWindowController");
			var viewController = (ExogenousProcessesViewController)ExogenousProcessesWindowController.Window.ContentViewController;
			viewController.ViewModel = new ExogenousProcessesViewModel(ViewModel.Matrix);

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
