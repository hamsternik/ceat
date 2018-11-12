using Foundation;
using System.Collections.Generic;

namespace ceat.Sources.Models
{
    public class ExcelDataModel
    {
        readonly string AnalyticalExpression;
        readonly double WorkedPointsErrorValue;

        readonly List<double> ActualValues = new List<double>();
        readonly List<double> ExpectedPoints = new List<double>();

        public ExcelDataModel(string analyticalExpression, double workedPointsErrorValue)
        {
            this.AnalyticalExpression = analyticalExpression;
            this.WorkedPointsErrorValue = workedPointsErrorValue;
        }
    }
}
