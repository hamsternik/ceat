using System.Text.RegularExpressions;

namespace ceat.Sources.Models
{
    public class InputParameter
    {
        public readonly string StringValue;

        public InputParameter(string stringValue)
        {
            this.StringValue = stringValue;
        }

        public int IntegerValue
        {
            get
            {
                var regex = new Regex(@"\d+");
                var matches = regex.Matches(StringValue);
                return int.Parse(matches[0].Value);
            }
        }
    }
}
