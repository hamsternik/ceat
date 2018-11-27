using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

using ceat.Sources.Models;
using ceat.Sources.Services;

namespace ceat.Sources.ViewControllers
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
        public override void ViewDidLoad() 
        { 
            base.ViewDidLoad();

            //DataSource = new CauseEffecetMatrixDataSource(PropertyTitles, CAEMatrix);
            //causeEffectTableView.DataSource = DataSource;
            //causeEffectTableView.Delegate = new CauseEffecetMatrixDelegate(DataSource, causeEffectTableView);
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
