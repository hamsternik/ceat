using System;
using System.Linq;

namespace ceat.Sources.Models
{
    public class UnexplainedVarianceProportionMatrix
    {
        public readonly UnexplainedVarianceProportion[,] Value;

		public (int Rows, int Columns) Dimension => ((int)Value.GetLength(0), (int)Value.GetLength(1));

		public UnexplainedVarianceProportion this[int row, int column] => this.Value[row, column];

		public UnexplainedVarianceProportionMatrix(UnexplainedVarianceProportionList uvpList, nint dirCount)
        {
            this.Value = new UnexplainedVarianceProportion[dirCount, dirCount];
            for (int i = 0; i < dirCount; i++)
            {
                for (int j = 0; j < dirCount; j++)
                {
                    if (i != j)
                    {
                        this.Value[i, j] = uvpList.Value.Find(
                            element => (element.OutputParameterIndex - 1) == i && (element.InputParameterIndex - 1) == j
                        );
                    }
                    else
                    {
                        this.Value[i, j] = null;
                    }
                }
            }
        }

		public UnexplainedVarianceProportion[] RowByIndex(int rowIndex) 
		{
			return Enumerable.Range(0, Dimension.Columns)
				.Select(columnIndex => this.Value[rowIndex, columnIndex])
				.ToArray();
		}

		public UnexplainedVarianceProportion[] ColumnByIndex(int columnIndex)
		{
			return Enumerable.Range(0, Dimension.Rows)
				.Select(rowIndex => this.Value[rowIndex, columnIndex])
				.ToArray();
		}

        public void Print()
        {
            Console.WriteLine("-=== Unexplained Variance Proportion Matrix [Error values] ===-");
            for (int i = 0; i < Value.GetLength(0); i++)
            {
                for (int j = 0; j < Value.GetLength(1); j++)
                {
                    Console.Write($"{Value[i, j]?.WorkedPointsError?.Value}\t");
                }
                Console.WriteLine();
            }
        }

    }
}