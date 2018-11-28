using System;
using System.Collections.Generic;

namespace Day_3___Spiral_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = 347991;
            var grid = 1;
            var result = 0;

            while ((grid * grid) < data)
            {
                grid = grid + 2;
            }
            
            if (grid * grid - data < grid) //1st arm
            {
                if ((grid * grid) - (data) < grid / 2)
                {
                    result = grid - 1 - ((grid * grid) - data);
                } else
                    result = ((grid * grid) - data);
            } else if (grid <= (grid * grid) - data && (grid * grid) - data < (grid - 1) * 2) //2nd arm
            {
                if (((grid * grid) - (data + grid)) < grid / 2)
                {
                    result = grid - 1 - ((grid * grid) - (data + grid - 1));
                } else
                    result = ((grid * grid) - (data + grid)) + 1;
            } else if ((grid - 1) * 2 <= (grid * grid) - data && (grid * grid) - data < (grid - 1) * 3) //3rd arm
            {
                if (((grid * grid) - (data + (2 * (grid - 1)))) < grid / 2)
                {
                    result = grid - 1 - ((grid * grid) - (data + 2 * (grid - 1)));
                } else 
                    result = ((grid * grid) - (data + 2 * (grid - 1)));
            } else if ((grid - 1) * 3 <= (grid * grid) - data && (grid * grid) - data < (grid - 1) * 4) //4th arm
            {
                if (((grid * grid) - (data + (3 * (grid - 1)))) < grid / 2)
                {
                    result = grid - 1 - ((grid * grid) - (data + 3 * (grid - 1)));
                } else
                    result = (grid * grid) - (data + 3 * (grid - 1));
            }

            Console.WriteLine("Spiral Memory Part 1: " + result);

            grid = 1;
            result = 0;

            var map = new Dictionary<int[], int>();
            var key = new int[] { 0, 0 };
            map.Add(key, 1);

            while (result < data)
            {
                result = 0;
                var newkey = new int[] { key[0], key[1] };
                if (newkey[0] == newkey[1] && newkey[0] != -grid) //Init move right
                {
                    newkey[1]++;
                    foreach (var mapKey in map.Keys)
                    {
                        if ((mapKey[0] - 1 == newkey[0]
                            || mapKey[0] == newkey[0]
                            || mapKey[0] + 1 == newkey[0]) &&
                            (mapKey[1] - 1 == newkey[1]
                            || mapKey[1] == newkey[1]
                            || mapKey[1] + 1 == newkey[1]))
                        {
                            result += map[mapKey];
                        }
                    }
                } else if (newkey[0] < newkey[1] && newkey[0] != -grid) //move to the top
                {
                    newkey[0]--;
                    foreach (var mapKey in map.Keys)
                    {
                        if ((mapKey[0] - 1 == newkey[0]
                            || mapKey[0] == newkey[0]
                            || mapKey[0] + 1 == newkey[0]) &&
                            (mapKey[1] - 1 == newkey[1]
                            || mapKey[1] == newkey[1]
                            || mapKey[1] + 1 == newkey[1]))
                        {
                            result += map[mapKey];
                        }
                    }
                } else if (newkey[0] < newkey[1] && newkey[1] != -grid) //move to the left
                {
                    newkey[1]--;
                    foreach (var mapKey in map.Keys)
                    {
                        if ((mapKey[0] - 1 == newkey[0]
                            || mapKey[0] == newkey[0]
                            || mapKey[0] + 1 == newkey[0]) &&
                            (mapKey[1] - 1 == newkey[1]
                            || mapKey[1] == newkey[1]
                            || mapKey[1] + 1 == newkey[1]))
                        {
                            result += map[mapKey];
                        }
                    }
                } else if (newkey[0] >= newkey[1] && newkey[1] == -grid && newkey[0] != grid) //move down
                {
                    newkey[0]++;
                    foreach (var mapKey in map.Keys)
                    {
                        if ((mapKey[0] - 1 == newkey[0]
                            || mapKey[0] == newkey[0]
                            || mapKey[0] + 1 == newkey[0]) &&
                            (mapKey[1] - 1 == newkey[1]
                            || mapKey[1] == newkey[1]
                            || mapKey[1] + 1 == newkey[1]))
                        {
                            result += map[mapKey];
                        }
                    }
                } else if (newkey[0] > newkey[1] && newkey[0] == grid) //move right
                {
                    newkey[1]++;
                    foreach (var mapKey in map.Keys)
                    {
                        if ((mapKey[0] - 1 == newkey[0]
                            || mapKey[0] == newkey[0]
                            || mapKey[0] + 1 == newkey[0]) &&
                            (mapKey[1] - 1 == newkey[1]
                            || mapKey[1] == newkey[1]
                            || mapKey[1] + 1 == newkey[1]))
                        {
                            result += map[mapKey];
                        }
                    }
                }

                if (grid == newkey[0] && grid == newkey[1])
                {
                    grid++;
                }
                key = newkey;
                map.Add(newkey, result);
            }

            Console.WriteLine("Spiral Memory Part 2: " + result);
            Console.Read();
        }
    }
}
