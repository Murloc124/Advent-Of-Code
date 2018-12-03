using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_07___Recursive_Circus
{
    class Program
    {
        private static List<string> HoldingProgramsList = new List<string>();
        private static Dictionary<string, string> HoldingProgramsDict = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"..\..\Day07-Data.txt");
            
            var isBottom = false;

            foreach (var entry in data)
            {
                var entryname = entry.Substring(0, entry.IndexOf('(') - 1);
                var weight = entry.Substring(entry.IndexOf('(') + 1, entry.IndexOf(')') - (entry.IndexOf('(') + 1));
                
                if (entry.Contains("->"))
                {
                    var holdingPrograms = entry.Substring(entry.IndexOf('>') + 1);
                    holdingPrograms.Replace(" ", "").Split(',').ToList().ForEach(x => {
                        HoldingProgramsList.Add(x);
                        weight += " " + x;
                    });
                }
                HoldingProgramsDict.Add(entryname, weight);
            }
            foreach (var entry in data)
            {
                isBottom = true;
                var entryname = entry.Substring(0, entry.IndexOf('(') - 1);
                for (int i = 0; i < HoldingProgramsList.Count; i++)
                {   
                    if (entryname.Equals(HoldingProgramsList[i]))
                    {
                        isBottom = false;
                        break;
                    }
                }
                if (isBottom)
                {
                    Console.WriteLine("Day 07 - Part 1: " + entryname);
                    break;
                }
            }

            foreach (var entry in HoldingProgramsDict)
            {
                var comparator = new List<int>();
                var values = entry.Value.Split(' ');
                for (int i = 0; i < values.Length; i++)
                {
                    if (i != 0)
                    {
                        comparator.Add(GetValue(values[i]));
                    }
                }
                if (comparator.Count > 0)
                {
                    var valueToCompare = comparator.First();
                    comparator.ForEach(x =>
                    {
                        if (x != valueToCompare)
                        {
                            Console.WriteLine("Day 07 - Part 2: " + x + " " + entry.Key);
                        }
                    });
                }
            }

            //With manual debugging you can get the expected result
            var val = HoldingProgramsDict["marnqj"].Split(' ');
            for (int i = 0; i < val.Length; i++)
            {
                if ( i != 0)
                {
                    Console.WriteLine("for marnqj " + val[i] + ": " + GetValue(val[i]));
                } else
                {
                    Console.WriteLine("Baseval = " + val[i]);
                }
            }

            Console.ReadLine();
        }

        private static int GetValue(string dictKey)
        {
            var values = HoldingProgramsDict[dictKey].Split(' ');
            var firstWeightValue = int.Parse(values.First());
            var totalWeight = firstWeightValue;

            if (values.Length > 1)
            {
                for (int i = 1; i < values.Length; i++)
                {
                    totalWeight += GetValue(values[i]);
                }
            }
            return totalWeight;
        }
    }
}
