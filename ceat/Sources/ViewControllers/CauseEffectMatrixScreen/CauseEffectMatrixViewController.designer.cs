// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ceat.Sources.ViewControllers.CauseEffectMatrixScreen
{
	[Register ("CauseEffectMatrixViewController")]
	partial class CauseEffectMatrixViewController
	{
		[Outlet]
		AppKit.NSTableView CauseEffectRelationshipsTableView { get; set; }

		[Outlet]
		AppKit.NSTableColumn ParameterColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn ParameterTitleColumn { get; set; }

		[Action ("DidEndEnterParameterTitle:")]
		partial void DidEndEnterParameterTitle (AppKit.NSTextField sender);

		[Action ("ShowDependencyGraph:")]
		partial void ShowDependencyGraph (AppKit.NSButton sender);

		[Action ("ShowExogenousParameters:")]
		partial void ShowExogenousParameters (AppKit.NSButton sender);

		[Action ("ShowParametersRelationships:")]
		partial void ShowParametersRelationships (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ParameterColumn != null) {
				ParameterColumn.Dispose ();
				ParameterColumn = null;
			}

			if (ParameterTitleColumn != null) {
				ParameterTitleColumn.Dispose ();
				ParameterTitleColumn = null;
			}

			if (CauseEffectRelationshipsTableView != null) {
				CauseEffectRelationshipsTableView.Dispose ();
				CauseEffectRelationshipsTableView = null;
			}
		}
	}
}
