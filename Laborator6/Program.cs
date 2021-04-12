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
            Hanoi();
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
