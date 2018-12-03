using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day__08___I_Heard_You_Like_Registers
{
    class Program
    {
        private static Dictionary<string, int> Registers = new Dictionary<string, int>();
        private static int HighestValueEver = int.MinValue;

        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"..\..\Day08-Data.txt").ToList();
            data.ForEach(x =>
            {
                if (!Registers.ContainsKey(x.Substring(0, (x.IndexOf("dec") > 0) ? x.IndexOf("dec") : x.IndexOf("inc")).Replace(" ", "")))
                {
                    Registers.Add(x.Substring(0, (x.IndexOf("dec") > 0) ? x.IndexOf("dec") : x.IndexOf("inc")).Replace(" ", ""), 0);
                }
            });

            foreach (var entry  in data)
            {
                var registerKey = entry.Substring(0, (entry.IndexOf("dec") > 0) ? entry.IndexOf("dec") : entry.IndexOf("inc")).Replace(" ", "");
                var modValue = int.Parse(entry.Substring((entry.IndexOf("dec") > 0) ? entry.IndexOf("dec") + 3 : entry.IndexOf("inc") + 3, entry.IndexOf("if") - ((entry.IndexOf("dec") > 0) ? entry.IndexOf("dec") + 3 : entry.IndexOf("inc") + 3)).Replace(" ", ""));
                if (entry.IndexOf(">=") > 0)
                {
                    var key = entry.Substring(entry.IndexOf("if") + 2, entry.IndexOf(">=") - (entry.IndexOf("if") + 2)).Replace(" ", "");
                    var value = int.Parse(entry.Substring(entry.IndexOf(">=") + 2));
                    if (Registers[key] >= value)
                    {
                        DoOperation(entry, registerKey, modValue);
                    }
                } else if (entry.IndexOf(">") > 0)
                {
                    var key = entry.Substring(entry.IndexOf("if") + 2, entry.IndexOf(">") - (entry.IndexOf("if") + 2)).Replace(" ", "");
                    var value = int.Parse(entry.Substring(entry.IndexOf(">") + 2));
                    if (Registers[key] > value)
                    {
                        DoOperation(entry, registerKey, modValue);
                    }
                } else if (entry.IndexOf("<=") > 0)
                {
                    var key = entry.Substring(entry.IndexOf("if") + 2, entry.IndexOf("<=") - (entry.IndexOf("if") + 2)).Replace(" ", "");
                    var value = int.Parse(entry.Substring(entry.IndexOf("<=") + 2));
                    if (Registers[key] <= value)
                    {
                        DoOperation(entry, registerKey, modValue);
                    }
                } else if (entry.IndexOf("<") > 0)
                {
                    var key = entry.Substring(entry.IndexOf("if") + 2, entry.IndexOf("<") - (entry.IndexOf("if") + 2)).Replace(" ", "");
                    var value = int.Parse(entry.Substring(entry.IndexOf("<") + 2));
                    if (Registers[key] < value)
                    {
                        DoOperation(entry, registerKey, modValue);
                    }
                } else if(entry.IndexOf("==") > 0)
                {
                    var key = entry.Substring(entry.IndexOf("if") + 2, entry.IndexOf("==") - (entry.IndexOf("if") + 2)).Replace(" ", "");
                    var value = int.Parse(entry.Substring(entry.IndexOf("==") + 2));
                    if (Registers[key] == value)
                    {
                        DoOperation(entry, registerKey, modValue);
                    }
                } else // !=
                {
                    var key = entry.Substring(entry.IndexOf("if") + 2, entry.IndexOf("!=") - (entry.IndexOf("if") + 2)).Replace(" ", "");
                    var value = int.Parse(entry.Substring(entry.IndexOf("!=") + 2));
                    if (Registers[key] != value)
                    {
                        DoOperation(entry, registerKey, modValue);
                    }
                }
            }

            Console.WriteLine("Day 08 - Part 1: " + Registers.Values.Max());
            Console.WriteLine("Day 08 - Part 2: " + HighestValueEver);
            Console.ReadLine();
        }

        private static void DoOperation(string dataEntry, string registerKey, int modificationValue)
        {
            //Check Operation
            switch (dataEntry.Substring((dataEntry.IndexOf("dec") > 0) ? dataEntry.IndexOf("dec") : dataEntry.IndexOf("inc"), 3))
            {
                case "dec":
                    Registers[registerKey] -= modificationValue;
                    break;
                case "inc":
                    Registers[registerKey] += modificationValue;
                    break;
            }
            if (Registers[registerKey] > HighestValueEver)
            {
                HighestValueEver = Registers[registerKey];
            }
        }
    }
}
