using System.Data;

namespace ceat.Sources.Models
{
    public class AnalyticalExpression
    {
        struct Indices
        {
            public static readonly int Row = 20;
            public static readonly int Column = 3;
        }

        public readonly DataTable ActiveSheet;

        public AnalyticalExpression(DataTable activeSheet)
        {
            this.ActiveSheet = activeSheet;
        }
        
        public string Value => (string)ActiveSheet.Rows[Indices.Row - 1][Indices.Column - 1];
    }
}
