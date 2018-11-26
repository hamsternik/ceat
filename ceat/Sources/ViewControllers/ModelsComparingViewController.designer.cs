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
	[Register ("ModelsComparingViewController")]
	partial class ModelsComparingViewController
	{
		[Outlet]
		AppKit.NSTextField Sigma_i_Label { get; set; }

		[Outlet]
		AppKit.NSTextField Sigma_j_Label { get; set; }

		[Outlet]
		AppKit.NSTextField SummaryResultLabel { get; set; }

		[Outlet]
		AppKit.NSTextField X_i_findModelLabel { get; set; }

		[Outlet]
		AppKit.NSTextField X_j_findModelLabel { get; set; }

		[Action ("DrawPlot:")]
		partial void DrawPlot (AppKit.NSButton sender);

		[Action ("ShowNext:")]
		partial void ShowNext (AppKit.NSButton sender);

		[Action ("ShowResults:")]
		partial void ShowResults (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Sigma_i_Label != null) {
				Sigma_i_Label.Dispose ();
				Sigma_i_Label = null;
			}

			if (Sigma_j_Label != null) {
				Sigma_j_Label.Dispose ();
				Sigma_j_Label = null;
			}

			if (SummaryResultLabel != null) {
				SummaryResultLabel.Dispose ();
				SummaryResultLabel = null;
			}

			if (X_i_findModelLabel != null) {
				X_i_findModelLabel.Dispose ();
				X_i_findModelLabel = null;
			}

			if (X_j_findModelLabel != null) {
				X_j_findModelLabel.Dispose ();
				X_j_findModelLabel = null;
			}
		}
	}
}
