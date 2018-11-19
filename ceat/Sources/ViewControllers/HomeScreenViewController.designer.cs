// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ceat.Sources.ViewControllers
{
	[Register ("HomeScreenViewController")]
	partial class HomeScreenViewController
	{
		[Outlet]
		AppKit.NSButton LoadDataButton { get; set; }

		[Outlet]
		AppKit.NSOutlineView LoadedDataOutlineView { get; set; }

		[Outlet]
		AppKit.NSButton ProcessDataButton { get; set; }

		[Action ("ChangeWorkModeClicked:")]
		partial void ChangeWorkModeClicked (AppKit.NSButton sender);

		[Action ("LoadDataClicked:")]
		partial void LoadDataClicked (AppKit.NSButton sender);

		[Action ("ProcessDataClicked:")]
		partial void ProcessDataClicked (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (LoadDataButton != null) {
				LoadDataButton.Dispose ();
				LoadDataButton = null;
			}

			if (ProcessDataButton != null) {
				ProcessDataButton.Dispose ();
				ProcessDataButton = null;
			}

			if (LoadedDataOutlineView != null) {
				LoadedDataOutlineView.Dispose ();
				LoadedDataOutlineView = null;
			}
		}
	}
}
