using System;

namespace NewTime2
{
    public class NewTime2
    {
        private int hour; // 0 - 23
        private int minute; // 0 - 59
        private int second; // 0 - 59

    
        public NewTime2(int second = 0)
        {
            int h = 0;
            int m = 0;
            int s = 0;
            if (second > 59)
            {
                if (second >= 3600)
                {
                    h = second / 3600;
                    second = second - h * 3600;
                    if (second > 59)
                    {
                        m = second / 60;
                        s = second % 60;
                    }
                    else
                    {
                        s = second;
                    }
                }
                else
                {
                    h = 0;
                    m = second / 60;
                    s = second % 60;
                }
            }
            else
            {
                s = second;
                m = 0;
                h = 0;
            }
            SetTime(h, m, s);
        }

        // set a new time value using universal time; invalid values
        // cause the properties' set accessors to throw exceptions
        public void SetTime(int hour, int minute, int second)
        {
            Hour = hour; // set the Hour property
            Minute = minute; // set the Minute property
            Second = second; // set the Second property
        }

        // property that gets and sets the hour
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                                                 value, $"{nameof(Hour)} must be 0-23");
                }

                hour = value;
            }
        }

        // property that gets and sets the minute
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(Minute)} must be 0-59");
                }

                minute = value;
            }
        }

        // property that gets and sets the second
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                      value, $"{nameof(Second)} must be 0-59");
                }

                second = value;
            }
        }

        // convert to string in universal-time format (HH:MM:SS)
        public string ToUniversalString() => $"{Second + Minute * 60 + Hour * 3600}";

        // convert to string in standard-time format (H:MM:SS AM or PM)
        //public override string ToString() => $"{Second + Minute * 60 + Hour * 3600} {(Hour < 12 ? "AM" : "PM")}";
        public override string ToString() => $"{((Hour == 0 || Hour == 12) ? 12 : Hour % 12)}:" + $"{Minute:D2}:{Second:D2} {(Hour < 12 ? "AM" : "PM")}";

        public void AddTime(int h, int m, int s)
        {
            int tempHour, tempMinute, tempSecond;
            tempHour = tempSecond = tempMinute = 0;
            if (s > 59)
            {
                tempMinute = s / 60;
                tempSecond = s - tempMinute * 60;

            }
            if (m > 59)
            {
                tempHour = m / 60;
                tempMinute += m - tempHour * 60;
            }

            tempHour += h;

            Hour += tempHour;
            Minute += tempMinute;
            Second += tempSecond;

            Console.WriteLine($"{Hour} : {Minute} : {Second}");
        }

        public void AddTime(NewTime2 time) => AddTime(time.Hour, time.Minute, time.Second);
    }
}

