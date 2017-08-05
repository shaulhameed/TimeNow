using System;
using AppKit;
using Foundation;
using TimeNow.Helper;

namespace TimeNow
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        


        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {

            // need to revist this.
            //mainWindowController = new MainWindowController();
            ////mainWindowController.Window.MakeKeyAndOrderFront(this);

            // this generates the menu bar.
            MenuBarHelper.sharedInstance.generate();


		}

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }





    }
}
