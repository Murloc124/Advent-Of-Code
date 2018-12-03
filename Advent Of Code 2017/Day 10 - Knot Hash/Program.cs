using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10___Knot_Hash
{
    class Program
    {
        private static List<int> Rope = new List<int>(new int[] {0, 1, 2, 3, 4 });
        private static List<int> Lengths = new List<int>(new int[] {3, 4 ,1, 5});
        private static int CurrentPosition = 0;

        static void Main(string[] args)
        {
            foreach (var length in Lengths)
            {
                var selectedValues = Rope.GetRange(CurrentPosition, length);
            }
        }
    }
}
