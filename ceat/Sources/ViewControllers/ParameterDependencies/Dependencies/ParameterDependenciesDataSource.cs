using System;
using AppKit;

namespace ceat.Sources.ViewControllers.ParameterDependencies.Dependencies
{
	public class ParameterDependenciesDataSource: NSTableViewDataSource
	{
		public readonly int ProcessesCount;

		public ParameterDependenciesDataSource(int count)
		{
			this.ProcessesCount = count;
		}

		public override nint GetRowCount(NSTableView tableView) => this.ProcessesCount;
	}
}
