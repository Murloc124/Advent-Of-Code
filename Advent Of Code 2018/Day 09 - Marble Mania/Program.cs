using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_09___Marble_Mania
{
    class Program
    {
        private static int AmountOfMarbles = 712230, AmoutOfPlayers = 455;
        private static int Position = 1, CurrentPlayer = 0;
        private static List<int> MarbleCircle = new List<int>();
        private static Dictionary<int, int> Players = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            InitializePlayers();

            MarbleCircle.Add(0);
            for (int i = 1; i <= AmountOfMarbles; i++)
            {
                if (i % 23 == 0)
                {
                    Players[CurrentPlayer] += i;
                    Position -= 7;
                    if (Position < 0)
                        Position = MarbleCircle.Count + Position;
                    Players[CurrentPlayer] += MarbleCircle[Position];
                    MarbleCircle.RemoveAt(Position);
                }
                else if (Position + 2 <= MarbleCircle.Count)
                {
                    Position += 2;
                    MarbleCircle.Insert(Position, i);
                } else
                {
                    Position = 1;
                    MarbleCircle.Insert(Position, i);
                }
                CurrentPlayer++;
                if (CurrentPlayer > Players.Keys.Max())
                    CurrentPlayer = 0;
            }

            Console.WriteLine("Day 09 - Part 1: " + Players.Values.Max());
            Console.ReadLine();
        }

        private static void InitializePlayers()
        {
            for (int i = 0; i < AmoutOfPlayers; i++)
                Players.Add(i, 0);
        }
    }
}
