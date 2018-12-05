using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_10___Knot_Hash
{
    class Program
    {
        private static List<int> Rope = Enumerable.Range(0, 256).ToList();
        private static List<int> Lengths = new List<int>();
        private static List<int> NewLengths = new List<int>();
        private static int CurrentPosition = 0, SkipSize = 0;

        static void Main(string[] args)
        {
            List<string> lengths = File.ReadAllLines(@"..\..\Day10_Data.txt").ToList();
            lengths.ForEach(x =>
            {
                foreach (var c in x)
                    NewLengths.Add(c);
                NewLengths.AddRange(new List<int> { 17, 31, 73, 47, 23 });
                foreach (var length in x.Split(','))
                    Lengths.Add(int.Parse(length.Trim()));
            });

            Lengths.ForEach(x => DoKnotHash(x));

            Console.WriteLine("Day 10 - Part 1: " + (Rope[0] * Rope[1]));
            Console.Write("Day 10 - Part 2: ");

            Rope = Enumerable.Range(0, 256).ToList();
            CurrentPosition = 0;
            SkipSize = 0;
           
            for (int j = 0; j < 64; j++)
            {
                NewLengths.ForEach(x => DoKnotHash(x));
            }

            var hexList = new List<string>();
            for (int i = 0; i < 16; i++)
            {
                var xorValues = new List<int>();
                for (int j = i * 16; j < (i + 1) * 16; j++)
                    xorValues.Add(Rope[j]);
                hexList.Add(xorValues.Aggregate((l, r) => l ^ r).ToString("x2"));
            }
            hexList.ForEach(x => Console.Write(x));
            Console.ReadLine();
        }

        private static void DoKnotHash(int length)
        {
            var helperList = new List<int>();
            for (int i = CurrentPosition; i < CurrentPosition + length; i++)
            {
                if (i >= Rope.Count)
                    helperList.Add(Rope[i - Rope.Count]);
                else
                    helperList.Add(Rope[i]);
            }
            var helperPosition = 1;
            var endPostion = CurrentPosition + length;
            while (CurrentPosition != endPostion)
            {
                if (CurrentPosition == Rope.Count)
                {
                    CurrentPosition = 0;
                    endPostion -= Rope.Count;
                }
                if (helperPosition > helperList.Count)
                    helperPosition = 1;
                Rope[CurrentPosition] = helperList[helperList.Count - helperPosition];
                CurrentPosition++;
                helperPosition++;
            }
            CurrentPosition += SkipSize;
            while (CurrentPosition >= Rope.Count)
                CurrentPosition -= Rope.Count;
            SkipSize++;
        }

    }
}
