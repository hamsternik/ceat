using System;

namespace ceat.Sources.Services
{
	public class AlgorithmService
	{
        // TODO: Get treshold values from the UI
        public double IndicativeErrorThreshold;
        public double ReliabilityIndexThreshold;

		public AlgorithmService(double indicativeErrorThreshold = 0.9, double reliabilityIndexThreshold = 0.01)
		{
			IndicativeErrorThreshold = indicativeErrorThreshold;
			ReliabilityIndexThreshold = reliabilityIndexThreshold;
		}

		/**
		 * @param X_i1_model: Model value for the model error.
		 * @param X_i2: All values of the parameter on which the model error depends.
		 * TODO: add @param name="Xi2" 
		 */
		public double CalculateUnexplainedVarianceProportion(double[] Xi1Model, double[] Xi2, double Xi1Average)
		{
			if (Xi1Model.Length != Xi2.Length)
				return double.Epsilon;
			
			double numerator = 0.0;
			double denominator = 0.0;
			for (int i = 0; i < Xi1Model.Length; i++) 
			{
				double numer = Xi2[i] - Xi1Model[i];
				double denom = Xi2[i] - Xi1Average;
				numerator += Math.Pow(numer, 2);
				denominator += Math.Pow(denom, 2);
			}

			/* Result: Model error value */
			double result = Math.Sqrt(numerator / denominator);
			return result;
		}

		/**
		 * uvp == Unexplained Variance Proportion
		 * @param X_i1_model: x_i1 comparable uvp value.
		 * @param X_i2_model: x_i2 comparable uvp value.
		 * @return result: The tuple value for each pair of variables.
		 */
        // Compare
		public Tuple<int, int> CompareConcurencyModels(double X_i1_uvp, double X_i2_uvp)
		{
			Tuple<int, int> result = new Tuple<int, int>(int.MinValue, int.MinValue);
			double indicativeErrorMin = Math.Min(X_i1_uvp, X_i2_uvp);
			double reliabilityIndex = Math.Abs(X_i1_uvp - X_i2_uvp);

			if (reliabilityIndex >= ReliabilityIndexThreshold)
			{
				if (indicativeErrorMin > IndicativeErrorThreshold) 
				{
					result = new Tuple<int, int>(-1, -1);
				} 
				else 
				{
					if (indicativeErrorMin.Equals(X_i1_uvp))
					{
						//result = new Tuple<int, int>(1, 0);
						//FIXME: Change input database param titles
						result = new Tuple<int, int>(0, 1);
					} 
					else if (indicativeErrorMin.Equals(X_i2_uvp)) 
					{
						//result =  new Tuple<int, int>(0, 1);
						//FIXME: Change input database param titles
						result = new Tuple<int, int>(1, 0);
					}
				}
			} 
			else if (reliabilityIndex < ReliabilityIndexThreshold) 
			{
				if (indicativeErrorMin > IndicativeErrorThreshold)
				{
					result = new Tuple<int, int>(0, 0);
				}
				else if (indicativeErrorMin <= IndicativeErrorThreshold)
				{
					result = new Tuple<int, int>(1, 1);
				}
			}

			return result;
		}

		public string MatchParametersRelationship(string xOut_i, string xOut_j, string directionFromItoJStr, string directionFromJtoIStr)
		{
			string result = "";

			// FIXME: Shoud use with `try-catch`
			int directionFromItoJ = int.Parse(directionFromItoJStr);
			int directionFromJtoI = int.Parse(directionFromJtoIStr);

			if (directionFromItoJ == -1 && directionFromJtoI == -1) {
				result = $"Взаимосвязь между {xOut_i} и {xOut_j} не установленна.";
			} else if (directionFromItoJ == 1 && directionFromJtoI == 0) {
				result = $"Параметер {xOut_j} зависит от параметра {xOut_i}.";
			} else if (directionFromItoJ == 0 && directionFromJtoI == 1) {
				result = $"Параметер {xOut_i} зависит от параметра {xOut_j}.";
			} else if (directionFromItoJ == 1 && directionFromJtoI == 1) {
				result = $"Двухстороннняя связь между {xOut_i} и {xOut_j}.";
			} else if (directionFromItoJ == 0 && directionFromJtoI == 0) {
				result = $"Переменные {xOut_i} и {xOut_j} не взаимосвязанны.";
			}

			return result;
		}

		#region Static Methods

		public static double Mean(double[] vec)
		{
			double result = 0.0;
			for(int i = 0; i < vec.Length; i++)
				result += vec[i];
			result = result / vec.Length;
			return result;
		}

		#endregion
	}
}
