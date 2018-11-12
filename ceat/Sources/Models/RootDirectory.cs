using Foundation;
using System.Collections.Generic;

using ceat.Sources.Services;

namespace ceat.Sources.Models
{
    public class RootDirectory : File
    {
        private readonly FileManagerWrapper FileManager;

        public RootDirectory(string path, FileManagerWrapper fileManager) : base(path)
        {
            this.FileManager = fileManager;
        }

        public List<Directory> Directories 
        {
            get 
            {
                var contents = FileManager.DirectoryContent(Path, out NSError fileManagerError);
                var directories = new List<Directory>();
                if (fileManagerError == null)
                {
                    foreach (var pathComponent in contents)
                    {
                        var filepath = new NSUrl(Path).Append(pathComponent, true).Path;
                        if (FileManager.IsDirectory(filepath))
                            directories.Add(new Directory(filepath, FileManager));
                    }
                }
                return directories;
            }
        }

        public List<string> DirectoryTitles
        {
            get
            {
                var directoryTitles = new List<string>();
                Directories.ForEach(dir => directoryTitles.Add(dir.Title));
                return directoryTitles;
            }
        }
    }
}