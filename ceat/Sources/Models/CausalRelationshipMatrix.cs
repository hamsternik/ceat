using System;
using System.Linq;

using ceat.Sources.Services;

namespace ceat.Sources.Models
{
    public class CausalRelationshipMatrix
    {
		public static class C
		{
			public static string DefaultComparingResultItem => "-";
		}

		public readonly string[,] Value;

		public (int Rows, int Columns) Dimension => ((int)Value.GetLength(0), (int)Value.GetLength(1));

		public string this[int row, int column] => this.Value[row, column];

		public CausalRelationshipMatrix(UnexplainedVarianceProportionMatrix matrix, AlgorithmService algorithms)
        {
        	matrix.Print();
			Console.WriteLine("-- calculate CausalRelationshipMatrix --");
        	
        	this.Value = new string[matrix.Dimension.Rows, matrix.Dimension.Columns];
            for (int i = 0; i < matrix.Dimension.Rows; i++)
            {
                for (int j = 0; j < matrix.Dimension.Columns; j++)
                {
                    if (i != j)
                    {
						Console.WriteLine($"x[{i+1},{j+1}] == {matrix[i, j].WorkedPointsError.Value}, x[{j+1},{i+1}] == {matrix[j, i].WorkedPointsError.Value}");
                        var comparingResult = algorithms.CompareConcurencyModels(
                            matrix[i, j].WorkedPointsError.Value,
                            matrix[j, i].WorkedPointsError.Value
                        );
                        this.Value[i, j] = Convert.ToString(comparingResult.Item1);
                        this.Value[j, i] = Convert.ToString(comparingResult.Item2);
                    }
                    else
                    {
                        this.Value[i, j] = C.DefaultComparingResultItem;
                    }
                }
            }
        }

		public string[] RowByIndex(int rowIndex)
		{
			return Enumerable.Range(0, Dimension.Columns)
				.Select(columnIndex => this.Value[rowIndex, columnIndex])
				.ToArray();
		}

		public string[] ColumnByIndex(int columnIndex)
		{
			return Enumerable.Range(0, Dimension.Rows)
				.Select(rowIndex => this.Value[rowIndex, columnIndex])
				.ToArray();
		}

		public void Print()
        {
            Console.WriteLine("-=== Causal Relationship Matrix ===-");
            for (int i = 0; i < Value.GetLength(0); i++)
            {
                for (int j = 0; j < Value.GetLength(1); j++)
                {
                    Console.Write($"{Value[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
