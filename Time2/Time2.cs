using System;

namespace Time2
{
    public class Time2
    {
        private int _hour;

        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 24)
                {

                    _hour = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"The value of hour should be between 0-23");
                }
            }
        }
        private int _minute;

        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 60)
                {

                    _minute = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"The value of minute should be between 0-59");
                }
            }
        }

        private int _second;

        public int Second
        {
            get { return _second; }
            set
            {
                if (value < 60)
                {

                    _second = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"The value of second should be between 0-59");
                }
            }
        }

        public Time2()
        {

        }

        public Time2(int hour, int minute, int second)
        {
            //call a SetTIme method
            //throw an outofrangeexception when the values are out of range
            SetTime(hour, minute, second);
        }

        public Time2(int hour)
        {
            Hour = hour;
        }

        public Time2(int hour, int minute) : this(hour)
        {
            Minute = minute;
        }
        public Time2(Time2 time) : this(time._hour, time._minute, time._second)
        {

        }

        //Set time
        public void SetTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public virtual string ToUniversalString() => $"{Hour:D2} : {Minute:D2} : {Second:D2}";

        public override string ToString() => $"{((Hour == 0 || Hour == 12) ? 12 : Hour % 12)}:" + $"{Minute:D2}:{Second:D2} {(Hour < 12 ? "AM" : "PM")}";

        //12 : 45 : 505
        public void AddTime(int h, int m, int s)
        {
            int tempHour, tempMinute, tempSecond;
            tempHour = Hour;
            tempMinute = Minute;
            tempSecond = Second;

            tempSecond += s;
            if (tempSecond < 0)
            {
                tempSecond = tempSecond + 60;
                tempMinute--;
            }
            tempMinute += m;
            if (tempMinute < 0)
            {
                tempMinute = tempMinute + 60;
                tempHour--;
            }
            tempHour += h;
            if(tempHour < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tempHour), $"The value of hour should be between 0-23");
            }
            Hour = tempHour;
            Minute = tempMinute;
            Second = tempSecond;

            Console.WriteLine($"{Hour} : {Minute} : {Second}");
        }

        public void AddTime(Time2 time) => AddTime(time.Hour, time.Minute, time.Second);
    }
}
