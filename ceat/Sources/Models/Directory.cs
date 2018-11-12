using Foundation;
using System.Collections.Generic;

using ceat.Sources.Services;

namespace ceat.Sources.Models
{
    public class Directory : File
    {
        private readonly FileManagerWrapper FileManager;

        public Directory(string path, FileManagerWrapper fileManager) : base(path) 
        {
            this.FileManager = fileManager;
        }

        public string Title => System.IO.Path.GetFileName(Path);

        public List<ExcelFile> ExcelFiles 
        {
            get 
            {
                var contents = FileManager.DirectoryContent(Path, out NSError fileManagerError);
                var excelFiles = new List<ExcelFile>();
                if (fileManagerError == null)
                {
                    foreach (var pathComponent in contents)
                    {
                        var filepath = new NSUrl(Path).Append(pathComponent, true).Path;
                        if (FileManager.IsExcelFile(filepath))
                            excelFiles.Add( new ExcelFile(filepath, this) );
                    }
                }
                return excelFiles;
            }
        }

        public List<string> ExcelFileTitles(bool isExtensionNeed = false)
        {
            var fileTitles = new List<string>();
            ExcelFiles.ForEach(file => fileTitles.Add( file.Title(isExtensionNeed) ));
            return fileTitles;
        }
    }
}
