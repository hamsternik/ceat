using Foundation;

namespace ceat.Sources.Models
{
    public abstract class File : NSObject
    {
        public readonly string Path;

        protected File(string path)
        {
            this.Path = path;
        }
    }
}
