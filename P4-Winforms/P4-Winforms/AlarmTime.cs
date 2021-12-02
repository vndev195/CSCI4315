using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Winforms
{
    public class AlarmTime : CTime2
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private CTime2 _snoozeTime;

        public CTime2 SnoozeTime
        {
            get { return _snoozeTime; }
            set { _snoozeTime = value; }
        }

        public AlarmTime(string _message, int hours, int minutes, int seconds) : base(hours, minutes, seconds)
        {
            Message = _message;
            SnoozeTime = null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public override int CompareTo(CTime2 other)
        {
            return base.CompareTo(other);
        }
    }
}
