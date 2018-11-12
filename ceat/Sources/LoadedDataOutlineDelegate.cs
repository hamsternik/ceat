using System;
using Foundation;
using AppKit;

using ceat.Sources.Models;

namespace ceat.Sources
{
    public class LoadedDataOutlineDelegate : NSOutlineViewDelegate
    {
        private const string CellIdentifier = "LoadedDataOutlineViewCell";

        public readonly LoadedDataOutlineDataSource DataSource;

        public LoadedDataOutlineDelegate(LoadedDataOutlineDataSource datasource)
        {
            this.DataSource = datasource;
        }

        #region Override Methods
        public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
        {
            NSTextField view = (NSTextField)outlineView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField
                {
                    Identifier = CellIdentifier,
                    BackgroundColor = NSColor.Clear,
                    Bordered = false,
                    Selectable = true,
                    Editable = false
                };
            }

            switch (item)
            {
                case Directory dir:
                    view.StringValue = dir.Title;
                    break;
                case ExcelFile excel:
                    view.StringValue = excel.Title(true);
                    break;
                default:
                    break;
            }

            return view;
        }
        #endregion
    }
}
