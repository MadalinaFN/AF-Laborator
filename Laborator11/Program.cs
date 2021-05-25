using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator11
{
    public static class ExtensionMethods
    {
        public static void Print<T>(this T[] instance)
        {
            foreach (var x in instance)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="start">Starting index</param>
        /// <param name="end">Ending index</param>
        public static void QuickSort(this int[] instance, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = Partition(start, end);

                instance.QuickSort(start, partitionIndex - 1);
                instance.QuickSort(partitionIndex + 1, end);
            }

            int Partition(int left, int right)
            {
                if (left + 1 == right)                              //    In cazul in care in partitia
                {                                                   //    curent se gasesc doar doua numere,
                    if (instance[left] > instance[right])           //    sunt comparate cele dou numere
                    {                                               //    fara a se executa restul codului
                        Swap(left, right);                          //    
                        return left;                                //
                    }                                               //
                    return right;                                   //
                }                                                   //      

                int pivot = MedianOfThree();                        //    pivotul cu care se comapra elementele din partitia curenta

                int low = left;                                     //    indexul elementelor din partea stanga a pivotului mai mari decat acesta
                int high = right - 1;                               //    indexul elementelor din partea dreapta a pivotului mai mici decat acesta

                while (low < high)                                  //    loop ul se executa cat timp indexul elementelor din partea stanga este mai mic decat indexul elementelor din partea dreapta
                {
                    while (instance[low] <= pivot && low <= high)   //    Cauta urmatorul numar din partea
                    {                                               //    stanga a pivotului mai mare decat pivotul
                        low++;                                      //    cat timp indexul din stanga este mai mic decat
                    }                                               //    cel din dreapta
                    while (instance[high] > pivot && low < high)    //    Cauta urmatorul numar din partea
                    {                                               //    dreapta a pivotului mai mic decat pivotul
                        high--;                                     //    cat timp indexul din stanga este mai mic decat
                    }                                               //    cel din dreapta
                    if (low < high)                                 //    Daca indexul din stanga este mai
                    {                                               //    mic decat cel din dreapta,
                        Swap(low, high);                            //    cele doua numere se interschimba
                    }                                               //
                }
                Swap(low, right);                                   //    Pivotul este plasat in locul potrivit
                return low;                                         //    in array si se returneaza indexul acestuia


                void Swap(int index1, int index2)
                {
                    int temp = instance[index1];
                    instance[index1] = instance[index2];
                    instance[index2] = temp;
                }

                int MedianOfThree()
                {
                    int medianIndex = ((right - left) / 2) + left;

                    if (instance[left] < instance[medianIndex])
                    {
                        if (instance[right] < instance[left])
                        {
                            Swap(left, right);
                        }
                        else if (instance[right] > instance[medianIndex])
                        {
                            Swap(medianIndex, right);
                        }
                    }
                    else
                    {
                        if (instance[right] < instance[medianIndex])
                        {
                            Swap(medianIndex, right);
                        }
                        else if (instance[right] > instance[left])
                        {
                            Swap(left, right);
                        }
                    }

                    return instance[right];
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //QuickSort();
            //SieveOfAtkin();
        }

        private static void SieveOfAtkin()
        {
            int limit = 20;
            SieveOfAtkin1(limit);
        }
        static int SieveOfAtkin1(int limit)
        {
            // 2 si 3 sunt stiute ca nr prime
            if (limit > 2)
                Console.Write(2 + " ");

            if (limit > 3)
                Console.Write(3 + " ");

            // Initialise the sieve array with
            // false values
            bool[] sieve = new bool[limit];

            for (int i = 0; i < limit; i++)
                sieve[i] = false;

            /* Marcam Sita [n] este adevărata dacă unul dintre
            următoarele sunt adevărate:
            a) n = (4 * x * x) + (y * y) are număr impar
               de soluții, adică, există
               număr impar de perechi distincte
               (x, y) care satisfac ecuația
               și n% 12 = 1 sau n% 12 = 5.
            b) n = (3 * x * x) + (y * y) are număr impar
               de soluții și n% 12 = 7
            c) n = (3 * x * x) - (y * y) are număr impar
               de soluții, x> y și n% 12 = 11 */
            for (int x = 1; x * x < limit; x++)
            {
                for (int y = 1; y * y < limit; y++)
                {

                    // Partea principală a sitei Atkin
                    int n = (4 * x * x) + (y * y);
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))

                        sieve[n] ^= true;

                    n = (3 * x * x) + (y * y);
                    if (n <= limit && n % 12 == 7)
                        sieve[n] ^= true;

                    n = (3 * x * x) - (y * y);
                    if (x > y && n <= limit && n % 12 == 11)
                        sieve[n] ^= true;
                }
            }

            // Marcați toți multiplii de pătrate ca
            // non-prime
            for (int r = 5; r * r < limit; r++)
            {
                if (sieve[r])
                {
                    for (int i = r * r; i < limit;
                         i += r * r)
                        sieve[i] = false;
                }
            }

            // Imprimați primele folosind sita[]
            for (int a = 5; a < limit; a++)
                if (sieve[a])
                    Console.Write(a + " ");
            return 0;
        }

        private static void QuickSort()
        {
            int[] array = { 1, 2, -3, 5, -387, 0, 7, 3, 345, 8, 4, -8, 3, 0, 1, };

            Console.WriteLine("Original array:");
            array.Print();
            Console.WriteLine();

            array.QuickSort(0, array.Length - 1);

            Console.WriteLine("Sorted array:");
            array.Print();
            Console.WriteLine();
        }
    }
}
