using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hanoi();
            Fibonacci();
        }

        private static void Fibonacci()
        {
            Console.WriteLine("Introduceti numarul pe care doriti sa-l aflati");
            int n = int.Parse(Console.ReadLine());
            int fib = fibon(n);
            Console.WriteLine($"Al {n}-lea numar Fibonacci este {fib}");
        }

        public static int fibon(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return fibon(n - 1) + fibon(n - 2);
        }

        private static void Hanoi()
        {
            hanoi("source", "dest", "aux", 4);
        }

        static void hanoi(string source, string dest, string aux, int n)
        {
            if (n == 1)
            {
                Console.WriteLine(source + " -> " + dest);
            }
            else
            {
                hanoi(source, aux, dest, n - 1);
                Console.WriteLine(source + " -> " + dest);
                hanoi(aux, dest, source, n - 1);
            }
        }
    }
}
