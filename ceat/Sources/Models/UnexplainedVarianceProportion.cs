using System.Text.RegularExpressions;

using ceat.Sources.Models.Parameters;

namespace ceat.Sources.Models
{
    public class UnexplainedVarianceProportion
    {
		public readonly InputParameter Input;
		public readonly OutputParameter Output;
		public readonly AnalyticalExpression ModelFormula;
		public readonly WorkedPointsErrorValue WorkedPointsError;

        public UnexplainedVarianceProportion(
            InputParameter input, 
            OutputParameter output, 
            AnalyticalExpression formula, 
            WorkedPointsErrorValue error
        ) {
            this.Input = input;
            this.Output = output;
            this.ModelFormula = formula;
            this.WorkedPointsError = error;
        }

		public int InputParameterIndex => ParameterIndexForTitle(Input.Title);
		public int OutputParameterIndex => ParameterIndexForTitle(Output.Title);

		public CausalRelationshipPair RelatedPair(UnexplainedVarianceProportion other)
        {
            return Input.Title == other.Output.Title
                && Output.Title== other.Input.Title
                ? new CausalRelationshipPair(this, other)
                : null;
        }

		private int ParameterIndexForTitle(string title)
		{
			var regex = new Regex(@"\d+");
			var matches = regex.Matches(title);
			return int.Parse(matches[0].Value);
		}
	}
}
