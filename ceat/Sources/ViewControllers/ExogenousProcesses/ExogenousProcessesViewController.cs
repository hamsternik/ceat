using System;
using AppKit;
using Foundation;

using ceat.Sources.Models.Parameters;
using ceat.Sources.ViewControllers.ExogenousProcesses.Processes;

namespace ceat.Sources.ViewControllers.ExogenousProcesses
{
	public class ExogenousProcessesViewModel
	{
		public readonly ExogenousParameters _ExogenousParameters;

		public ExogenousProcessesViewModel (ExogenousParameters exogenousParameters)
		{
			this._ExogenousParameters = exogenousParameters;
		}
	}

	public partial class ExogenousProcessesViewController : NSViewController
	{
		public static class C
		{
			public static double DefaultColumnWidth => 75.0;
			public static double DefaultParameterTextFieldWidth => 55.0;
			public static double DefaultParameterTextFieldHeight => 17.0;
		}

		public ExogenousProcessesViewModel ViewModel;

		public ExogenousProcessesViewController (IntPtr handle) : base (handle) {}
		public override void ViewDidLoad () { base.ViewDidLoad(); }

		public override void ViewWillAppear ()
		{
			base.ViewWillAppear ();

			SetScreenElementsHiddenness (ViewModel._ExogenousParameters.Value.Length == 0);
			SetupTableViewColumns();

			ProcessesTableView.DataSource = new ExogenousProcessesDataSource (ViewModel._ExogenousParameters.Value.Length);
			ProcessesTableView.Delegate = new ExogenousProcessesDelegate (ViewModel._ExogenousParameters, ProcessesTableView);
		}

		void SetupTableViewColumns ()
		{
			var titlesColumn = ProcessesTableView.FindTableColumn(new NSString("ExogenousProcessTitlesColumn"));
			titlesColumn.Width = (nfloat)C.DefaultParameterTextFieldWidth;

			for (int i = 0; i < ViewModel._ExogenousParameters.Value[0].Values.Length; i++)
			{
				var title = $"t{i + 1}";
				ProcessesTableView.AddColumn(new NSTableColumn
				{
					Title = title,
					Width = (nfloat)C.DefaultColumnWidth
				});
			}
		}

		void SetScreenElementsHiddenness (bool isMatrixEmpty) 
		{
			EmptyProcessCountDescriptionLabel.Hidden = !isMatrixEmpty;
			ProcessesTableView.Hidden = isMatrixEmpty;
		}
	}
}
