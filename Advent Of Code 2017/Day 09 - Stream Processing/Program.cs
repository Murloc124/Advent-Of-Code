using System;
using System.IO;
using System.Linq;

namespace Day_09___Stream_Processing
{
    class Program
    {
        private static string Data = File.ReadAllLines(@"..\..\Day09-Data.txt").ToList()[0].ToString();
        private static int Score = 0, CanceledCharacters = 0, ScoreModifier = 0;
        private static bool Ignore = false;

        static void Main(string[] args)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                switch (Data[i])
                {
                    case '{':
                        if (!Ignore)
                        {
                            ScoreModifier++;
                            Score += ScoreModifier;
                        } else
                            CanceledCharacters++;
                        break;
                    case '}':
                        if (!Ignore)
                            ScoreModifier--;
                        else
                            CanceledCharacters++;
                        break;
                    case '!':
                        i++;
                        break;
                    case '<':
                        if (Ignore)
                            CanceledCharacters++;
                        Ignore = true;
                        break;
                    case '>':
                        Ignore = false;
                        break;
                    default:
                        if (Ignore)
                            CanceledCharacters++;
                        break;
                }
            }
            Console.WriteLine("Day 09 - Part 1: " + Score);
            Console.WriteLine("Dau 09 - Part 2: " + CanceledCharacters);
            Console.ReadLine();
        }
    }
}
