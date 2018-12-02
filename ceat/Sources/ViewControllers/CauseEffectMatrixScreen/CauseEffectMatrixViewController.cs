using System;
using AppKit;

using ceat.Sources.Models;
using ceat.Sources.Services;
using ceat.Sources.ViewControllers.CauseEffectMatrixScreen.CauseEffectRelationships;

namespace ceat.Sources.ViewControllers.CauseEffectMatrixScreen
{
    public class CauseEffectMatrixViewModel
    {
        public readonly CausalRelationshipMatrix _CausalRelationshipMatrix;
        public readonly AlgorithmService _AlgorithmService;

        public CauseEffectMatrixViewModel(
            CausalRelationshipMatrix causalRelationshipMatrix, 
            AlgorithmService algorithmService
        ) {
            this._CausalRelationshipMatrix = causalRelationshipMatrix;
            this._AlgorithmService = algorithmService;
        }
    }

    public partial class CauseEffectMatrixViewController : NSViewController
    {
        public CauseEffectMatrixViewModel ViewModel;

        public CauseEffectMatrixViewController(IntPtr handle) : base(handle) { }
        public override void ViewDidLoad() { base.ViewDidLoad(); }

		public override void ViewWillAppear()
		{
			base.ViewWillAppear();

			CauseEffectRelationshipsTableView.DataSource = new CauseEffectRelationshipsDataSource(ViewModel._CausalRelationshipMatrix);
			CauseEffectRelationshipsTableView.Delegate = new CauseEffectRelationshipsDelegate(
				(CauseEffectRelationshipsDataSource)CauseEffectRelationshipsTableView.DataSource,
				CauseEffectRelationshipsTableView
			);
		}

		partial void ShowExogenousParameters(NSButton sender)
        {
            throw new NotImplementedException();
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
