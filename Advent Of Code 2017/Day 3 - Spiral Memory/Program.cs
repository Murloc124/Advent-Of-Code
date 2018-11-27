using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3___Spiral_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = 347991;
            var grid = 1;
            var result = 0;

            while ((grid * grid) <= data)
            {
                grid = grid + 2;
            }

            if (data - 591 < )


            Console.WriteLine("Spiral Memory Part 1: " + result);
            Console.Read();
        }
    }
}
