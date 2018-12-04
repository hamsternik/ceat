using System.Collections.Generic;

using ceat.Sources.Models.Parameters;

namespace ceat.Sources.Models
{
    public class UnexplainedVarianceProportionList
    {
        public readonly List<UnexplainedVarianceProportion> Value = new List<UnexplainedVarianceProportion>();

        public UnexplainedVarianceProportionList(List<Directory> directories)
        {
            for (int i = 0; i < directories.Count; i++)
            {
                for (int j = 0; j < directories[i].ExcelFiles.Count; j++)
                {
					Value.Add(new UnexplainedVarianceProportion(
                        new InputParameter(directories[i].ExcelFiles[j]),
                        new OutputParameter(directories[i].ExcelFiles[j]),
                        new AnalyticalExpression(directories[i].ExcelFiles[j].ActiveSheet),
                        new WorkedPointsErrorValue(directories[i].ExcelFiles[j].ActiveSheet)
                    ));
                }
            }
        }

    }
}
