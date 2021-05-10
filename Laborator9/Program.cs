using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator9
{
    class Program
    {
        static void Main(string[] args)
        {
            //CiurulLuiEratostene();
            //InsertionSort();
        }

        private static void InsertionSort()
        {
            Console.WriteLine("**********INSERTION SORT********** ");
            Console.WriteLine();
            int[] array = { 5, 1, 6, 2, 4, 3 };
            Console.WriteLine("Vectorul initial: ");
            printArray(array, array.Length);
            Console.WriteLine();
            insertionSort(array, array.Length);
            Console.ReadKey();
        }
        private static void insertionSort(int[] array, int length)
        {
            int i, j, insertedElement;
            for (i = 1; i < length; i++)
            {
                insertedElement = array[i]; ///salvam elementul pe care vrem sa il inseram
                j = i - 1;
                while (j >= 0 && array[j] > insertedElement)
                {
                    array[j + 1] = array[j]; /// mutam elementul mai la dreapta daca este mai mare decat cel pec are vrem sa il inseram
                    j--;
                }
                array[j + 1] = insertedElement;
                if (i != length - 1)
                    Console.WriteLine("Vectorul dupa urmatoarea iteratie: ");
                else
                    Console.WriteLine("Vectorul dupa ultima iteratie, gata SORTAT: ");

                printArray(array, length);
            }

        }
        private static void printArray(int[] array, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        private static void CiurulLuiEratostene()
        {
            Console.WriteLine("**********Sieve of Eratosthenes********** ");
            Console.WriteLine();
            Console.Write("Enter a value for n: ");
            n = Int32.Parse(Console.ReadLine());
            array = new int[n + 1]; // In C# elementele unui array automat sunt initializate cu 0

            ComputePrimeNumbers();
            PrintPrimeNumbers();

            Console.ReadKey();
        }
        public static int n { get; set; }
        public static int[] array { get; set; }
        static void PrintPrimeNumbers()
        {
            Console.Write($"The prime numbers up until {n} are: ");

            for (int i = 2; i <= array.Length; i++)
            {
                if (array[i] == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
        static void ComputePrimeNumbers()
        {
            array[0] = 1;
            array[1] = 1;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (array[i] == 0)
                {
                    for (int j = 2; j <= n / i; j++)
                    {
                        array[i * j] = 1;
                    }
                }
            }
        }
    }
}
