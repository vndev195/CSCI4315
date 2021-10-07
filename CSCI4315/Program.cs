using System;

namespace CSCI4315
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int[] array = new int[10];

            for(int i = 0; i < array.Length; i++){
                array[i]= rd.Next(1,100);
            }

            //display int array
            for(int i = 0; i < array.Length; i++){
                Console.Write(array[i]+ "\t");
            }
            Console.WriteLine();
            int sum = ArrayHandler.Sum(array);
            Console.WriteLine($"Sum = {sum}");

            double avg = ArrayHandler.Average(sum, array.Length);
            Console.WriteLine($"Average = {avg}");

            int theLargest = ArrayHandler.LargestNumber(array);
            Console.WriteLine($"The largest = {theLargest}");

            int theSecondLargest = ArrayHandler.SecondLargest(array);
            Console.WriteLine($"The second largest = {theSecondLargest}");

            ArrayHandler.StandardDeviation(array);
        }
    }
}
