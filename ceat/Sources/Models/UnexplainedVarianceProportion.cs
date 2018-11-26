namespace ceat.Sources.Models
{
    public class UnexplainedVarianceProportion
    {
        public readonly InputParameter Input;
        public readonly OutputParameter Ouput;
        public readonly AnalyticalExpression ModelFormula;
        public readonly WorkedPointsErrorValue WorkedPointsError;

        public UnexplainedVarianceProportion(
            InputParameter input, 
            OutputParameter output, 
            AnalyticalExpression formula, 
            WorkedPointsErrorValue error
        ) {
            this.Input = input;
            this.Ouput = output;
            this.ModelFormula = formula;
            this.WorkedPointsError = error;
        }

        public CausalRelationshipPair RelatedPair(UnexplainedVarianceProportion other)
        {
            return Input.StringValue == other.Ouput.StringValue
                && Ouput.StringValue == other.Input.StringValue
                ? new CausalRelationshipPair(this, other)
                : null;
        }
    }
}
