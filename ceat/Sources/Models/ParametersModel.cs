using System;

namespace ceat.Sources.Models
{
    public class ParametersModel
    {
        public readonly AnalyticalExpression Expression;
        public readonly WorkedPointsErrorValue ErrorValue;

        public ParametersModel(AnalyticalExpression expression, WorkedPointsErrorValue errorValue)
        {
            this.Expression = expression;
            this.ErrorValue = errorValue;
        }
    }
}
