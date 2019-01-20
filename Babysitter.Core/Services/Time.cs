using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Services
{
    class Time
    {
        public Int32 Hours { get; private set; }
        public Int32 Minutes { get; private set; }
        public Int32 Seconds { get; private set; }

        public Time(Int32 h, Int32 m, Int32 s)
        {
            if (h > 23 || m > 59 || s > 59)
            {
                throw new ArgumentException("Invalid time specified");
            }
            Hours = h;
            Minutes =m;
            Seconds =s;
        }

        public Time(DateTime dt)
        {
            Hours = dt.Hour;
            Minutes = dt.Minute;
            Seconds = dt.Second;
        }

        public override string ToString()
        {
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }

        public void AddHours(Int32 h)
        {
            this.Hours += h;
        }

        public void AddMinutes(Int32 m)
        {
            this.Minutes += m;
            while (this.Minutes > 59)
            {
                this.Minutes -= 60;
                this.AddHours(1);
            }
        }

        public void AddSeconds(Int32 s)
        {
            this.Seconds += s;
            while (this.Seconds > 59)
            {
                this.Seconds -= 60;
                this.AddMinutes(1);
            }
        }
    }
}
