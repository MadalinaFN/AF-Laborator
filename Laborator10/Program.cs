using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator10
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinearSearch();
            //JumpSearch();
            BucketSort();
        }

        private static void BucketSort()
        {
            
        }

        private static void JumpSearch()
        {
            int[] arr = { 0, 1, 1, 2, 3, 5, 8, 13, 21,
                    34, 55, 89, 144, 233, 377, 610};
            int x = 55;

            // Gasim indexul „x” folosind Jump Search
            int index = jumpSearch(arr, x);

            // Imprimam indexul unde se află „x”
            Console.Write("Numarul " + x +
                                " se afla pe pozitia " + index);
            Console.WriteLine();
        }
        public static int jumpSearch(int[] arr, int x)
        {
            int n = arr.Length;

            // Gasirea dimensiunii blocului care trebuie sarit
            int step = (int)Math.Floor(Math.Sqrt(n));

            // Gasirea blocului unde este elementul
            // prezent (daca este prezent)
            int prev = 0;
            while (arr[Math.Min(step, n) - 1] < x)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            // Efectuarea unei cautări liniare pentru x în bloc
            // incepand cu prev
            while (arr[prev] < x)
            {
                prev++;

                // Daca am ajuns la urmatorul bloc sau la sfarsitul
                // matricei si elementul nu este prezent.
                if (prev == Math.Min(step, n))
                    return -1;
            }

            // Daca elementul este gasit
            if (arr[prev] == x)
                return prev;

            return -1;
        }

        private static void LinearSearch()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int x = 10;

            // Apelarea functiei
            int result = search(arr, x);
            if (result == -1)
                Console.WriteLine(
                    "Elementul nu este prezent in tablou");
            else
                Console.WriteLine("Elementul este prezent in index "
                                + result);
        }
        public static int search(int[] arr, int x)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == x)
                    return i;
            }
            return -1;
        }
    }
}
