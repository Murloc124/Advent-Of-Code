using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_12___Digital_Plumber
{
    class Program
    {
        private static List<string> Data = File.ReadAllLines(@"..\..\Day12_Data.txt").ToList();
        private static List<int> CanCommunicateList = new List<int> { 0 };
        private static Dictionary<int, List<int>> Groups = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            var previousCount = 0;
            while (CanCommunicateList.Count != previousCount)
            {
                previousCount = CanCommunicateList.Count;
                Data.ForEach(x => CheckCanCommunicate(x));
            }
            Console.WriteLine("Day 12 - Part 1: " + CanCommunicateList.Count);
            Groups.Add(0, CanCommunicateList);

            for (int i = 1; i < Data.Count; i++)
            {
                var exit = false;
                foreach (var group in Groups)
                {
                    if (group.Value.Contains(i))
                    {
                        exit = true;
                        break;
                    }
                }
                if (exit)
                    continue;
                CanCommunicateList = new List<int> { i };
                previousCount = 0;
                while (CanCommunicateList.Count != previousCount)
                {
                    previousCount = CanCommunicateList.Count;
                    Data.ForEach(x => CheckCanCommunicate(x));
                }
                Groups.Add(i, CanCommunicateList);
            }
            Console.WriteLine("Day 12 - Part 2: " + Groups.Count);
            Console.ReadLine();
        }

        private static void CheckCanCommunicate(string record)
        {
            var id = record.Substring(0, record.IndexOf('<'));
            var connections = record.Substring(record.IndexOf('>') + 1).Split(',').ToList();
            connections.ForEach(y =>
            {
                if (!CanCommunicateList.Contains(int.Parse(id)) && CanCommunicateList.Contains(int.Parse(y)))
                    CanCommunicateList.Add(int.Parse(id));
            });
        }
    }
}
