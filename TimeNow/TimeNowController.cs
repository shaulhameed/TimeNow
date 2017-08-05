using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using TimeNow.Model;
using CoreGraphics;
using TimeNow.Helper;

namespace TimeNow
{
    public partial class TimeNowController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public TimeNowController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public TimeNowController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public TimeNowController() : base("TimeNow", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {


        }

        public override void ViewWillAppear()
        {

            this.generateView();
            base.ViewWillAppear();
        }

        #endregion

        //strongly typed view accessor
        public new TimeNow View
        {
            get
            {
                return (TimeNow)base.View;
            }
        }

        private void generateView()
        {



            this.generateInitialData().ForEach((value) =>
            {





                this.View.WantsLayer = true;

                this.View.Layer.BackgroundColor = NSColor.Clear.CGColor;

                var time = TimeZoneInfo.ConvertTime(DateTime.Now, value.timeZone);



                NSTextField title = new NSTextField(new CGRect(
                     (this.View.Frame.Size.Width / 2) - 50,
                        (this.View.Frame.Size.Height / 2) + 10,
                        100,
                        20
                ));

				title.Editable = false;

				title.Bordered = false;

				title.BackgroundColor = NSColor.Control;

                title.StringValue = "Time in Dallas";

                NSTextField dateAndTime = new NSTextField(
                    new CGRect(
                        (this.View.Frame.Size.Width / 2) - 100,
                        (this.View.Frame.Size.Height / 2) - 10,
                        200,
                        20)
                );

                dateAndTime.Editable = false;

                dateAndTime.Bordered = false;

                dateAndTime.BackgroundColor = NSColor.Control;


                dateAndTime.StringValue = string.Format("{0: hh:mm:ss tt} - {1: dd/MM/yyyy - ddd}", time, time);

                foreach (NSView view in this.View.Subviews.AsEnumerable())
                {
                    view.RemoveFromSuperview();
                }

                this.View.AddSubview(dateAndTime);

                this.View.AddSubview(title);


            });

        }


        private List<DateModel> generateInitialData()
        {

            List<DateModel> times = new List<DateModel>();

            var timeZones = new DateTimeHelper().getTimeZoneAsArray();


            var value = from zone in timeZones
                        where zone.BaseUtcOffset.Hours == -6
                        select zone;

            times.Add(
                   new DateModel()
                   {
                       timeZone = value.First()
                   });





            return times;
        }
    }
}
