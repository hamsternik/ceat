using System;
using AppKit;

using ceat.Sources.Models;

namespace ceat.Sources.ViewControllers.CauseEffectMatrixScreen.CauseEffectRelationships
{
    public class CauseEffectRelationshipsDataSource: NSTableViewDataSource
    {
        public readonly CausalRelationshipMatrix Matrix;

        public CauseEffectRelationshipsDataSource(CausalRelationshipMatrix matrix)
        {
            this.Matrix = matrix;
        }

		public override nint GetRowCount(NSTableView tableView) => Matrix.Dimension.Rows;
	}
}
