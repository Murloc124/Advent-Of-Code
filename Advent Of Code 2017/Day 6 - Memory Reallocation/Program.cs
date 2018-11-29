using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6___Memory_Reallocation
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[] { 14, 0, 15, 12, 11, 11, 3, 5, 1, 6, 8, 4, 9, 1, 8, 4 };
            var dataSeenBefore = new List<int[]>();
            dataSeenBefore.Add(data);
            var result = 0;
            var check = true;

            while (check)
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
                    if (entry.Equals(lastdata))
                    {
                        check = false;
                    }
                }
                result++;
                dataSeenBefore.Add(lastdata);
            }
            Console.WriteLine("Memory reallocation Part 1: " + result);
            Console.ReadLine();
        }
    }
}
