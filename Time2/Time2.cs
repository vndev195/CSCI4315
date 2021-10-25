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
                if (value < 0 || value > 23)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The value of hour should be between 0-23");
                _hour = value;
            }
        }
        private int _minute;

        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The value of minute should be between 0-59");
                _minute = value;
            }
        }

        private int _second;

        public int Second
        {
            get { return _second; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The value of second should be between 0-59");
                _second = value;
            }
        }

        public Time2(int hour, int minute, int second)
        {
            //call a SetTIme method
            //throw an outofrangeexception when the values are out of range
            SetTime(hour, minute, second);
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

        public string ToUniversalString() => $"{Hour:D2} : {Minute:D2} : {Second:D2}";

        public override string ToString() => $"{((Hour == 0 || Hour == 12) ? 12 : Hour % 12)}:" + $"{Minute:D2}:{Second:D2} {(Hour < 12 ? "AM" : "PM")}";
    }
}
