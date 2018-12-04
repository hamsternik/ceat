using System;
using AppKit;

using ceat.Sources.Models;
using ceat.Sources.Models.Parameters;
using ceat.Sources.ViewControllers.ExogenousProcesses.Processes;

namespace ceat.Sources.ViewControllers.ExogenousProcesses
{
	public class ExogenousProcessesViewModel
	{
		public readonly ExogenousParameters _ExogenousParameters;

		public ExogenousProcessesViewModel(ExogenousParameters exogenousParameters)
		{
			this._ExogenousParameters = exogenousParameters;
		}
	}

	public partial class ExogenousProcessesViewController : NSViewController
	{
		public ExogenousProcessesViewModel ViewModel;

		public ExogenousProcessesViewController(IntPtr handle) : base(handle) { }
		public override void ViewDidLoad() { base.ViewDidLoad(); }

		public override void ViewWillAppear()
		{
			base.ViewWillAppear();

			SetScreenElementsHiddenness(ViewModel._ExogenousParameters.Value.Length == 0);

			ProcessesTableView.DataSource = new ExogenousProcessesDataSource(ViewModel._ExogenousParameters.Value.Length);
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
