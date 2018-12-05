using System;
using System.IO;
using System.Linq;

namespace Day_05___Alchemical_Reduction
{
    class Program
    {
        private static string Data = File.ReadAllLines(@"..\..\Day05_Data.txt").ToList().FirstOrDefault();

        static void Main(string[] args)
        {
            int shortestLength = int.MaxValue;
            for (int i = 97; i <= 122; i++)
            {
                var helperData = RemoveAllCharFromString((char)i, Data);
                var helperLength = ReduceString(helperData).Length;
                shortestLength = shortestLength < helperLength ? shortestLength : helperLength;
            }

            Console.WriteLine("Day 05 - Part 1: " + ReduceString(Data).Length);
            Console.WriteLine("Day 05 - Part 2: " + shortestLength);
            Console.ReadLine();
        }

        private static string ReduceString(string input)
        {
            var n = 0;
            while (n != input.Length)
            {
                n = input.Length;
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (Math.Abs((int)input[i] - (int)input[i + 1]) == 32)
                    {
                        input = input.Remove(i, 2);
                    }
                }
            }
            return input;
        }

        private static string RemoveAllCharFromString(char c, string input)
        {
            var n = 0;
            while (n != input.Length)
            {
                n = input.Length;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].Equals(c) || input[i].Equals((char)((int)c - 32)))
                    {
                        input = input.Remove(i, 1);
                    }
                }
            }
            return input;
        }
    }
}
