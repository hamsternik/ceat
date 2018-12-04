// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ceat.Sources.ViewControllers.ExogenousProcesses
{
	[Register ("ExogenousProcessesViewController")]
	partial class ExogenousProcessesViewController
	{
		[Outlet]
		AppKit.NSTextField EmptyProcessCountDescriptionLabel { get; set; }

		[Outlet]
		AppKit.NSTableColumn ExogenousProcessTitlesColumn { get; set; }

		[Outlet]
		AppKit.NSTableView ProcessesTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (EmptyProcessCountDescriptionLabel != null) {
				EmptyProcessCountDescriptionLabel.Dispose ();
				EmptyProcessCountDescriptionLabel = null;
			}

			if (ExogenousProcessTitlesColumn != null) {
				ExogenousProcessTitlesColumn.Dispose ();
				ExogenousProcessTitlesColumn = null;
			}

			if (ProcessesTableView != null) {
				ProcessesTableView.Dispose ();
				ProcessesTableView = null;
			}
		}
	}
}
