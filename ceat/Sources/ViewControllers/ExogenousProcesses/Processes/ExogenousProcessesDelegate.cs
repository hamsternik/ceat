using System;
using AppKit;
using Foundation;

using ceat.Sources.Models.Parameters;

namespace ceat.Sources.ViewControllers.ExogenousProcesses.Processes
{
	public class ExogenousProcessesDelegate: NSTableViewDelegate
	{
		private readonly ExogenousParameters _ExogenousParameters;
		private readonly NSTableView _TableView;

		public ExogenousProcessesDelegate(
			ExogenousParameters exogenousParameters,
			NSTableView tableView
		) {
			_ExogenousParameters = exogenousParameters;
			_TableView = tableView;
		}

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			var identifier = "CellIdentifier";
			var view = (NSTextField)tableView.MakeView (identifier, this);
			if (view == null)
			{
				view = new NSTextField
				{
					Identifier = identifier,
					Alignment = NSTextAlignment.Center,
					Bordered = false,
					Selectable = false,
					Editable = false
				};
			}

			if (tableColumn.Identifier == "ExogenousProcessTitlesColumn")
			{
				view.StringValue = _ExogenousParameters.Value[row].Title;
			}
			else /// exogenous process values column
			{
				var column = tableView.FindColumn ((NSString)tableColumn.Identifier);
				view.StringValue = $"{_ExogenousParameters.Value[row].Values[column - 1]}";
			}

			return view;
		}
	}
}
