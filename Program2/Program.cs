//1. The new methods for the original Time2 class is easier to write.
//2. Yes, the overloaded methods can either handle negative value as input.
//3. Handling negative require serious blocks of code to handle the negative number.
using System;
namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Time2.Time2(); // 00:00:00          
            var t2 = new Time2.Time2(2); // 02:00:00         
            var t3 = new Time2.Time2(-21, 34); // 21:34:00    
            var t4 = new Time2.Time2(12, -25, -42); // 12:25:42
            var t5 = new Time2.Time2(t4); // 12:25:42        

            Console.WriteLine("Constructed with:\n");
            Console.WriteLine("t1: all arguments defaulted");
            Console.WriteLine($"   {t1.ToUniversalString()}"); // 00:00:00
            Console.WriteLine($"   {t1.ToString()}\n"); // 12:00:00 AM

            Console.WriteLine(
                  "t2: hour specified; minute and second defaulted");
            Console.WriteLine($"   {t2.ToUniversalString()}"); // 02:00:00
            Console.WriteLine($"   {t2.ToString()}\n"); // 2:00:00 AM

            Console.WriteLine(
                   "t3: hour and minute specified; second defaulted");
            Console.WriteLine($"   {t3.ToUniversalString()}"); // 21:34:00
            Console.WriteLine($"   {t3.ToString()}\n"); // 9:34:00 PM

            Console.WriteLine("t4: hour, minute and second specified");
            Console.WriteLine($"   {t4.ToUniversalString()}"); // 12:25:42
            Console.WriteLine($"   {t4.ToString()}\n"); // 12:25:42 PM

            Console.WriteLine("t5: Time2 object t4 specified");
            Console.WriteLine($"   {t5.ToUniversalString()}"); // 12:25:42
            Console.WriteLine($"   {t5.ToString()}"); // 12:25:42 PM

            Console.WriteLine("Adding Time");
            try
            {
                t1.AddTime(12, 64, 77);
                t2.AddTime(12, 64, -77);
                t3.AddTime(12, 64, 77); //Will throw aa new outofrange exception
                t4.AddTime(12, 64, 77); //Will throw aa new outofrange exception
                t5.AddTime(12, 64, 77); //Will throw aa new outofrange exception
                var t6 = new Time2.Time2(27, 74, 99); // invalid values

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


            var t7 = new NewTime2.NewTime2(); // 00:00:00          
            var t8 = new NewTime2.NewTime2(4600);
            var t9 = new NewTime2.NewTime2(2186);
            var t10 = new NewTime2.NewTime2(1518);

            Console.WriteLine("\n\n----------\nConstructed with:\n");
            Console.WriteLine("t7: all arguments defaulted");
            Console.WriteLine($"   {t7.ToUniversalString()}"); // 00:00:00
            Console.WriteLine($"   {t7.ToString()}\n"); // 12:00:00 AM

            Console.WriteLine(
                "t8: hour specified; minute and second defaulted");
            Console.WriteLine($"   {t8.ToUniversalString()}");
            Console.WriteLine($"   {t8.ToString()}\n");

            Console.WriteLine(
                "t9: hour and minute specified; second defaulted");
            Console.WriteLine($"   {t9.ToUniversalString()}");
            Console.WriteLine($"   {t9.ToString()}\n");

            Console.WriteLine("t10: hour, minute and second specified");
            Console.WriteLine($"   {t10.ToUniversalString()}");
            Console.WriteLine($"   {t10.ToString()}\n");

            try
            {
                t7.AddTime(12, 64, 77);
                t8.AddTime(12, 64, 77);
                t9.AddTime(12, 64, 77);
                t10.AddTime(32, 64, 77); //Will throw aa new outofrange exception
                var t11 = new NewTime2.NewTime2(273285); // invalid values

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
