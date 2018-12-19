using System;
using System.Linq;

namespace ceat.Sources.Models.Parameters
{
	public class ParameterDependencies
	{
		private readonly OutputParameter[] _OutputParameters;
		private readonly CausalRelationshipMatrix _CausalRelationshipMatrix;
		private readonly UnexplainedVarianceProportionMatrix _UnexplainedVarianceProportionMatrix;

		public ParameterDependencies(
			OutputParameter[] outputParameters,
			CausalRelationshipMatrix crMatrix,
			UnexplainedVarianceProportionMatrix uvpMatrix
		)
		{
			this._OutputParameters = outputParameters;
			this._CausalRelationshipMatrix = crMatrix;
			this._UnexplainedVarianceProportionMatrix = uvpMatrix;
		}

		public OutputParameter[] Value
		{
			get
			{
				// TODO: Remove this logic and write logic to find set of param. dependencies
				var exogenousParamaterValidationResults = Enumerable.Range(0, this._CausalRelationshipMatrix.Dimension.Rows)
					.Select(_CausalRelationshipMatrix.RowByIndex)
					.Select(crRow => crRow.Where(elem => elem != CausalRelationshipMatrix.C.DefaultComparingResultItem).ToArray())
					.Select(crRow => crRow.Aggregate(true, (acc, str) => acc && int.Parse(str) == 1))
					.ToArray();

				return Enumerable.Range(0, exogenousParamaterValidationResults.Length)
					.Where(rowIndex => exogenousParamaterValidationResults[rowIndex])
					.Select(index => this._OutputParameters.ElementAtOrDefault(index))
					.ToArray();
			}
		}
	}
}
