using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Day_17___Reservoir_Research
{
    class Program
    {
        private static List<string> Data = File.ReadLines(@"../../Day17_Data.txt").ToList();
        private static char[,] WaterFlow;
        private static int MaxX, MaxY, CurrentYPosition = 0;

        static void Main(string[] args)
        {
            Data.Sort();
            InitWaterFlow();
            PrintWaterFlow();
            WaterFlow[500, 0] = '+';
            while (true)
            {

                for (int x = 0; x < MaxX; x++)
                {
                    if (WaterFlow[x, CurrentYPosition] == '+')
                    {
                        CurrentYPosition++;
                        if (WaterFlow[x, CurrentYPosition] == '#')
                        {
                            CurrentYPosition--;
                            WaterFlow[x, CurrentYPosition] = '~';
                            CheckLeftForClay(x, CurrentYPosition - 1);
                            CheckRightForClay(x, CurrentYPosition + 1);
                        } else
                            WaterFlow[x, CurrentYPosition] = '|';
                        break;
                    }
                    else if (WaterFlow[x, CurrentYPosition] == '|')
                    {
                        CurrentYPosition++;
                        if (WaterFlow[x, CurrentYPosition] == '#')
                        {
                            CurrentYPosition--;
                            WaterFlow[x, CurrentYPosition] = CheckLeftForClay(x, CurrentYPosition); //Algemene methode check edges van maken ipv rechts ne links
                            CheckRightForClay(x, CurrentYPosition);
                        }
                        else
                            WaterFlow[x, CurrentYPosition] = '|';
                        break;
                    }
                    else if (WaterFlow[x, CurrentYPosition] == '~')
                    {

                        //Zet een bool op true
                        //Indien geen andere tekens doe pos -1 en check op overlopen.
                    } 
                }
                break;
            }

            Console.WriteLine("Day 17 : ");
            Console.ReadLine();
        }

        private static bool CheckLeftForClay(int x, int y)
        {
            if (WaterFlow[x - 1, y] != '#')
            {
                if (x == 1)
                    return false;
                return CheckLeftForClay(x - 1, y);
            }
            return true;
        }

        private static bool CheckRightForClay(int x, int y)
        {
            if (WaterFlow[x + 1, y] != '#')
            {
                if (x == MaxX - 2)
                    return false;
                return CheckRightForClay(x + 1, y);
            }
            return true;
        }

        private static void PrintWaterFlow()
        {
            for (int y = 0; y < MaxY; y++) 
            {
                for (int x = 0; x < MaxX; x++)
                {
                    Console.Write(WaterFlow[x, y]);
                }
                Console.WriteLine();
            }
        }

        private static void InitWaterFlow()
        {
            Data.ForEach(x =>
            {
                if (x.StartsWith("x="))
                {
                    MaxX = MaxX > int.Parse(x.Substring(2, x.IndexOf(',') - 2)) ? MaxX : int.Parse(x.Substring(2, x.IndexOf(',') - 2));
                    MaxY = MaxY > int.Parse(x.Substring(x.IndexOf("..") + 2)) ? MaxY : int.Parse(x.Substring(x.IndexOf("..") + 2));
                }
                else if (x.StartsWith("y="))
                {
                    MaxX = MaxX > int.Parse(x.Substring(x.IndexOf("..") + 2)) ? MaxX : int.Parse(x.Substring(x.IndexOf("..") + 2));
                    MaxY = MaxY > int.Parse(x.Substring(2, x.IndexOf(',') - 2)) ? MaxY : int.Parse(x.Substring(2, x.IndexOf(',') - 2));
                }
            });
            WaterFlow = new char[MaxX + 1, MaxY + 1];
            for (int y = 0; y < MaxY; y++)
                for (int x = 0; x < MaxX; x++)
                    WaterFlow[x, y] = '.';

            Data.ForEach(x =>
            {
                if (x.StartsWith("x="))
                {
                    var xCoord = int.Parse(x.Substring(2, x.IndexOf(',') - 2));
                    for (int y = int.Parse(x.Substring(x.IndexOf("y=") + 2, x.IndexOf("..") - (x.IndexOf("y=") + 2))); y <= int.Parse(x.Substring(x.IndexOf("..") + 2)); y++)
                        WaterFlow.SetValue('#', xCoord, y);
                }
                else if (x.StartsWith("y="))
                {
                    var yCoord = int.Parse(x.Substring(2, x.IndexOf(',') - 2));
                    for (int xCo = int.Parse(x.Substring(x.IndexOf("x=") + 2, x.IndexOf("..") - (x.IndexOf("x=") + 2))); xCo <= int.Parse(x.Substring(x.IndexOf("..") + 2)); xCo++)
                        WaterFlow.SetValue('#', xCo, yCoord);
                }
            });
        }
    }

}
