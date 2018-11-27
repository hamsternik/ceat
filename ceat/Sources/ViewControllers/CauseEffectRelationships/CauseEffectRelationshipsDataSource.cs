using System;
using AppKit;

using ceat.Sources.Models;

namespace ceat.Sources.ViewControllers
{
    public class CauseEffectRelationshipsDataSource: NSTableViewDataSource
    {
        public readonly CausalRelationshipMatrix _CausalRelationshipMatrix;

        public CauseEffectRelationshipsDataSource(CausalRelationshipMatrix causalRelationshipMatrix)
        {
            this._CausalRelationshipMatrix = causalRelationshipMatrix;
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return _CausalRelationshipMatrix.Rows;
        }
    }
}
