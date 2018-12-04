using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace ceat.Sources.Models.Parameters
{
	public class InputParameter
    {
		public readonly Parameter _Parameter;

		public string Title => _Parameter.ParameterTitles[1].Value;
		public double[] Values => this._Parameter.Values;

		private ParameterIndices InputIndices => new ParameterIndices(30, 6);

		public InputParameter(ExcelFile file)
        {
			this._Parameter = new Parameter(file, InputIndices);
		}

		//public string Title
		//{
		//	get
		//	{
		//		var inputParameters = new List<string>();
		//		foreach (Match param in _Parameter.ParameterTitles)
		//		{
		//			inputParameters.Add(param.Value);
		//		}
		//		return inputParameters.Skip(1).ToArray()[0];
		//	}
		//}
	}
}
