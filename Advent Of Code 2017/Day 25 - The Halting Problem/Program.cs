using System;
using System.Collections.Generic;

namespace Day_25___The_Halting_Problem
{
    class Program
    {
        private static List<int> data;
        private static int amount;
        private static int index;

        static void Main(string[] args)
        {
            data = new List<int>();
            data.Add(0);
            index = 0;
            amount = 0;

            goto A;

            A:
            {
                if (Check())
                {
                    if (data[index] == 0)
                    {
                        data[index] = 1;
                        index++;
                        goto B;
                    }
                    else
                    {
                        data[index] = 0;
                        index--;
                        goto E;
                    }
                } else
                {
                    goto G;
                }
            }

            B:
            {
                if (Check())
                {
                    if (data[index] == 0)
                    {
                        data[index] = 1;
                        index--;
                        goto C;
                    }
                    else
                    {
                        data[index] = 0;
                        index++;
                        goto A;
                    }
                } else
                {
                    goto G;
                }
            }

            C:
            {
                if (Check())
                {
                    if (data[index] == 0)
                    {
                        data[index] = 1;
                        index--;
                        goto D;
                    }
                    else
                    {
                        data[index] = 0;
                        index++;
                        goto C;
                    }
                } else
                {
                    goto G;
                }
            }

            D:
            {
                if (Check())
                {
                    if (data[index] == 0)
                    {
                        data[index] = 1;
                        index--;
                        goto E;
                    }
                    else
                    {
                        data[index] = 0;
                        index--;
                        goto F;
                    }
                }
                else
                {
                    goto G;
                }
            }

            E:
            {
                if (Check())
                {
                    if (data[index] == 0)
                    {
                        data[index] = 1;
                        index--;
                        goto A;
                    }
                    else
                    {
                        data[index] = 1;
                        index--;
                        goto C;
                    }
                } else
                {
                    goto G;
                }
            }

            F:
            {
                if (Check())
                {
                    if (data[index] == 0)
                    {
                        data[index] = 1;
                        index--;
                        goto E;
                    }
                    else
                    {
                        data[index] = 1;
                        index++;
                        goto A;
                    }
                }
                else
                {
                    goto G;
                }
            }

            G:
            {
                var result = 0;
                foreach (var entry in data)
                {
                    result += entry;
                }

                Console.WriteLine("The Halting Problem Part 1: " + result);
                Console.ReadLine();
            }
        }

        private static bool Check()
        {
            if (amount == 12386363)
            {
                return false;
            }
            amount++;
            if (index < 0)
            {
                data.Insert(0, 0);
                index++;
            }
            if (index >= data.Count)
            {
                data.Add(0);
            }
            return true;
        }
    }
}
