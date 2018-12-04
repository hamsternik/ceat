namespace ceat.Sources.Models.Parameters
{
    public class OutputParameter
    {
		public string Title => _Parameter.ParameterTitles[0].Value;
		public double[] Values => this._Parameter.Values;

		private readonly Parameter _Parameter;
		private ParameterIndices OutputIndices => new ParameterIndices(30, 4);

		public OutputParameter(ExcelFile file)
        {
			this._Parameter = new Parameter(file, OutputIndices);
		}
	}
}
