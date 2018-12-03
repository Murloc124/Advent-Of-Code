using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_6___Memory_Reallocation
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[] { 14, 0, 15, 12, 11, 11, 3, 5, 1, 6, 8, 4, 9, 1, 8, 4 };
            var dataSeenBefore = new List<int[]>();
            dataSeenBefore.Add(data);
            var areAllEqual = false;

            while (!areAllEqual)
            {
                var lastdata = (int[])dataSeenBefore.Last().Clone();
                var highestValue = 0;
                var index = 0;

                for (int i = 0; i < lastdata.Length; i++)
                {
                    if (lastdata[i] > highestValue)
                    {
                        highestValue = lastdata[i];
                        index = i;
                    }
                }
                lastdata[index] = 0;
                while (highestValue > 0)
                {
                    index++;
                    if (index == lastdata.Length)
                    {
                        index = 0;
                    }
                    lastdata[index]++;
                    highestValue--;
                }
                foreach (var entry in dataSeenBefore)
                {
                    areAllEqual = true;
                    for (int i = 0; i < entry.Length; i++)
                    {
                        if (entry[i] != lastdata[i])
                        {
                            areAllEqual = false;
                            break;
                        }
                    }
                    if (areAllEqual)
                        break;
                }
                dataSeenBefore.Add(lastdata);
            }

            Console.WriteLine("Memory reallocation Part 1: " + dataSeenBefore.Count);

            areAllEqual = false;
            var newDataSeenBefore = new List<int[]>();
            newDataSeenBefore.Add(dataSeenBefore.Last());

            while (!areAllEqual)
            {
                var lastdata = (int[])newDataSeenBefore.Last().Clone();
                var highestValue = 0;
                var index = 0;

                for (int i = 0; i < lastdata.Length; i++)
                {
                    if (lastdata[i] > highestValue)
                    {
                        highestValue = lastdata[i];
                        index = i;
                    }
                }
                lastdata[index] = 0;
                while (highestValue > 0)
                {
                    index++;
                    if (index == lastdata.Length)
                    {
                        index = 0;
                    }
                    lastdata[index]++;
                    highestValue--;
                }
                foreach (var entry in newDataSeenBefore)
                {
                    areAllEqual = true;
                    for (int i = 0; i < entry.Length; i++)
                    {
                        if (entry[i] != lastdata[i])
                        {
                            areAllEqual = false;
                            break;
                        }
                    }
                    if (areAllEqual)
                        break;
                }
                newDataSeenBefore.Add(lastdata);
            }

            Console.WriteLine("Memory reallocation Part 2: " + (newDataSeenBefore.Count - 1));
            Console.ReadLine();
        }
    }
}
