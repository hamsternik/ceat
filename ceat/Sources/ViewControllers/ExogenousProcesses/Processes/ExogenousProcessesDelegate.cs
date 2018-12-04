using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace ceat.Sources.ViewControllers.ExogenousProcesses.Processes
{
	public class ExogenousProcessesDelegate: NSTableViewDelegate
	{
		public static class C
		{
			public static double DefaultColumnWidth => 45.0;
			public static double DefaultParameterTextFieldWidth => 55.0;
			public static double DefaultParameterTextFieldHeight => 17.0;
		}

		public readonly ExogenousProcessesDataSource DataSource;

		public ExogenousProcessesDelegate(
			ExogenousProcessesDataSource dataSource,
			NSTableView tableView
		) {
			this.DataSource = dataSource;
			SetupTableColumns(tableView);
		}

		void SetupTableColumns(NSTableView tableView)
		{
			var titlesColumn = tableView.FindTableColumn(new NSString("ExogenousProcessTitlesColumn"));
			titlesColumn.Width = (nfloat)C.DefaultParameterTextFieldWidth;
			
			for (int ind = 0; ind < DataSource.Matrix.Rows; ind++)
			{
				var title = $"t{ind+1}";
				NSTableColumn valuesColumn = new NSTableColumn(title)
				{
					Title = title,
					Width = (nfloat)C.DefaultColumnWidth
				};
				tableView.AddColumn(valuesColumn);
			}
		}
	}
}
