using System;
using AppKit;
using Foundation;

namespace TimeNow.Helper
{
    public sealed class MenuBarHelper : NSObject
    {
        // Singleton method
        private static readonly MenuBarHelper _sharedInstance = new MenuBarHelper();

        private NSStatusBar statusBar;

        private NSStatusItem menuItem;

        private NSPopover popOver;
        static MenuBarHelper()
        {

        }

        private MenuBarHelper()
        {
            this.popOver = new NSPopover();

            this.statusBar = NSStatusBar.SystemStatusBar;
            this.menuItem = this.statusBar
                .CreateStatusItem(NSStatusItemLength.Variable);
        }

        public static MenuBarHelper sharedInstance
        {
            get
            {
                return _sharedInstance;
            }
        }


        public void generate()
        {

            // Configure the menu

            this.menuItem.Title = "Time Now";
            this.menuItem.Target = this;

            this.menuItem.Action = new ObjCRuntime.Selector("onMenuClick");

            this.popOver.ContentViewController = new TimeNowController();



        }


        [Export("onMenuClick")]
        private void onMenuClick()
        {


            if(this.popOver.Shown){
                this.popOver.PerformClose(this);
            }
            else {
				var button = this.menuItem.Button;
				this.popOver.Show(button.Bounds, button, NSRectEdge.MinYEdge);
            }

           


        }


    }
}
