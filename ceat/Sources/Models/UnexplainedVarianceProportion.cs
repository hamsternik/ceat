namespace ceat.Sources.Models
{
    public class UnexplainedVarianceProportion
    {
        public readonly WorkedPointsErrorValue WorkedPointsError;
        public readonly InputParameter Input;
        public readonly OutputParameter Ouput;

        public UnexplainedVarianceProportion(WorkedPointsErrorValue error, InputParameter input, OutputParameter output)
        {
            this.WorkedPointsError = error;
            this.Input = input;
            this.Ouput = output;
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
