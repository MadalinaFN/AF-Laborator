using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Partial_1
{
    class Program
    {
        static int[] v;
        static void load()
        {
            TextReader reader = new StreamReader(@"../../ex01.txt");

            string[] line = reader.ReadLine().Split(' ');
            v = new int[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write($"{line[i]} ");
                v[i] = int.Parse(line[i]);
            }
            Console.WriteLine();
            reader.Close();
        }

        static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void result(int[] res)
        {
            TextWriter writer = new StreamWriter(@"../../ex01.out");

            for (int i = 0; i < res.Length; i++)
            {
                Console.Write($"{res[i]} ");
                writer.Write($"{res[i]} ");
            }
            writer.Close();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            load();

            int temp, fib, count, idx = 0; ;
            int[] rez = new int[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                fib = 0;
                temp = 0;
                count = 2;
                while ((fib = Fibonacci(count)) <= v[i])
                {
                    temp = fib;
                    count++;
                }
                if (Math.Abs(v[i] - temp) < Math.Abs(v[i] - fib))
                {
                    rez[idx] = temp - v[i];
                }
                else
                {
                    rez[idx] = fib - v[i];
                }
                idx++;
            }
            result(rez);
        }
    }
}
