using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day_14___Disk_Fragmentation
{
    class Program
    {
        private static string Data = "flqrgnkx";
        private static int[,] Disk = new int[128,128];
        private static List<int> Length = new List<int>();
        private static List<int> Rope = Enumerable.Range(0, 256).ToList();
        private static int CurrentPosition = 0, SkipSize = 0, UsedSpaces = 0;

        static void Main(string[] args)
        {
            for (int times = 0; times < 128; times++)
            {
                Length = new List<int>();
                Rope = Enumerable.Range(0, 256).ToList();
                CurrentPosition = 0;
                SkipSize = 0;
                foreach (var c in (Data  + "-" + times))
                    Length.Add(c);
                Length.AddRange(new List<int> { 17, 31, 73, 47, 23 });

                Length.ForEach(x => DoKnotHash(x));

                var hexList = new List<string>();
                for (int i = 0; i < 16; i++)
                {
                    var xorValues = new List<int>();
                    for (int j = i * 16; j < (i + 1) * 16; j++)
                        xorValues.Add(Rope[j]);
                    hexList.Add(xorValues.Aggregate((l, r) => l ^ r).ToString("x2"));
                }
                var binaryValue = "";
                hexList.ForEach(x => binaryValue += x);
                //binaryValue = String.Join(String.Empty, binaryValue.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

                binaryValue = Convert.ToString(BigInteger.Parse(binaryValue), 2).PadLeft(128, '0');

                for (int i = 0; i < binaryValue.Length; i++)
                    Disk[times, i] = int.Parse(binaryValue[i].ToString());
            }
            foreach (var value in Disk)
                if (value == 1)
                    UsedSpaces++;

            Console.WriteLine("Day 14 - Part 1: " + UsedSpaces);
            Console.Read();
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
