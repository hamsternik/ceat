using System;

namespace ceat.Sources.Models
{
    public class UnexplainedVarianceProportionMatrix
    {
        public readonly UnexplainedVarianceProportion[,] Value;

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
                            element => (element.Ouput.IntegerValue - 1) == i && (element.Input.IntegerValue - 1) == j
                        );
                    }
                    else
                    {
                        this.Value[i, j] = null;
                    }
                }
            }
        }

        public nint Rows => Value.GetLength(0);
        public nint Columns => Value.GetLength(1);

        public UnexplainedVarianceProportion this[int row, int column] => this.Value[row, column];

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