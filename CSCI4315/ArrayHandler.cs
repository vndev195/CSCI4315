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
            return sum/length;
        }

        public static double Average(int[] _array){
            int sum = 0;
            foreach(var i in _array){
                sum += i;
            }
            return sum/_array.Length;
        }

        public static int Sum(int[] _array)
        {
            int sum = 0;
            foreach(var i in _array){
                sum += i;
            }

            return sum;
        }

        public static int LargestNumber(int[] _array){
            int largest = (from i in _array orderby i descending select i).FirstOrDefault();

            // foreach(var i in largest){
            //     Console.Write($"{i}\t");
            // }
            // Console.WriteLine();
            //Console.WriteLine($"The largest number is {largest}");

            return largest;
        }

        public static int SecondLargest(int[] _array){
            int secondLargest = (from i in _array orderby i descending select i).ElementAtOrDefault(1);

            return secondLargest;
        }

        public static double StandardDeviation(int[] _array){
            double standardDeviation = 0;
            double sampleMean = ((int)_array.Average()) / _array.Length;

            double t = 0;
            foreach(int i in _array){
                t += Math.Pow(i - sampleMean,2);
            }
            standardDeviation = Math.Sqrt(t/(_array.Length -1));
            Console.WriteLine($"sample mean: {sampleMean} and \nstandard deviation: {standardDeviation}");

            return 0;
        }
    }
}
