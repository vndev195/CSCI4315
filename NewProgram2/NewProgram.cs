//1. Both new methods for the original Time2 class and the new Time2 class. They use the same implementation.
//2. Yes, the overloaded methods can either handle negative value as input.
using System;

namespace NewProgram2
{
    class NewProgram
    {
        static void Main(string[] args)
        {
            var t1 = new NewTime2.NewTime2(); // 00:00:00          
            var t2 = new NewTime2.NewTime2(4600); // 02:00:00         
            var t3 = new NewTime2.NewTime2(2186); // 21:34:00    
            var t4 = new NewTime2.NewTime2(1518); // 12:25:42
            //var t5 = new NewTime2.NewTime2(t4); // 12:25:42        

            Console.WriteLine("Constructed with:\n");
            Console.WriteLine("t1: all arguments defaulted");
            //Console.WriteLine($"   {t1.ToUniversalString()}"); // 00:00:00
            Console.WriteLine($"   {t1.ToString()}\n"); // 12:00:00 AM

            Console.WriteLine(
                "t2: hour specified; minute and second defaulted");
            //Console.WriteLine($"   {t2.ToUniversalString()}"); // 02:00:00
            Console.WriteLine($"   {t2.ToString()}\n"); // 2:00:00 AM

            Console.WriteLine(
                "t3: hour and minute specified; second defaulted");
            //Console.WriteLine($"   {t3.ToUniversalString()}"); // 21:34:00
            Console.WriteLine($"   {t3.ToString()}\n"); // 9:34:00 PM

            Console.WriteLine("t4: hour, minute and second specified");
            //Console.WriteLine($"   {t4.ToUniversalString()}"); // 12:25:42
            Console.WriteLine($"   {t4.ToString()}\n"); // 12:25:42 PM

            //Console.WriteLine("t5: Time2 object t4 specified");
            //Console.WriteLine($"   {t5.ToUniversalString()}"); // 12:25:42
            //Console.WriteLine($"   {t5.ToString()}"); // 12:25:42 PM


            // attempt to initialize t6 with invalid values and adding new time for t1,t2,t3,t4,t5
            try
            {
                t1.AddTime(12, 64, 77);
                t2.AddTime(12, 64, 77);
                t3.AddTime(12, 64, 77); 
                t4.AddTime(32, 64, 77); //Will throw aa new outofrange exception
                //t5.AddTime(12, 64, 77); //Will throw aa new outofrange exception
                var t6 = new NewTime2.NewTime2(273285); // invalid values

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
