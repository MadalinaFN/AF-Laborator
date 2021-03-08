using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator2
{
    class Program
    {
        static void Main(string[] args)
        {
            //MaxAbsDif();
        }

        static Random rnd = new Random();

        private static void MaxAbsDif()
        {
            int max = 0;

            int n = int.Parse(Console.ReadLine());

            int[] v = new int[n];

            for (int i = 0; i < n; i++)
            {
                //v[i] = rnd.Next(10);
                v[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int aux = f(v, i, j);

                    if (aux > max)
                    {
                        max = aux;
                    }
                }
            }
            Console.WriteLine(max);
        }

        private static int f(int[] v, int i, int j)
        {
            return Math.Abs(v[i] - v[j]) + Math.Abs(i - j);
        }
    }
}
