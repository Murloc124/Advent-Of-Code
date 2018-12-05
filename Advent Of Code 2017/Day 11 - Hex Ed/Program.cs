using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_11___Hex_Ed
{
    class Program
    {
        private static List<string> Data = new List<string>();
        private static int XPosition = 0, YPosition = 0, ZPosition = 0, FurthestDistanceTraveled = 0;

        static void Main(string[] args)
        {
            List<string> moves = File.ReadAllLines(@"..\..\Day11_Data.txt").ToList();
            moves.ForEach(x =>
            {
                foreach (var length in x.Split(','))
                    Data.Add(length.Trim());
            });

            //See https://www.redblobgames.com/grids/hexagons/ for a detailed explanation
            Data.ForEach(x =>
            {
                switch (x)
                {
                    case "n":
                        YPosition++;
                        ZPosition--;
                        break;
                    case "ne":
                        XPosition++;
                        ZPosition--;
                        break;
                    case "se":
                        XPosition++;
                        YPosition--;
                        break;
                    case "s":
                        ZPosition++;
                        YPosition--;
                        break;
                    case "sw":
                        XPosition--;
                        ZPosition++;
                        break;
                    case "nw":
                        XPosition--;
                        YPosition++;
                        break;
                }
                FurthestDistanceTraveled = FurthestDistanceTraveled < ((Math.Abs(XPosition) + Math.Abs(YPosition) + Math.Abs(ZPosition)) / 2) ? ((Math.Abs(XPosition) + Math.Abs(YPosition) + Math.Abs(ZPosition)) / 2) : FurthestDistanceTraveled;
            });

            Console.WriteLine("Day 11 - Part 1: " + ((Math.Abs(XPosition) + Math.Abs(YPosition) + Math.Abs(ZPosition)) / 2));
            Console.WriteLine("Day 11 - Part 2: " + FurthestDistanceTraveled);
            Console.ReadLine();
        }
    }
}
