using System.Text;
using System.Text.RegularExpressions;

namespace ceat.Sources.Models
{
    public class OutputParameter
    {
        public readonly string StringValue;

        public OutputParameter(string stringValue)
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
