using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.CokiSkoki
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var buildings = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentMax = buildings[buildings.Length - 1];
            var currentMaxJumps = 0;

            var jumps = new int[buildings.Length];

            for (int i = buildings.Length - 1; i >= 0; i--)
            {
                var current = buildings[i];
                if (currentMax < current)
                {
                    currentMax = current;
                    currentMaxJumps = 0;
                }
                else if (current < currentMax)
                {

                }
            }


        }
    }
}
