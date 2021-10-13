using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CSCI4315
{
    public static class ArrayHandler
    {
        public static double Average(int sum, int length)
        {
            return sum / length;
        }

        public static double Average(int[] _array)
        {
            return _array.Average();
        }

        public static int Sum(int[] _array)
        {
            int sum = 0;
            foreach (var i in _array)
            {
                sum += i;
            }

            return sum;
        }

        public static int LargestNumber(int[] _array)
        {
            int largest = (from i in _array orderby i descending select i).FirstOrDefault();

            // foreach(var i in largest){
            //     Console.Write($"{i}\t");
            // }
            // Console.WriteLine();
            //Console.WriteLine($"The largest number is {largest}");

            return largest;
        }

        public static int SecondLargest(int[] _array)
        {
            int secondLargest = (from i in _array orderby i descending select i).ElementAtOrDefault(1);

            return secondLargest;
        }

        public static double StandardDeviation(int[] _array)
        {
            double standardDeviation = 0;
            double sampleMean = Math.Round(_array.Average(), 0);

            double t = 0;
            foreach (var i in _array)
            {
                t += Math.Pow(i - sampleMean, 2);
            }

            standardDeviation = Math.Sqrt(t / (_array.Length - 1));
            //Console.WriteLine($"length: {_array.Length}\nsample mean: {sampleMean} and \nstandard deviation: {standardDeviation}");

            return Math.Round(standardDeviation,2);
        }

        public static double Variance(int[] _array)
        {
            double standardDeviation = ArrayHandler.StandardDeviation(_array);
            return Math.Round(Math.Pow(standardDeviation, 2),2);
        }

        public static double StandardError(int[] _array)
        {
            double standardDeviation = ArrayHandler.StandardDeviation(_array);
            return Math.Round(standardDeviation / Math.Sqrt(_array.Length),2);
        }

        public static void PrintOut(int[] _array)
        {
            Console.WriteLine("-----Array-----");

            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write(_array[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("---------------");
        }

        public static IEnumerable<int> BiggerOrSmallerThan(int[] _array, bool bigger = true)
        {

            int avg = (int)Math.Round(_array.Average(), 0);
            if (bigger)
            {
                return _array.Where(x => x >= avg).Select(x => x);
            }
            else
            {
                return _array.Where(x => x <= avg).Select(x => x);
            }
        }
    }
}
