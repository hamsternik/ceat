using System;
using AppKit;
using Foundation;

using ceat.Sources.Models.Parameters;
using ceat.Sources.ViewControllers.ParameterDependencies.Dependencies;

namespace ceat.Sources.ViewControllers.ParameterDependencies
{
	public class ParameterDependenciesViewModel
	{
		public readonly Models.Parameters.ParameterDependencies _ParameterDependencies;

		public ParameterDependenciesViewModel(Models.Parameters.ParameterDependencies parameterDependencies)
		{
			this._ParameterDependencies = parameterDependencies;
		}
	}

	public partial class ParameterDependenciesViewController : NSViewController
	{
		public static class C
		{
			public static double DefaultColumnWidth => 75.0;
			public static double DefaultParameterTextFieldWidth => 55.0;
			public static double DefaultParameterTextFieldHeight => 17.0;
		}

		public ParameterDependenciesViewModel ViewModel;

		public ParameterDependenciesViewController(IntPtr handle) : base(handle) { }
		public override void ViewDidLoad() { base.ViewDidLoad(); }

		public override void ViewWillAppear()
		{
			base.ViewWillAppear();

			SetScreenElementsHiddenness(ViewModel._ParameterDependencies.Value.Length == 0);
			SetupTableViewColumns();

			//ProcessesTableView.DataSource = new ParameterDependenciesDataSource(ViewModel._ExogenousParameters.Value.Length);
			//ProcessesTableView.Delegate = new ParameterDependenciesDelegate(ViewModel._ExogenousParameters, ProcessesTableView);
		}

		void SetupTableViewColumns()
		{
			var titlesColumn = ProcessesTableView.FindTableColumn(new NSString("ParameterDependencyTitlesColumn"));
			titlesColumn.Width = (nfloat)C.DefaultParameterTextFieldWidth;

			for (int i = 0; i < ViewModel._ParameterDependencies.Value[0].Values.Length; i++)
			{
				var title = $"t{i + 1}";
				var header = new NSCell
				{
					Title = title,
					Bordered = true,
					Highlighted = false,
					Selectable = false,
					Editable = false,
					Alignment = NSTextAlignment.Center,
					State = NSCellStateValue.On
				};

				ProcessesTableView.AddColumn(new NSTableColumn
				{
					Title = title,
					Width = (nfloat)C.DefaultColumnWidth,
					HeaderCell = header
				});
			}
		}

		void SetScreenElementsHiddenness(bool isMatrixEmpty)
		{
			EmptyDescriptionLabel.Hidden = !isMatrixEmpty;
			ProcessesTableView.Hidden = isMatrixEmpty;
		}
	}
}
