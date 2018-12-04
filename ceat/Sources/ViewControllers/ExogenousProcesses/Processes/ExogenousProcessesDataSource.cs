using System;
using AppKit;
using Foundation;

namespace ceat.Sources.ViewControllers.ExogenousProcesses.Processes
{
	public class ExogenousProcessesDataSource: NSTableViewDataSource
	{
		public readonly int ProcessesCount;

		public ExogenousProcessesDataSource(int count)
		{
			this.ProcessesCount = count;
		}

		public override nint GetRowCount(NSTableView tableView) => this.ProcessesCount;
	}
}
