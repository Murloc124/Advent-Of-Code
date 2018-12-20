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
            SumOfMetaData(0);
            Console.WriteLine("Day 08 - Part 1: " + MetadataSum);
            Console.WriteLine("Day 08 - Part 2: " + GetValue(0));
            Console.ReadLine();
        }

        private static int GetValue(int position)
        {
            var childNodes = int.Parse(Data[position]);
            var metadataLength = int.Parse(Data[position + 1]);
            var sum = 0;

            List<int> valueList = new List<int>();

            for (int i = 0; i < childNodes; i++)
            {
                valueList.Add(GetValue(position + 2));
                position = GetLength(position + 2);
            }

            while (metadataLength > 0)
            {
                if (childNodes > 0)
                    try
                    {
                        sum += valueList[int.Parse(Data[position + metadataLength - 1])];
                    } catch (Exception) { }
                else
                    sum += int.Parse(Data[position + metadataLength - 1]);
                metadataLength--;
            }

            return sum;
        }

        private static int GetLength(int position)
        {
            var childNodes = int.Parse(Data[position]);
            var metadataLength = int.Parse(Data[position + 1]);
            var newPosition = position;
            for (int i = 0; i < childNodes; i++)
                newPosition = GetLength(position + 2);
            return newPosition + metadataLength;
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

        //private static int SpecialSumOfMetaData(int position)
        //{
        //    var childNodes = int.Parse(Data[position]);
        //    var metadataLength = int.Parse(Data[position + 1]);
        //    var endPosition = position + 2;
        //    List<int> childrenValuesList = new List<int>();

        //    for (int i = 0; i < childNodes; i++)
        //    {
        //        MetadataSum = 0;
        //        endPosition = SpecialSumOfMetaData(endPosition);
        //        childrenValuesList.Add(MetadataSum);
        //    }
        //    endPosition += metadataLength - 1;
        //    if (position == 0)
        //    {
        //        for (int i = 0; i < childNodes; i++)
        //        {
        //            var childNumber = int.Parse(Data[endPosition - metadataLength + 1]);
        //            try
        //            {
        //                SpecialMetadataSum += childrenValuesList[childNumber - 1];
        //            }
        //            catch (Exception)
        //            {
        //            }
        //        }
        //    } else if (childNodes == 0)
        //    {
        //        return SumOfMetaData(endPosition - metadataLength - 1);
        //    } else
        //    {
        //        MetadataSum = 0;
        //        for (int i = 0; i < childNodes; i++)
        //        {
        //            var childNumber = int.Parse(Data[endPosition - metadataLength + 1]);
        //            try
        //            {
        //                MetadataSum += childrenValuesList[childNumber - 1];
        //            }
        //            catch (Exception)
        //            {
        //            }
        //        }
        //    }
        //    return endPosition + 1;
        //}
    }
}
