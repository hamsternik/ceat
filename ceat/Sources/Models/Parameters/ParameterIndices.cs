namespace ceat.Sources.Models.Parameters
{
	public struct ParameterIndices
	{
		public readonly int Row;
		public readonly int Column;

		public ParameterIndices(int row, int column)
		{
			this.Row = row;
			this.Column = column;
		}
	}
}
