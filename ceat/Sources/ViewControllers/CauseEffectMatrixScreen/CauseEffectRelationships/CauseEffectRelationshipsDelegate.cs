﻿using System;
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

                textField.StringValue = DataSource._CausalRelationshipMatrix[(int)row, (int)tableColumnIndex - 1];
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

		#region Private Methods
		void SetupTableColumns(NSTableView tableView)
        {
            /// 1. Remove unused column
            if (CheckColumnExistence(tableView, "ParameterValuesTableColumn"))
                tableView.RemoveColumn(tableView.FindTableColumn(new NSString("ParameterValuesTableColumn")));

            /// 2. Check if exist, remove and re-create a new column
            for (int ind = 0; ind < DataSource._CausalRelationshipMatrix.Rows; ind++) 
            {
                var propertyTitle = ind < 10 ? $"x0{ind}" : $"x{ind}";
                NSTableColumn column = new NSTableColumn(propertyTitle)
                {
                    Title = propertyTitle,
                    Width = (nfloat)C.DefaultColumnWidth
                };
                tableView.AddColumn(column);
            }

            // 3. Update ParameterTitlesTableColumnID width
            var parametTitlesColumn = tableView.FindTableColumn(new NSString("ParameterTitlesTableColumn"));
            parametTitlesColumn.Width = (nfloat)C.DefaultParameterTextFieldWidth;
        }

        void SetupTextFieldInterfaceByColumnIdentifier(NSTextField textField, string identifier)
        {
            textField.Alignment = (identifier == "ParameterValuesTableColumn") ? NSTextAlignment.Right : NSTextAlignment.Center;
            textField.Selectable = true;
            textField.Editable = false;
            textField.Bordered = false;
        }

        bool CheckColumnExistence(NSTableView tableView, string tableColumnID)
        {
            var tableColumn = tableView.FindTableColumn(new NSString(tableColumnID));
            return tableColumn != null;
        }
        #endregion Private Methods
    }
}
