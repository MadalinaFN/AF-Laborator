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
            //ExponentialSearch();
            //SublistSearch();
        }
        class Node
        {
            public int data;
            public Node next;
        };

        static bool findList(Node first, Node second)
        {
            Node ptr1 = first, ptr2 = second;

            if (first == null && second == null)
                return true;

            if (first == null || (first != null && second == null))
                return false;

            while (second != null)
            {
                ptr2 = second;

                while (ptr1 != null)
                {
                    if (ptr2 == null)
                        return false;

                    else if (ptr1.data == ptr2.data)
                    {
                        ptr1 = ptr1.next;
                        ptr2 = ptr2.next;
                    }

                    else break;
                }

                if (ptr1 == null)
                    return true;

                ptr1 = first;

                second = second.next;
            }
            return false;
        }

        static Node newNode(int key)
        {
            Node temp = new Node();
            temp.data = key;
            temp.next = null;
            return temp;
        }
        private static void SublistSearch()
        {
            //a : 1->2->3->4
            //b : 1->2->1->2->3->4

            Node a = newNode(1);
            a.next = newNode(2);
            a.next.next = newNode(3);
            a.next.next.next = newNode(4);


            Node b = newNode(1);
            b.next = newNode(2);
            b.next.next = newNode(1);
            b.next.next.next = newNode(2);
            b.next.next.next.next = newNode(3);
            b.next.next.next.next.next = newNode(4);


            if (findList(a, b) == true)
                Console.Write("LIST FOUND");
            else
                Console.Write("LIST NOT FOUND");
        }

        private static void ExponentialSearch()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int n = arr.Length;
            int x = 10;
            int result = exponentialSearch(arr, n, x);
            if (result == -1)
                Console.Write($"Elementul {x} nu există în vector");
            else
                Console.Write($"Elementul {x} există în vector pe pozitia {result}");
        }
        //Metodă care returnează poziția primei apariții a lui x în vector
        static int exponentialSearch(int[] arr, int n, int x)
        {
            //verificare dacă x se află pe prima poziție
            if (arr[0] == x)
                return 0;

            //Se caută intervalul pe care trebuie făcută căutarea binară prin dublarea
            //repetată a lui i
            int i = 1;
            while (i < n && arr[i] <= x)
                i = i * 2;

            //Apelarea metodei pentru căutare binară pentru intervalul găsit
            return binarySearch(arr, i / 2, Math.Min(i, n - 1), x);
        }

        //Metodă recursivă pentru căutarea binară.
        //Returnează locația lui x în vector dacă există
        //În caz că nu există returnează -1
        static int binarySearch(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                //Se calculează mijlocul
                int mid = l + (r - l) / 2;

                //Dacă elementul se află în mijloc
                if (arr[mid] == x)
                    return mid;
                //Dacă elementul este mai mic decât mijlocul, acesta se poate afla
                //doar în jumătatea inferioară(în stânga)
                if (arr[mid] > x)
                    return binarySearch(arr, l, mid - 1, x);

                //Alfel, elementul poate fi doar în jumătatea superioară(în dreapta)
                return binarySearch(arr, mid + 1, r, x);
            }

            //Dacă elementul nu este găsit în vector
            return -1;
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
