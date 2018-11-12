using System.Data;

namespace ceat.Sources.Models
{
    public class WorkedPointsErrorValue
    {
        struct Indices
        {
            public static readonly int Row = 22;
            public static readonly int Column = 5;
        }

        public readonly DataTable ActiveSheet;

        public WorkedPointsErrorValue(DataTable activeSheet)
        {
            this.ActiveSheet = activeSheet;
        }

        public double Value => (double)ActiveSheet.Rows[Indices.Row - 1][Indices.Column - 1];
    }
}
