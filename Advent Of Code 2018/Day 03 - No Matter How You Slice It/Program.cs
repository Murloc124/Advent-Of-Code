using System;
using System.IO;

namespace Day_3___No_Matter_How_You_Slice_It
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"..\..\Day03-Data.txt");
            var result = 0;
            var matrix = new int[1000, 1000];

            foreach (var entry in data)
            {
                var id = int.Parse(entry.Substring(entry.IndexOf('#') + 1, entry.IndexOf('@') - (entry.IndexOf('#') + 1)));
                var indexX = int.Parse(entry.Substring(entry.IndexOf('@') + 2, entry.IndexOf(',') - (entry.IndexOf('@') + 2)));
                var indexY = int.Parse(entry.Substring(entry.IndexOf(',') + 1, entry.IndexOf(':') - (entry.IndexOf(',') + 1)));
                var sizeX = int.Parse(entry.Substring(entry.IndexOf(':') + 2, entry.IndexOf('x') - (entry.IndexOf(':') + 2)));
                var sizeY = int.Parse(entry.Substring(entry.IndexOf('x') + 1));

                for (int x = indexX; x < (indexX + sizeX); x++)
                {
                    for (int y = indexY; y < (indexY + sizeY); y++)
                    {
                        if (int.Parse(matrix.GetValue(x,y).ToString()) != 0)
                        {
                            matrix.SetValue(-1, x, y);
                        } else
                        matrix.SetValue(id, x, y);
                    }
                }
            }
            foreach (var entry in matrix)
            {
                if (entry == -1)
                {
                    result++;
                }
            }

            Console.WriteLine("Day 3 - Part 1: " + result);

            foreach (var entry in data)
            {
                var id = int.Parse(entry.Substring(entry.IndexOf('#') + 1, entry.IndexOf('@') - (entry.IndexOf('#') + 1)));
                var indexX = int.Parse(entry.Substring(entry.IndexOf('@') + 2, entry.IndexOf(',') - (entry.IndexOf('@') + 2)));
                var indexY = int.Parse(entry.Substring(entry.IndexOf(',') + 1, entry.IndexOf(':') - (entry.IndexOf(',') + 1)));
                var sizeX = int.Parse(entry.Substring(entry.IndexOf(':') + 2, entry.IndexOf('x') - (entry.IndexOf(':') + 2)));
                var sizeY = int.Parse(entry.Substring(entry.IndexOf('x') + 1));

                var isValid = true;

                for (int x = indexX; x < (indexX + sizeX); x++)
                {
                    for (int y = indexY; y < (indexY + sizeY); y++)
                    {
                        if (int.Parse(matrix.GetValue(x, y).ToString()) != id)
                        {
                            isValid = false;
                        }
                    }
                }
                if (isValid)
                {
                    result = id;
                    break;
                }
            }

            Console.WriteLine("Dat 3 - Part 2: " + result);
            Console.ReadLine();
        }
    }
}
