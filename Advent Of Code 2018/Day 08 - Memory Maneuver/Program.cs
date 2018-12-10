using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_08___Memory_Maneuver
{
    class Program
    {
        private static List<string> Data = File.ReadAllLines(@"../../Day08_Data.txt").ToList()[0].Split(' ').ToList();
        private static int MetadataSum = 0, SpecialMetadataSum = 0;

        static void Main(string[] args)
        {
           // Data = new List<string> { "2", "3", "0", "3", "10", "11", "12", "1", "1", "0", "1", "99", "2", "1", "1", "2" };
            SumOfMetaData(0);
            Console.WriteLine("Day 08 - Part 1: " + MetadataSum);
            MetadataSum = 0;
            SpecialSumOfMetaData(0);
            Console.WriteLine("Day 08 - Part 2: " + SpecialMetadataSum);
            Console.ReadLine();
        }

        private static int SumOfMetaData(int position)
        {
            var childNodes = int.Parse(Data[position]);
            var metadataLength = int.Parse(Data[position + 1]);
            var endPosition = position + 2;
            for (int i = 0; i < childNodes; i++)
                endPosition = SumOfMetaData(endPosition);
            endPosition += metadataLength - 1;
            while (metadataLength > 0)
            {
                MetadataSum = MetadataSum + int.Parse(Data[endPosition - metadataLength + 1]);
                metadataLength--;
            }
            return endPosition + 1;
        }

        private static int SpecialSumOfMetaData(int position)
        {
            var childNodes = int.Parse(Data[position]);
            var metadataLength = int.Parse(Data[position + 1]);
            var endPosition = position + 2;
            List<int> childrenValuesList = new List<int>();

            for (int i = 0; i < childNodes; i++)
            {
                MetadataSum = 0;
                endPosition = SpecialSumOfMetaData(endPosition);
                childrenValuesList.Add(MetadataSum);
            }
            endPosition += metadataLength - 1;
            if (position == 0)
            {
                for (int i = 0; i < childNodes; i++)
                {
                    var childNumber = int.Parse(Data[endPosition - metadataLength + 1]);
                    try
                    {
                        SpecialMetadataSum += childrenValuesList[childNumber - 1];
                    }
                    catch (Exception)
                    {
                    }
                }
            } else if (childNodes == 0)
            {
                return SumOfMetaData(endPosition - metadataLength - 1);
            } else
            {
                MetadataSum = 0;
                for (int i = 0; i < childNodes; i++)
                {
                    var childNumber = int.Parse(Data[endPosition - metadataLength + 1]);
                    try
                    {
                        MetadataSum += childrenValuesList[childNumber - 1];
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return endPosition + 1;
        }
    }
}
