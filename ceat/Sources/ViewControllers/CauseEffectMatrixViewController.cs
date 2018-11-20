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

    public partial class CauseEffectMatrixViewController : AppKit.NSViewController
    {
        public CauseEffectMatrixViewController(IntPtr handle) : base(handle) { }
        public override void ViewDidLoad() { base.ViewDidLoad(); }
        
        public CauseEffectMatrixViewModel ViewModel;

    }
}
