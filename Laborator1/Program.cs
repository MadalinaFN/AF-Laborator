using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rotatie();
            //Suma();

        }

        private static void Suma()
        {
            int n, suma = 0;

            n = int.Parse(Console.ReadLine());

            int[] v = new int[n];

            for (int i = 0; i < n; i++)
            {
                v[i] = i + 1;
            }

            for (int i = 0; i < n; i++)
            {
                suma += v[i];
            }
            Console.WriteLine(suma);
        }

        private static void Rotatie()
        {
            int n, nrRot, j = 0;

            n = int.Parse(Console.ReadLine());
            nrRot = int.Parse(Console.ReadLine());

            int[] v = new int[n];
            int[] v2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                v[i] = i + 1;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();

            if (nrRot == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{v[i]} ");
                }
                Console.WriteLine();
            }

            for (int i = nrRot; i < n; i++)
            {
                v2[j] = v[i];
                j++;
            }

            for (int i = 0; i < nrRot; i++)
            {
                v2[j] = v[i];
                j++;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{v2[i]} ");
            }
            Console.WriteLine();
        }
    }
}
