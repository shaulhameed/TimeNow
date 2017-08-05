using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace TimeNow
{
    public partial class TimeNow : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public TimeNow(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public TimeNow(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
            
        }

        #endregion
    }
}
