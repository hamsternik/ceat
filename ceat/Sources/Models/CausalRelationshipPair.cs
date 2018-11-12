using System;

namespace ceat.Sources.Models
{
    public class CausalRelationshipPair
    {
        public readonly UnexplainedVarianceProportion UVPLeft;
        public readonly UnexplainedVarianceProportion UVPRight;

        public CausalRelationshipPair(UnexplainedVarianceProportion left, UnexplainedVarianceProportion right)
        {
            this.UVPLeft = left;
            this.UVPRight = right;
        }

        // TODO: Maybe `Tuple<int, int>` isn't the best result Type to return, think about custom class.
        public Tuple<int, int> Value(double indicativeErrorThreshold = 0.8, double reliabilityIndexThreshold = 0.15)
        {
            Tuple<int, int> result = new Tuple<int, int>(int.MinValue, int.MinValue);
            double reliabilityIndex = Math.Abs(UVPLeft.WorkedPointsError.Value - UVPRight.WorkedPointsError.Value);
            double indicativeErrorMin = Math.Min(UVPLeft.WorkedPointsError.Value, UVPRight.WorkedPointsError.Value);

            if (reliabilityIndex >= reliabilityIndexThreshold)
            {
                if (indicativeErrorMin > indicativeErrorThreshold)
                {
                    result = new Tuple<int, int>(-1, -1);
                }
                else
                {
                    if (indicativeErrorMin.Equals(UVPLeft.WorkedPointsError.Value))
                    {
                        result = new Tuple<int, int>(1, 0);
                    }
                    else if (indicativeErrorMin.Equals(UVPRight.WorkedPointsError.Value))
                    {
                        result = new Tuple<int, int>(0, 1);
                    }
                }
            }
            else if (reliabilityIndex < reliabilityIndexThreshold)
            {
                if (indicativeErrorMin > indicativeErrorThreshold)
                {
                    result = new Tuple<int, int>(0, 0);
                }
                else if (indicativeErrorMin <= indicativeErrorThreshold)
                {
                    result = new Tuple<int, int>(1, 1);
                }
            }

            return result;
        }
    }
}
