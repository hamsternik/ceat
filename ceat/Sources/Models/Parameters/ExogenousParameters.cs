using System.Linq;

namespace ceat.Sources.Models.Parameters
{
	/// FYI: Small description about most prefferable operators from MS LinQ.
	/// Map = Select | Enumerable.Range(1, 10).Select(x => x + 2);
	/// Reduce = Aggregate | Enumerable.Range(1, 10).Aggregate(0, (acc, x) => acc + x);
	/// Filter = Where | Enumerable.Range(1, 10).Where(x => x % 2 == 0);

	public class ExogenousParameters
	{
		private readonly OutputParameter[] _OutputParameters;
		private readonly CausalRelationshipMatrix _CausalRelationshipMatrix;
		private readonly UnexplainedVarianceProportionMatrix _UnexplainedVarianceProportionMatrix;

		public ExogenousParameters(
			OutputParameter[] outputParameters, 
			CausalRelationshipMatrix crMatrix, 
			UnexplainedVarianceProportionMatrix uvpMatrix
		) {
			this._OutputParameters = outputParameters;
			this._CausalRelationshipMatrix = crMatrix;
			this._UnexplainedVarianceProportionMatrix = uvpMatrix;
		}

		public OutputParameter[] Value
		{
			get 
			{
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
