using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_2_3_C__
{
    internal class Time
    {
        private byte hours, minutes;

        public byte HOURS { get { return hours; } set { hours = value; } }
        public byte MINUTES { get { return minutes; } set { minutes = value; } }

        public Time()
        {
            this.hours = 0;
            this.minutes = 0;
        }

        public Time(byte hours, byte minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }

        public Time minus(Time time2)
        {
            byte minutes = 0, hours = 0;
            if (this.minutes < time2.minutes && this.hours > 0)
            {
                minutes = 60;
                minutes += this.minutes;
                minutes -= time2.minutes;
                hours = this.hours;
                hours--;
            }
            else if (this.minutes < time2.minutes && this.hours == 0)
            {
                hours = 23;
                minutes = 60;
                minutes += this.minutes;
                minutes -= time2.minutes;
            }
            else
            {
                minutes = this.minutes;
                minutes -= time2.minutes;
                hours = this.hours;
            }
            if (hours >= time2.hours)
            {
                hours -= time2.hours;
            }
            else
            {
                hours += 24;
                hours -= time2.hours;
            }
            return new Time(hours, minutes);
        }
        public override string ToString() //перегрузка оператора
        {
            string hours, minutes;
            if (this.hours < 10)
            {
                hours = "0" + this.hours;
            }
            else
                hours = Convert.ToString(this.hours);
            if (this.minutes < 10)
            {
                minutes = "0" + this.minutes;
            }
            else
                minutes = Convert.ToString(this.minutes);
            return hours + ":" + minutes;
        }

        public static Time operator ++(Time time)
        {
            if (time.minutes == 59)
            {
                time.minutes = 0;
                if (time.hours == 23)
                    time.hours = 0;
                else
                    time.hours++;
            }
            else
                time.minutes++;
            return time;
        }
        public static Time operator --(Time time)
        {
            if (time.minutes == 0)
            {
                if (time.hours > 0)
                    time.hours--;
                else
                    time.hours = 23;
                time.minutes = 59;
            }
            else
                time.minutes--;
            return time;
        }

        public static implicit operator int(Time time)
        {
            return time.minutes + time.hours * 60;
        }

        public static explicit operator bool(Time time)
        {
            if (time.hours == 0 && time.minutes == 0)
                return false;
            else
                return true;
        }

        public static bool operator >(Time time1, Time time2)
        {
            if (0 + time1 > 0 + time2)
                return true;
            else
                return false;
        }

        public static bool operator <(Time time1, Time time2)
        {
            if (0 + time1 < 0 + time2)
                return true;
            else
                return false;
        }
    }
}
