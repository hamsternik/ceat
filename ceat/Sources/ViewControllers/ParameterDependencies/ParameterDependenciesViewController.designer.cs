// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ceat.Sources.ViewControllers.ParameterDependencies
{
	[Register ("ParameterDependenciesViewController")]
	partial class ParameterDependenciesViewController
	{
		[Outlet]
		AppKit.NSTextField EmptyDescriptionLabel { get; set; }

		[Outlet]
		AppKit.NSTableColumn ParameterDependencyTitlesColumn { get; set; }

		[Outlet]
		AppKit.NSTableView ProcessesTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (EmptyDescriptionLabel != null) {
				EmptyDescriptionLabel.Dispose ();
				EmptyDescriptionLabel = null;
			}

			if (ParameterDependencyTitlesColumn != null) {
				ParameterDependencyTitlesColumn.Dispose ();
				ParameterDependencyTitlesColumn = null;
			}

			if (ProcessesTableView != null) {
				ProcessesTableView.Dispose ();
				ProcessesTableView = null;
			}
		}
	}
}
