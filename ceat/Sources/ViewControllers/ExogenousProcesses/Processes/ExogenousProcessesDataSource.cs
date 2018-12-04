using System;
using AppKit;

using ceat.Sources.Models;

namespace ceat.Sources.ViewControllers.ExogenousProcesses.Processes
{
	public class ExogenousProcessesDataSource: NSTableViewDataSource
	{
		// TODO: Should be another properties (CausalRelationshipMatrix doesn't needed here)
		public readonly CausalRelationshipMatrix Matrix;

		public ExogenousProcessesDataSource(CausalRelationshipMatrix matrix)
		{
			this.Matrix = matrix;
		}

		public override nint GetRowCount(NSTableView tableView) => Matrix.Rows;
	}
}
