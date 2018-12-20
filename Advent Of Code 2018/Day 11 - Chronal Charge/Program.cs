using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11___Chronal_Charge
{
    class Program
    {
        private static int SerialNumber = 5153;
        private static int HighestValue = int.MinValue;
        private static FuelCell[,] FuelCells;

        class FuelCell
        {
            private int RackID { get { return CoordX + 10; } }
            public int CoordX, CoordY;
            

            public int PowerLevel
            {
                get
                {
                    var power = RackID * CoordY;
                    power = power + SerialNumber;
                    power = power * RackID;
                    power = power / 100;
                    return int.Parse(power.ToString().Last().ToString()) - 5;
                }
            }

            public FuelCell(int x, int y)
            {
                CoordX = x;
                CoordY = y;
            }
        }

        static void Main(string[] args)
        {
            InitializeFuelCells();

            Console.WriteLine("Day 11 - Part 1: " + SearchHighestFuelCells(3).CoordX + ", " + SearchHighestFuelCells(3).CoordY);

            var highestValue = int.MinValue;
            FuelCell highestFuelCell = null;
            var gridSize = 0;

            for (int i = 1; i < 301; i++)
            {
                var fuelCell = SearchHighestFuelCells(i);
                if (HighestValue > highestValue)
                {
                    highestValue = HighestValue;
                    highestFuelCell = fuelCell;
                    gridSize = i;
                }
            }

            Console.WriteLine("Day 11 - Part 2: Value: " + highestValue + ", Coord: " + highestFuelCell.CoordX + ", " + highestFuelCell.CoordY + " Size: " + gridSize);
            Console.ReadLine();
        }

        private static FuelCell SearchHighestFuelCells(int size)
        {
            FuelCell HighestFuelCell = null;
            var highestPower = int.MinValue;
            for (int y = 0; y < 300 - size; y++)
            {
                for (int x = 0; x < 300 - size; x++)
                {
                    var tempPower = 0;
                    for (int sizeY = 0; sizeY < size; sizeY++)
                    {
                        for (int sizeX = 0; sizeX < size; sizeX++)
                        {
                            tempPower += FuelCells[x + sizeX, y + sizeY].PowerLevel;
                        }
                    }
                    if (tempPower > highestPower)
                    {
                        highestPower = tempPower;
                        HighestFuelCell = FuelCells[x, y];
                    }
                }
            }
            HighestValue = highestPower;
            return HighestFuelCell;
        }

        private static void InitializeFuelCells()
        {
            FuelCells = new FuelCell[300, 300];
            for (int y = 0; y < 300; y++)
            {
                for (int x = 0; x < 300; x++)
                {
                    FuelCells[x, y] = new FuelCell(x, y);
                }
            }
        }
    }
}
