using AppKit;
using Foundation;

namespace ceat
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
		public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
		{
			return true;
		}

		public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }
    }
}
