using System;

namespace CSCI4315
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            bool flag = true;
            char opt;
            Console.Write("Pleae input the size of an array: "); //Take input from user

            do //promt user to input again if it's not an integer number
            {
                if (flag == false)
                {
                    Console.WriteLine("Input again!");
                }
                flag = int.TryParse(Console.ReadLine(), out size);
            } while (flag == false);

            Random rd = new Random(); //ini random object
            int[] array = new int[size]; //ini an integer array with size is import from user


            //Users have two options that are enter number by hand or use random obj to create random number for an array
            Console.Write("\nEnter number by hand? yes(Y/y) or no(N/n): ");
            char.TryParse(Console.ReadLine(), out opt);

            switch (opt)
            {
                case 'Y':
                case 'y':
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = int.Parse(Console.ReadLine());
                    }
                    break;
                case 'N':
                case 'n':
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = rd.Next(1, 100);
                    }
                    break;
                default:
                    break;
            }

            Console.WriteLine();
            ArrayHandler.PrintOut(array); // display an array of int to the screen

            Console.WriteLine();

            //used of ArrayHandler class
            Console.WriteLine($"Sum = {ArrayHandler.Sum(array)}");

            Console.WriteLine($"Average = {ArrayHandler.Average(array)}");

            Console.WriteLine($"The largest = {ArrayHandler.LargestNumber(array)}");

            Console.WriteLine($"The second largest = {ArrayHandler.SecondLargest(array)}");

            Console.WriteLine($"Standard deviation = {ArrayHandler.StandardDeviation(array)}");

            Console.WriteLine($"Variance = {ArrayHandler.Variance(array)}");

            Console.WriteLine($"Standard Error = {ArrayHandler.StandardError(array)}");

            Console.Write("\nEnter 1 for numbers that are bigger than the average, 2 for numbers that are smaller than average: ");
            int.TryParse(Console.ReadLine(), out int choice);

            if (choice == 1)
            {
                Console.WriteLine("-----The numbers that are bigger than the average-----");
                foreach (var i in ArrayHandler.BiggerOrSmallerThan(array))
                {
                    Console.Write($"{i}\t");
                }
            }
            else if(choice == 2){
                Console.WriteLine("-----The numbers that are smaller than the average-----");
                foreach (var i in ArrayHandler.BiggerOrSmallerThan(array, false))
                {
                    Console.Write($"{i}\t");
                }
            }
            else{
                Console.WriteLine("Check your input and try again");
            }
        }
    }
}
