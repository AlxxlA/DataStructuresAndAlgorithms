using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.PlusOneMultipleOne
{
    class PlusOneMultipleOne
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            if (m == 1)
            {
                Console.WriteLine(n);
                return;
            }

            var sums = new LinkedList<int>();
            var result = new LinkedList<int>();

            int count = 0;

            while (count < m)
            {
                result.AddLast(n + 1);
                result.AddLast(2 * n + 1);
                result.AddLast(n + 2);

                sums.AddLast(n + 1);
                sums.AddLast(2 * n + 1);
                sums.AddLast(n + 2);

                count += 3;

                n = sums.First.Value;
                sums.RemoveFirst();
            }

            while (m <= count)
            {
                sums.RemoveLast();
                count--;
            }


            Console.WriteLine(sums.Last.Value);

        }
    }
}
