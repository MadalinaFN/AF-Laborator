using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolare
{
    class Program
    {
        // Daca x apartine vectorului, atunci returneaza pozitia lui x, alfel returneaza -1
        static int interpolationSearch(int[] arr, int lo, int hi, int x)
        {
            int pos;

            // De la inceput vectorul e sortat, x trebuie sa apartina intervalului
            if (lo <= hi && x >= arr[lo] && x <= arr[hi])
            {
                // Aflam pozitia prin formula
                pos = lo + (((hi - lo) / (arr[hi] - arr[lo])) * (x - arr[lo]));

                // Conditia de pozitie tinta
                if (arr[pos] == x)
                    return pos;

                // Daca x este mai mare, atunci x este la dreapta
                if (arr[pos] < x)
                    return interpolationSearch(arr, pos + 1, hi, x);

                // Daca x este mai mic, atunci x este la stanga
                if (arr[pos] > x)
                    return interpolationSearch(arr, lo, pos - 1, x);
            }
            return -1;
        }

        public static void Main()
        {
            int[] arr = new int[] { 10, 12, 13, 16, 18, 19, 20, 21, 22, 23, 24, 33, 35, 42, 47 };

            // Elementul cautat
            int x = 18;
            int n = arr.Length;
            int index = interpolationSearch(arr, 0, n - 1, x);

            // Daca elementul a fost gasit
            if (index != -1)
                Console.WriteLine("Elementul a fost gasit pe pozitia " + index);
            else
                Console.WriteLine("Elementul nu a fost gasit in vector");
        }
    }
}
