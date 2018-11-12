using ExcelDataReader;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace ceat.Sources.Models
{
    public class ExcelFile : File
    {
        public readonly Directory ActualDirectory;

        public ExcelFile(string path, Directory actualDirectory) : base(path)
        {
            this.ActualDirectory = actualDirectory;
        }

        public string Title(bool isExtensionNeed = false)
        {
            return isExtensionNeed
                ? System.IO.Path.GetFileName(Path)
                : System.IO.Path.GetFileNameWithoutExtension(Path);
        }

        public List<string> InputParameters
        {
            get
            {
                var inputParameters = new List<string>();
                foreach (Match param in Parameters)
                {
                    inputParameters.Add(param.Value);
                }
                return inputParameters.Skip(1).ToList();
            }
        }

        public string OutputParameter => Parameters[0].Value;

        public DataTable ActiveSheet
        {
            get
            {
                DataTable activeSheet;
                using (FileStream stream = System.IO.File.Open(Path, FileMode.Open))
                {
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    activeSheet = excelReader.AsDataSet().Tables[0];
                }

                return activeSheet;
            }
        }

        private MatchCollection Parameters => new Regex(@"x\d+").Matches(Title());
    }
}
