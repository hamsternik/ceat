using System;

namespace ceat.Sources.Models
{
    public class ParametersComparingModel
    {
        public readonly ParametersModel FirstArgFromSecond;
        public readonly ParametersModel SecondArgFromFirst;
        public readonly string SummarizingText;

        public ParametersComparingModel(
            ParametersModel firstArgFromSecond, 
            ParametersModel secondArgFromFirst, 
            string summarizingText
        )
        {
            this.FirstArgFromSecond = firstArgFromSecond;
            this.SecondArgFromFirst = secondArgFromFirst;
            this.SummarizingText = summarizingText;
        }
    }
}
