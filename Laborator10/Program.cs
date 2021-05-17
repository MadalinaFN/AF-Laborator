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
            //BucketSort();
        }

        private static void BucketSort()
        {
            int[] row = new int[] { 44, 98, 2, 31, 55, 26, 59, 20, 13, 68 };

            Console.WriteLine("\nSirul initial");

            for (int i = 0; i < row.Length; i++)
            {
                Console.Write(row[i] + "  ");

            }

            Console.WriteLine("\n\nSirul Sortat");

            List<int> inOrder = Sort(row);

            for (int i = 0; i < inOrder.Count; i++)
            {
                Console.Write(inOrder[i] + "  ");
            }

            Console.ReadLine();
        }
        public static List<int> Sort(params int[] x)
        {
            List<int> sortList = new List<int>();

            int n = 10;

            //Construim bucket-urile
            List<int>[] buckets = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i = 0; i < x.Length; i++)
            {
                int k = (x[i] / n);
                buckets[k].Add(x[i]);
            }

            //Sortam fiecare bucket si il adaugam in lista
            for (int i = 0; i < n; i++)
            {
                List<int> temp = InsertionSort(buckets[i]);
                sortList.AddRange(temp);
            }
            return sortList;
        }

        //insertare sort
        public static List<int> InsertionSort(List<int> imput)
        {
            for (int i = 1; i < imput.Count; i++)
            {
                int value = imput[i];
                int pointer = i - 1;

                while (pointer >= 0)
                {
                    if (value < imput[pointer])
                    {
                        imput[pointer + 1] = imput[pointer];
                        imput[pointer] = value;
                    }
                    else break;
                }
            }

            return imput;
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
