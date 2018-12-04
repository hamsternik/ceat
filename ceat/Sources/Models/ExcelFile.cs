using ExcelDataReader;
using System.Data;
using System.IO;

namespace ceat.Sources.Models
{
    public class ExcelFile : File
    {
        public readonly Directory ActualDirectory;

        public ExcelFile(string path, Directory actualDirectory) : base(path)
        {
            this.ActualDirectory = actualDirectory;
        }
        
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

		public string Title(bool isExtensionNeed = false)
		{
			return isExtensionNeed
				? System.IO.Path.GetFileName(Path)
				: System.IO.Path.GetFileNameWithoutExtension(Path);
		}
    }
}
