using System;
using AppKit;

using ceat.Sources.Models;
using ceat.Sources.ViewControllers.ExogenousProcesses.Processes;

namespace ceat.Sources.ViewControllers.ExogenousProcesses
{
	public class ExogenousProcessesViewModel
	{
		// TODO: Should has another properties (CausalRelationshipMatrix doesn't needed here)
		public readonly CausalRelationshipMatrix Matrix;

		public ExogenousProcessesViewModel(CausalRelationshipMatrix matrix)
		{
			this.Matrix = matrix;
		}
	}

	public partial class ExogenousProcessesViewController : NSViewController
	{
		public ExogenousProcessesViewModel ViewModel;

		public ExogenousProcessesViewController(IntPtr handle) : base(handle) { }
		public override void ViewDidLoad() { 
			base.ViewDidLoad();

			SetScreenElementsHiddenness(ViewModel.Matrix.Rows == 0);
		}

		public override void ViewWillAppear()
		{
			base.ViewWillAppear();

			ProcessesTableView.DataSource = new ExogenousProcessesDataSource(ViewModel.Matrix);
			ProcessesTableView.Delegate = new ExogenousProcessesDelegate(
				(ExogenousProcessesDataSource)ProcessesTableView.DataSource,
				ProcessesTableView
			);
		}

		void SetScreenElementsHiddenness(bool isMatrixEmpty) 
		{
			EmptyProcessCountDescriptionLabel.Hidden = !isMatrixEmpty;
			ProcessesTableView.Hidden = isMatrixEmpty;
		}
	}
}
