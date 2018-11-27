using System;
using AppKit;
using CoreGraphics;
using Foundation;

using ceat.Sources.Models;

namespace ceat.Sources.ViewControllers
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

        #region Override Methods
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
                textField.StringValue = DataSource.PropertyTitles[row];
            }
            /// for `ParameterValuesTableColumn`
            else
            {
                nint tableColumnIndex = tableView.FindColumn(new NSString(tableColumn.Title));
                if (tableColumnIndex < 0)
                    return null;

                textField.StringValue = DataSource.CAEMatrix[row, tableColumnIndex - 1];
            }

            NSView cellView = new NSView();
            cellView.AddSubview(textField);

            return cellView;
        }
        #endregion

        #region Private Methods
        void SetupTableColumns(NSTableView tableView)
        {
            /// 1. Remove unused column
            if (CheckColumnExistence(tableView, "ParameterValuesTableColumn"))
                tableView.RemoveColumn(tableView.FindTableColumn(new NSString("ParameterValuesTableColumn")));

            /// 2. Check if exist, remove and re-create a new column
            foreach (string propertyTitle in DataSource.PropertyTitles)
            {
                NSTableColumn column = new NSTableColumn(propertyTitle)
                {
                    Title = propertyTitle,
                    Width = (nfloat)C.DefaultColumnWidth
                };
                tableView.AddColumn(column);
            }

            // 3. Update ParameterTitlesTableColumnID width
            var parametTitlesColumn = tableView.FindTableColumn(new NSString("ParameterValuesTableColumn"));
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
        #endregion

    }
}
