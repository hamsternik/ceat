using System;
using AppKit;
using Foundation;

using ceat.Sources.Models;

namespace ceat.Sources.ViewControllers.HomeScreen.LoadedData
{
    public class LoadedDataOutlineDataSource : NSOutlineViewDataSource
    {
        public readonly RootDirectory RootDataDir;

        public LoadedDataOutlineDataSource(RootDirectory rootDataDir)
        {
            this.RootDataDir = rootDataDir;
        }

        #region Override Methods
        public override nint GetChildrenCount(NSOutlineView outlineView, NSObject item)
        {
            if (item == null)
                return RootDataDir.Directories.Count;
            else
                return ((Directory)item).ExcelFiles.Count;
        }

        public override NSObject GetChild(NSOutlineView outlineView, nint childIndex, NSObject item)
        {
            if (item == null)
                return RootDataDir.Directories[(int)childIndex];
            else
                return ((Directory)item).ExcelFiles[(int)childIndex];

        }

        public override bool ItemExpandable(NSOutlineView outlineView, NSObject item)
        {
            return item == null || item is Directory;
        }
        #endregion
    }
}
