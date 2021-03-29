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
            //Recursivitate();
            SumaRecursiva();
        }

        private static void SumaRecursiva()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Suma(n, 1));
        }

        private static int Suma(int n, int currentnumber)
        {
            if (currentnumber == n)
            {
                return currentnumber;
            }
            return Suma(n, currentnumber + 1) + currentnumber;
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
