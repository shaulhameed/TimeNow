using System;
using System.Collections.Generic;

namespace TimeNow.Helper
{
    public class DateTimeHelper
    {

        public IReadOnlyCollection<TimeZoneInfo> timeZones;
        public DateTimeHelper()
        {
            this.timeZones = TimeZoneInfo.GetSystemTimeZones();
        
        }

        public List<TimeZoneInfo> getTimeZoneAsArray(){

            List<TimeZoneInfo> zones = new List<TimeZoneInfo>();

            foreach (TimeZoneInfo zone in this.timeZones){

                zones.Add(zone);

            }

            return zones;

        }



    }
}
