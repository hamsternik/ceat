using AppKit;
using System;
using System.Collections.Generic;
using System.Linq;

using ceat.Sources.Models;
using ceat.Sources.Services;

namespace ceat.Sources.ViewControllers
{
    public class ModelsComparingViewModel 
    {
        public readonly UnexplainedVarianceProportionMatrix _UnexplainedVarianceProportionMatrix;
        public readonly AlgorithmService _AlgorithmService;

        public ModelsComparingViewModel(
            UnexplainedVarianceProportionMatrix unexplainedVarianceProportionMatrix, 
            AlgorithmService algorithmService
        ) {
            this._UnexplainedVarianceProportionMatrix = unexplainedVarianceProportionMatrix;
            this._AlgorithmService = algorithmService;
        }
    }

    public partial class ModelsComparingViewController : AppKit.NSViewController
    {
        public ModelsComparingViewController(IntPtr handle) : base(handle) { }
        public override void ViewDidLoad() { base.ViewDidLoad(); }

        public ModelsComparingViewModel ViewModel;

    }
}
