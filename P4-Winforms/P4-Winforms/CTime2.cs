using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Winforms
{
    public class CTime2 : Time2.Time2, IComparable<CTime2>
    {
        public CTime2() : base()
        {

        }
        public CTime2(int hour, int minute, int second) : base(hour, minute, second)
        {

        }
        public override string ToUniversalString()
        {
            return $"{((Hour == 0 || Hour == 12) ? 12 : Hour % 12)}   :   " + $"{Minute:D2}   :   {Second:D2} ";
        }


        public virtual int CompareTo(CTime2 other)
        {
            CTime2 ct2 = other;
            TimeSpan ts1 = new TimeSpan(this.Hour, this.Minute, this.Second);
            TimeSpan ts2 = new TimeSpan(ct2.Hour, ct2.Minute, ct2.Second);

            return ts1.CompareTo(ts2);
        }

        public override void AddTime(int minutes)
        {
            base.AddTime(minutes);
        }
    }
}
