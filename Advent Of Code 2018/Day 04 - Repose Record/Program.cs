using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_04___Repose_Record
{
    class Program
    {
        private static List<string> Data = File.ReadAllLines(@"..\..\Day04-Data.txt").ToList();
        private static Dictionary<string, int> Guards = new Dictionary<string, int>();
        private static Dictionary<int, Dictionary<int, int>> GuardsSleepyMinutes = new Dictionary<int, Dictionary<int, int>>();

        static void Main(string[] args)
        {
            Data.Sort();
            Data.ForEach(x =>
            {
                if (x.Contains("#"))
                    if(!Guards.ContainsKey(x.Substring(x.IndexOf('#') + 1, x.IndexOf('b') - (x.IndexOf('#') + 1)).Replace(" ", "")))
                        Guards.Add(x.Substring(x.IndexOf('#') + 1, x.IndexOf('b') - (x.IndexOf('#') + 1)).Replace(" ", ""), 0);
            });
            string guardID = "";
            bool asleep = false;
            int minuteFellAsleep = 0;
            Data.ForEach(x =>
            {
                if (x.Contains("#"))
                    guardID = x.Substring(x.IndexOf('#') + 1, x.IndexOf('b') - (x.IndexOf('#') + 1)).Replace(" ", "");
                else
                {
                    if (!asleep)
                    {
                        minuteFellAsleep = int.Parse(x.Substring(x.IndexOf(':') + 1, x.IndexOf(']') - (x.IndexOf(':') + 1)));
                        asleep = true;
                    } else
                    {
                        Guards[guardID] += Math.Abs(minuteFellAsleep - int.Parse(x.Substring(x.IndexOf(':') + 1, x.IndexOf(']') - (x.IndexOf(':') + 1))));
                        asleep = false;
                    }
                }
            });
            Data.ForEach(x =>
            {
                if (x.Contains("#"))
                {
                    guardID = x.Substring(x.IndexOf('#') + 1, x.IndexOf('b') - (x.IndexOf('#') + 1)).Replace(" ", "");
                }
                else
                {
                    if (!asleep)
                    {
                        minuteFellAsleep = int.Parse(x.Substring(x.IndexOf(':') + 1, x.IndexOf(']') - (x.IndexOf(':') + 1)));
                        asleep = true;
                    }
                    else
                    {
                        for (int i = minuteFellAsleep; i < int.Parse(x.Substring(x.IndexOf(':') + 1, x.IndexOf(']') - (x.IndexOf(':') + 1))); i++)
                        {
                            if (GuardsSleepyMinutes.ContainsKey(int.Parse(guardID)))
                            {
                                if (GuardsSleepyMinutes[int.Parse(guardID)].ContainsKey(i))
                                    GuardsSleepyMinutes[int.Parse(guardID)][i]++;
                                else
                                    GuardsSleepyMinutes[int.Parse(guardID)].Add(i, 1);
                            }
                            else
                            {
                                GuardsSleepyMinutes.Add(int.Parse(guardID), new Dictionary<int, int>());
                                GuardsSleepyMinutes[int.Parse(guardID)].Add(i, 1);
                            }
                        }
                        asleep = false;
                    }
                }
            });
            var kvp = GuardsSleepyMinutes.Aggregate((l, r) => l.Value.Aggregate((val1, val2) => val1.Value > val2.Value ? val1 : val2).Value > r.Value.Aggregate((val1, val2) => val1.Value > val2.Value ? val1 : val2).Value ? l : r);
            Console.WriteLine("Day 04 - Part 1: " + (int.Parse(Guards.Aggregate((l, r) => l.Value > r.Value ? l : r).Key) * GuardsSleepyMinutes[int.Parse(Guards.Aggregate((l, r) => l.Value > r.Value ? l : r).Key)].Aggregate((l, r) => l.Value > r.Value ? l : r).Key));
            Console.WriteLine("Day 04 - Part 2: " + (kvp.Key * kvp.Value.Aggregate((l, r) => l.Value > r.Value ? l : r).Key));
            Console.ReadLine();
        }
    }
}
