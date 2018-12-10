using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_10___The_Stars_Align
{
    class Point
    {
        private int positionX;
        public int PositionX
        {
            get { return positionX; }
            set
            {
                if (value > maxPosX)
                    maxPosX = value;
                if (value < minPosX)
                    minPosX = value;
                positionX = value;
            }
        }

        private int positionY;
        public int PositionY
        {
            get { return positionY; }
            set
            {
                if (value > maxPosY)
                    maxPosY = value;
                if (value < minPosY)
                    minPosY = value;
                positionY = value;
            }
        }
            
        public int velocityX, velocityY;
        public static int maxPosX = int.MinValue, maxPosY = int.MinValue, minPosX = int.MaxValue, minPosY = int.MaxValue;

        public void AddVelocity()
        {
            PositionX = PositionX + velocityX;
            PositionY = PositionY + velocityY;
        }

        public bool Equals(int x, int y)
        {
            if (PositionX == x && PositionY == y)
                return true;
            return false;
        }

        public static void ResetMaxMin()
        {
            maxPosX = int.MinValue;
            maxPosY = int.MinValue;
            minPosX = int.MaxValue;
            minPosY = int.MaxValue;
        }

        public static int GetMaxMinDifferenceX()
        {
            return maxPosX - minPosX;
        }

        public static int GetMaxMinDifferenceY()
        {
            return maxPosY - minPosY;
        }
    }

    class Program
    {
        private static List<string> Data = File.ReadAllLines(@"..\..\Day10_Data.txt").ToList();
        private static List<Point> Points = new List<Point>();

        static void Main(string[] args)
        {
            Data.ForEach(x => FillPoints(x));

            var hasFoundConvergence = false;
            var counter = 0;
            while (!hasFoundConvergence)
            {
                Point.ResetMaxMin();
                Points.ForEach(x => x.AddVelocity());
                if (Point.GetMaxMinDifferenceY() <= 10 && Point.GetMaxMinDifferenceX() <= 100)
                    hasFoundConvergence = true;
                counter++;
            }

            DrawGrid();
            Console.WriteLine("Count: " + counter); 
            Console.ReadLine();
        }

        private static void DrawGrid()
        {
            var grid = new string[Point.GetMaxMinDifferenceX() + 1, Point.GetMaxMinDifferenceY() + 1];
            Points.ForEach(p => grid[p.PositionX - Point.minPosX, p.PositionY - Point.minPosY] = "#");

            for (int y = 0; y <= Point.GetMaxMinDifferenceY(); y++)
            { 
                for (int x = 0; x <= Point.GetMaxMinDifferenceX(); x++)
                    Console.Write((grid[x, y] == null) ? "." : grid[x, y]);
                Console.WriteLine();
            }
        }

        private static void FillPoints(string dataLine)
        {
            var point = new Point();
            point.PositionX = int.Parse(dataLine.Substring(10, 6));
            point.PositionY = int.Parse(dataLine.Substring(18, 6));
            point.velocityX = int.Parse(dataLine.Substring(36, 2));
            point.velocityY = int.Parse(dataLine.Substring(40, 2));
            Points.Add(point);
        }
    }
}
