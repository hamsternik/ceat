using System;
using ceat.Sources.Services;

namespace ceat.Sources.Models
{
    public class CausalRelationshipMatrix
    {
        public readonly string[,] Value;

        public CausalRelationshipMatrix(UnexplainedVarianceProportionMatrix matrix, AlgorithmService algoService)
        {
            this.Value = new string[matrix.Rows, matrix.Columns];
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (i != j)
                    {
                        var comparingResult = algoService.CompareConcurencyModels(
                            matrix[i, j].WorkedPointsError.Value,
                            matrix[j, i].WorkedPointsError.Value
                        );
                        this.Value[i, j] = Convert.ToString(comparingResult.Item1);
                        this.Value[j, i] = Convert.ToString(comparingResult.Item2);
                    }
                    else
                    {
                        this.Value[i, j] = "-";
                    }
                }
            }
        }

        public string this[int row, int column] => this.Value[row, column];

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
