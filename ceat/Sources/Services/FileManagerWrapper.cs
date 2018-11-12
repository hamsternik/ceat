using Foundation;

namespace ceat.Sources.Services
{
    public class FileManagerWrapper
    {
        private NSFileManager FileManager;
        private readonly string[] ExcelFileTypes = new string[] { ".xls", ".xlsx" };

        public FileManagerWrapper(NSFileManager fileManager)
        {
            this.FileManager = fileManager;
        }

        public string[] DirectoryContent(string path, out NSError error, bool recursively = false)
        {
            return !recursively
                ? FileManager.GetDirectoryContent(path, out error)
                : FileManager.GetDirectoryContentRecursive(path, out error);
        }


        public bool IsDirectory(string path)
        {
            var fileAttributes = System.IO.File.GetAttributes(path);
            return (fileAttributes & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory;
        }

        public bool IsExcelFile(string path)
        {
            var fileExtension = System.IO.Path.GetExtension(path);
            foreach (var excelFileType in ExcelFileTypes) {
                if (fileExtension == excelFileType) return true;
            }
            return false;
        }
    }
}
