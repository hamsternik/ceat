using System.Collections.Generic;

namespace ceat.Sources.Models
{
    // TODO: Think about make `CausalRelationshipSet` implemeneted of {ICollection<T>, IEnumerable<T>, ICollection}
    public class CausalRelationshipPairsSet
    {
        public readonly HashSet<CausalRelationshipPair> PairsSet = new HashSet<CausalRelationshipPair>();

        public CausalRelationshipPairsSet(List<UnexplainedVarianceProportion> list) 
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    PairsSet.Add(list[i].RelatedPair(list[j]));
                }
            }
        }

        public void Add(CausalRelationshipPair pair) => PairsSet.Add(pair);

        public string[,] Matrix {
            get {
                string[,] CAEMatrix = new string[dataSource.RootDataDir.Directories.Count, dataSource.RootDataDir.Directories.Count];
                for (int i = 0; i < dataSource.RootDataDir.Directories.Count; i++)
                {
                    for (int j = 0; j < dataSource.RootDataDir.Directories.Count; j++)
                    {
                        if (i != j)
                        {
                            //var comparingResult = new AlgorithmService().CompareConcurencyModels(UVPMatrix[i, j], UVPMatrix[j, i]);
                            //CAEMatrix[i, j] = Convert.ToString(comparingResult.Item1);
                            //CAEMatrix[j, i] = Convert.ToString(comparingResult.Item2);

                        }
                        else
                        {
                            CAEMatrix[i, j] = "-";
                        }
                    }
                }
                return CAEMatrix;
            }
        }
    }
}
