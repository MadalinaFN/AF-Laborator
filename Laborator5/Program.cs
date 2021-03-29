using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator5
{
    class Program
    {
        static void Main(string[] args)
        {
            Recursivitate();
        }

        private static void Recursivitate()
        {
            print("Madalina", 0);
            Console.WriteLine();
        }

        private static void print(string str, int index)
        {
            if (index == str.Length)
            {
                return;
            }
            Console.Write(str[index]);
            print(str, index + 1);

            //print(str, index + 1);
            //Console.Write(str[index]);
        }
    }
}
