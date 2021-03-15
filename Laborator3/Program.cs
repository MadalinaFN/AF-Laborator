using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3
{
    class Program
    {
        static void Main(string[] args)
        {
            NumeleTransformate();
        }

        private static void NumeleTransformate()
        {
            string name = "BitStone";
            Console.WriteLine(name);
            reverse(name);
        }

        static void reverse(string name)
        {
            int count = 1, k = 0;

            List<int> list = new List<int>();

            for (int i = 1; i < name.Length; i++)
            {
                if (char.IsUpper(name[i]))
                {
                    list.Add(count);
                    count = 1;
                }
                else
                {
                    count++;
                }
            }
            list.Add(count);

            char[] v = name.ToCharArray();
            Array.Reverse(v);

            for (int i = list.Count - 1; i >= 0; i--)
            {
                v[k] = char.ToUpper(v[k]);
                k++;
                for (int j = 1; j < list[i]; j++)
                {
                    v[k] = char.ToLower(v[k]);
                    k++;
                }
            }

            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i]);
            }
            Console.WriteLine();
        }
    }
}
