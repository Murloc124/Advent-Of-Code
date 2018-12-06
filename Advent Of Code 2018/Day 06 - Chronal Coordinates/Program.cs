using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_06___Chronal_Coordinates
{

    public struct Point
    {
        public int x, y;

        public int CalculateDistance(Point p)
        {
            return Math.Abs(x - p.x) + Math.Abs(y - p.y);
        }
    }

    class Program
    {
        private static List<string> Data = File.ReadAllLines(@"..\..\Day06_Data.txt").ToList();
        private static Dictionary<string, Point> Coordinates = new Dictionary<string, Point>();
        private static List<string> Infinites = new List<string>();
        private static Dictionary<string, int> Sizes = new Dictionary<string, int>();
        private static int maxX = int.MinValue, maxY = int.MinValue, minX = int.MaxValue, minY = int.MaxValue, SafeRegionSize = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                var coordinates = Data[i].Split(',');
                Coordinates.Add(((char)(65 + i)).ToString(), new Point() { x = int.Parse(coordinates[0]), y = int.Parse(coordinates[1]) });
                maxX = maxX < int.Parse(coordinates[0]) ? int.Parse(coordinates[0]) : maxX;
                maxY = maxY < int.Parse(coordinates[1]) ? int.Parse(coordinates[1]) : maxY;
                minX = minX < int.Parse(coordinates[0]) ? minX : int.Parse(coordinates[0]);
                minY = minY < int.Parse(coordinates[1]) ? minY : int.Parse(coordinates[1]);
            }
            CheckInfinites();
            FillSizes();

            Console.WriteLine("Day 06 - Part 1: " + GetBiggestSize());
            Console.WriteLine("Day 06 - Part 2: " + SafeRegionSize);
            Console.ReadLine();
        }

        private static int GetBiggestSize()
        {
            Infinites.ForEach(x => Sizes.Remove(x));
            return Sizes.Aggregate((l, r) => l.Value > r.Value ? l : r).Value;
        }

        private static void FillSizes()
        {
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    var distance = int.MaxValue;
                    var index = "";
                    var isEqual = false;
                    var totalDistance = 0;
                    Point p = new Point() { x = x, y = y };
                    for (int i = 0; i < Coordinates.Count; i++)
                    {
                        totalDistance += Coordinates[((char)(i + 65)).ToString()].CalculateDistance(p);
                        if (distance > Coordinates[((char)(i + 65)).ToString()].CalculateDistance(p))
                        {
                            distance = Coordinates[((char)(i + 65)).ToString()].CalculateDistance(p);
                            index = ((char)(i + 65)).ToString();
                            isEqual = false;
                        } else if (distance == Coordinates[((char)(i + 65)).ToString()].CalculateDistance(p))
                            isEqual = true;
                    }
                    if (!Sizes.ContainsKey(index) && !isEqual)
                        Sizes.Add(index, 1);
                    else if (!isEqual)
                        Sizes[index]++;
                    if (totalDistance < 10000)
                        SafeRegionSize++;
                }
            }
        }

        private static void CheckInfinites()
        {
            for (int x = minX - 1; x <= maxX + 1; x++)
            {
                var minDistance = int.MaxValue;
                var maxDistance = int.MaxValue;
                string minIndex = "", maxIndex = "";
                for (int i = 0; i < Coordinates.Count; i++)
                {
                    if (minDistance > Coordinates[((char)(i + 65)).ToString()].CalculateDistance(new Point() { x = x, y = minY }))
                    {
                        minDistance = Coordinates[((char)(i + 65)).ToString()].CalculateDistance(new Point() { x = x, y = minY });
                        minIndex = ((char)(i + 65)).ToString();
                    }
                    if (maxDistance > Coordinates[((char)(i + 65)).ToString()].CalculateDistance(new Point() { x = x, y = maxY }))
                    {
                        maxDistance = Coordinates[((char)(i + 65)).ToString()].CalculateDistance(new Point() { x = x, y = maxY });
                        maxIndex = ((char)(i + 65)).ToString();
                    }
                }
                if (!Infinites.Contains(minIndex))
                    Infinites.Add(minIndex);
                if (!Infinites.Contains(maxIndex))
                    Infinites.Add(maxIndex);
            }

            for (int y = minY - 1; y <= maxY + 1; y++)
            {
                var minDistance = int.MaxValue;
                var maxDistance = int.MaxValue;
                string minIndex = "", maxIndex = "";
                for (int i = 0; i < Coordinates.Count; i++)
                {
                    if (minDistance > Coordinates[((char)(i + 65)).ToString()].CalculateDistance(new Point() { x = minX, y = y }))
                    {
                        minDistance = Coordinates[((char)(i + 65)).ToString()].CalculateDistance(new Point() { x = minX, y = y });
                        minIndex = ((char)(i + 65)).ToString();
                    }
                    if (maxDistance > Coordinates[((char)(i + 65)).ToString()].CalculateDistance(new Point() { x = maxX, y = y }))
                    {
                        maxDistance = Coordinates[((char)(i + 65)).ToString()].CalculateDistance(new Point() { x = maxX, y = y });
                        maxIndex = ((char)(i + 65)).ToString();
                    }
                }
                if (!Infinites.Contains(minIndex))
                    Infinites.Add(minIndex);
                if (!Infinites.Contains(maxIndex))
                    Infinites.Add(maxIndex);
            }
        }
    }
}
