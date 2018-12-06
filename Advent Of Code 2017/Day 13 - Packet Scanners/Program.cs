using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_13___Packet_Scanners
{
    class Program
    {
        private static List<string> Data = File.ReadAllLines(@"..\..\Day13_data.txt").ToList();
        private static Dictionary<int, int> Scanners = new Dictionary<int, int>();
        private static List<int> CurrentScannerPositions = new List<int>();
        private static List<int> ScannerDirections = new List<int>();
        private static int Severity = 0;
        private static long PicoSecondsWaited = 0;

        static void Main(string[] args)
        {
            InitializeData();

            for (int currentPosition = 0; currentPosition < Scanners.Count; currentPosition++)
            {
                if (CurrentScannerPositions[currentPosition] == 0 && Scanners[currentPosition] > 0)
                    Severity += currentPosition * Scanners[currentPosition];
                MoveScanners();
            }

            Console.WriteLine("Day 13 - Part 1: " + Severity);

            InitializeData();
            var tempPositions = new List<int>(CurrentScannerPositions);
            var tempDirections = new List<int>(ScannerDirections);

            while (Severity != 0)
            {
                PicoSecondsWaited++;
                Severity = 0;
                CurrentScannerPositions = new List<int>(tempPositions);
                ScannerDirections = new List<int>(tempDirections);
                MoveScanners();
                tempPositions = new List<int>(CurrentScannerPositions);
                tempDirections = new List<int>(ScannerDirections);
                for (int currentPosition = 0; currentPosition < Scanners.Count; currentPosition++)
                {
                    if (CurrentScannerPositions[currentPosition] == 0 && Scanners[currentPosition] > 0)
                    {
                        Severity++;
                        break;
                    }
                    MoveScanners();
                }
            }

            Console.Write("Day 13 - Part 2: " + PicoSecondsWaited);
            Console.ReadLine();
        }

        private static void InitializeData()
        {
            ScannerDirections = new List<int>();
            Scanners = new Dictionary<int, int>();
            CurrentScannerPositions = new List<int>();

            for (int i = 0; i <= int.Parse(Data.Last().Substring(0, Data.Last().IndexOf(':'))); i++)
            {
                var foundScanner = false;
                Data.ForEach(x =>
                {
                    if (int.Parse(x.Substring(0, x.IndexOf(':'))) == i)
                    {
                        Scanners.Add(int.Parse(x.Substring(0, x.IndexOf(':'))), int.Parse(x.Substring(x.IndexOf(':') + 1)));
                        CurrentScannerPositions.Add(0);
                        ScannerDirections.Add(-1);
                        foundScanner = true;
                    }
                });
                if (foundScanner)
                    continue;
                Scanners.Add(i, 0);
                CurrentScannerPositions.Add(0);
                ScannerDirections.Add(0);
            }
        }
        
        private static void MoveScanners()
        {
            for (int i = 0; i < CurrentScannerPositions.Count; i++)
            {
                if (CurrentScannerPositions[i] == Scanners[i] - 1 || CurrentScannerPositions[i] == 0)
                    ScannerDirections[i] = -ScannerDirections[i];
                CurrentScannerPositions[i] += ScannerDirections[i];
            }
        }
    }
}
