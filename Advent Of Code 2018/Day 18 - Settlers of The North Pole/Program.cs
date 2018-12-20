using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_18___Settlers_of_The_North_Pole
{
    class Program
    {
        private static List<string> Data = File.ReadAllLines(@"../../Day18_Data.txt").ToList();
        private static char[,] Map;

        private static List<char[,]> PreviousMapStates = new List<char[,]>();

        static void Main(string[] args)
        {
            ProcessData();

            Console.WriteLine("Initial State");
            DrawMap();

            int upperBound = 1000000000;
            while (upperBound < 470)
                upperBound -= 56;
            upperBound += 57;

            for (int i = 1; i < upperBound; i++)
            {
                var newMap = new char[Data[0].Length, Data.Count];
                for (int y = 0; y < Data.Count; y++)
                {
                    for (int x = 0; x < Data[0].Length; x++)
                    {
                        switch (Map[x, y])
                        {
                            case '.':
                                newMap[x, y] = CheckOpenTerrain(x, y);
                                break;
                            case '|':
                                newMap[x, y] = CheckWoodTerrain(x, y);
                                break;
                            case '#':
                                newMap[x, y] = CheckLumberyardTerrain(x, y);
                                break;
                        }
                    }
                }
                Map = newMap;
                CheckPreviousMapStates(i - 1);
                PreviousMapStates.Add(newMap);
                Console.WriteLine("Step " + i);
                DrawMap();

            }

            Console.WriteLine("Day 18: " + GetResourceValue());
            Console.ReadLine();
        }

        private static void CheckPreviousMapStates(int currentMinute)
        {
            var minute = 0;
            foreach (var state in PreviousMapStates)
            {
                bool canContinue = true;
                minute = PreviousMapStates.IndexOf(state);
                for (int y = 0; y < Data.Count; y++)
                {
                    for (int x = 0; x < Data[0].Length; x++)
                    {
                        if (!state[x, y].Equals(Map[x, y]))
                        {
                            canContinue = false;
                            break;
                        }
                    }
                }
                if (canContinue)
                    Console.WriteLine("Loop Found: " + (currentMinute - minute));
            }
        }

        private static void DrawMap()
        {
            for (int y = 0; y < Data.Count; y++)
            {
                for (int x = 0; x < Data[0].Length; x++)
                    Console.Write(Map[x, y]);
                Console.WriteLine();
            }
        }

        private static char CheckOpenTerrain(int x, int y)
        {
            var count = 0;
            if (x > 0)
                if (Map[x - 1, y].Equals('|'))
                    count++;
            if (x > 0 && y < Data.Count - 1)
                if (Map[x - 1, y + 1].Equals('|'))
                    count++;
            if (y > 0)
                if (Map[x, y - 1].Equals('|'))
                    count++;
            if (y > 0 && x < Data[0].Length - 1)
                if (Map[x + 1, y - 1].Equals('|'))
                    count++;
            if (x > 0 && y > 0)
                if (Map[x - 1, y - 1].Equals('|'))
                    count++;
            if (x < Data[0].Length - 1 && y < Data.Count - 1)
                if (Map[x + 1, y + 1].Equals('|'))
                    count++;
            if (x < Data[0].Length - 1)
                if (Map[x + 1, y].Equals('|'))
                    count++;
            if (y < Data.Count - 1)
                if (Map[x, y + 1].Equals('|'))
                    count++;
            if (count >= 3)
                return '|';
            return '.';
        }

        private static char CheckWoodTerrain(int x, int y)
        {
            var count = 0;
            if (x > 0)
                if (Map[x - 1, y].Equals('#'))
                    count++;
            if (x > 0 && y < Data.Count - 1)
                if (Map[x - 1, y + 1].Equals('#'))
                    count++;
            if (y > 0)
                if (Map[x, y - 1].Equals('#'))
                    count++;
            if (y > 0 && x < Data[0].Length - 1)
                if (Map[x + 1, y - 1].Equals('#'))
                    count++;
            if (x > 0 && y > 0)
                if (Map[x - 1, y - 1].Equals('#'))
                    count++;
            if (x < Data[0].Length - 1 && y < Data.Count - 1)
                if (Map[x + 1, y + 1].Equals('#'))
                    count++;
             if (x < Data[0].Length - 1)
                if (Map[x + 1, y].Equals('#'))
                    count++;
            if (y < Data.Count - 1)
                if (Map[x, y + 1].Equals('#'))
                    count++;
            if (count >= 3)
                return '#';
            return '|';
        }

        private static char CheckLumberyardTerrain(int x, int y)
        {
            int countLumber = 0, countYard = 0;
            if (x > 0)
            {
                if (Map[x - 1, y].Equals('#'))
                    countYard++;
                if (Map[x - 1, y].Equals('|'))
                    countLumber++;
            }
            if (x > 0 && y < Data.Count - 1)
            {
                if (Map[x - 1, y + 1].Equals('#'))
                    countYard++;
                if (Map[x - 1, y + 1].Equals('|'))
                    countLumber++;
            }
            if (y > 0)
            {
                if (Map[x, y - 1].Equals('#'))
                    countYard++;
                if (Map[x, y - 1].Equals('|'))
                    countLumber++;
            }
            if (y > 0 && x < Data[0].Length - 1)
            {
                if (Map[x + 1, y - 1].Equals('#'))
                    countYard++;
                if (Map[x + 1, y - 1].Equals('|'))
                    countLumber++;
            }
            if (x > 0 && y > 0)
            {
                if (Map[x - 1, y - 1].Equals('#'))
                    countYard++;
                if (Map[x - 1, y - 1].Equals('|'))
                    countLumber++;
            }
            if (x < Data[0].Length - 1 && y < Data.Count - 1)
            {
                if (Map[x + 1, y + 1].Equals('#'))
                    countYard++;
                if (Map[x + 1, y + 1].Equals('|'))
                    countLumber++;
            }
            if (x < Data[0].Length - 1)
            {
                if (Map[x + 1, y].Equals('#'))
                    countYard++;
                if (Map[x + 1, y].Equals('|'))
                    countLumber++;
            }
            if (y < Data.Count - 1)
            {
                if (Map[x, y + 1].Equals('#'))
                    countYard++;
                if (Map[x, y + 1].Equals('|'))
                    countLumber++;
            }
            if (countYard >= 1 && countLumber >= 1)
                return '#';
            return '.';
        }

        private static int GetResourceValue()
        {
            int lumberyardCount = 0, woodedAcresCount = 0;
            foreach (var acre in Map)
            {
                if (acre.Equals('|'))
                    woodedAcresCount++;
                if (acre.Equals('#'))
                    lumberyardCount++;
            }
            return lumberyardCount * woodedAcresCount;
        }

        private static void ProcessData()
        {
            Map = new char[Data[0].Length, Data.Count];
            var row = 0;
            Data.ForEach(line =>
            {
                for (int i = 0; i < line.Length; i++)
                    Map[i, row] = line[i];
                row++;
            });
        }
    }
}
