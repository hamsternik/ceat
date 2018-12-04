using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace ceat.Sources.ViewControllers.CauseEffectMatrixScreen.CauseEffectRelationships
{
    public class CauseEffectRelationshipsDelegate: NSTableViewDelegate
    {
        public static class C
        {
            public static double DefaultColumnWidth => 75.0;
            public static double DefaultParameterTextFieldWidth => 55.0;
            public static double DefaultParameterTextFieldHeight => 17.0;
        }

        public readonly CauseEffectRelationshipsDataSource DataSource;

        public CauseEffectRelationshipsDelegate(
            CauseEffectRelationshipsDataSource dataSource, 
            NSTableView tableView
        ) {
            this.DataSource = dataSource;
            SetupTableColumns(tableView);
        }

		#region NSTableViewDelegate Methods
		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            double tfWidth = (tableColumn.Identifier == "ParameterTitlesTableColumn") 
                ? C.DefaultParameterTextFieldWidth 
                   : C.DefaultColumnWidth;

            NSTextField textField = new NSTextField(
                new CGRect(0.0, 0.0, tfWidth, C.DefaultParameterTextFieldHeight)
            );

            SetupTextFieldInterfaceByColumnIdentifier(textField, tableColumn.Identifier);

            /// Setup data in the textField
            if (tableColumn.Identifier == "ParameterTitlesTableColumn")
            {
                var propertyTitle = row < 10 ? $"x0{row}" : $"x{row}";
                textField.StringValue = propertyTitle;
            }
            /// for `ParameterValuesTableColumn`
            else
            {
                nint tableColumnIndex = tableView.FindColumn(new NSString(tableColumn.Title));
                if (tableColumnIndex < 0)
                    return null;

                textField.StringValue = DataSource.Matrix[(int)row, (int)tableColumnIndex - 1];
            }

            NSView cellView = new NSView();
            cellView.AddSubview(textField);

            return cellView;
        }

		public override nfloat GetRowHeight(NSTableView tableView, nint row)
		{
			return (nfloat)C.DefaultParameterTextFieldHeight;
		}
		#endregion NSTableViewDelegate Methods

		void SetupTableColumns(NSTableView tableView)
        {
			/// Update titles column .width
			var titlesColumn = tableView.FindTableColumn(new NSString("ParameterTitlesTableColumn"));
			titlesColumn.Width = (nfloat)C.DefaultParameterTextFieldWidth;

			/// Remove unused `ParameterValuesTableColumn` column
			var unusedParameterValuesColumn = tableView.FindTableColumn(new NSString("ParameterValuesTableColumn"));
			if (unusedParameterValuesColumn != null)
                tableView.RemoveColumn(unusedParameterValuesColumn);

            /// Add columns for each variable (`x*` input process)
            for (int ind = 0; ind < DataSource.Matrix.Dimension.Rows; ind++) 
            {
                var propertyTitle = ind < 10 ? $"x0{ind}" : $"x{ind}";
                NSTableColumn column = new NSTableColumn(propertyTitle)
                {
                    Title = propertyTitle,
                    Width = (nfloat)C.DefaultColumnWidth
                };
                tableView.AddColumn(column);
            }
        }

        void SetupTextFieldInterfaceByColumnIdentifier(NSTextField textField, string identifier)
        {
            textField.Alignment = (identifier == "ParameterValuesTableColumn") ? NSTextAlignment.Right : NSTextAlignment.Center;
            textField.Selectable = true;
            textField.Editable = false;
            textField.Bordered = false;
        }
	}
}
