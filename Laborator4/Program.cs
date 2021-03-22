using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator4
{
    class Program
    {
        static void Main(string[] args)
        {
            //MatriceSpirala1();
            MatriceSpirala2();
        }

        private static void MatriceSpirala2()
        {
            int m, n;

            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());

            int[,] M = new int[n, m];

            /*for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    M[i, j] = rnd.Next(10);
                }
            }*/

            /*for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();*/

            int x = 0, y = 0, counter = 1;

            while (x < n && y < m)
            {
                for (int i = y; i < m; i++)
                {
                    M[x, i] = counter;
                    counter++;
                }
                x++;

                for (int i = x; i < n; i++)
                {
                    M[i, m - 1] = counter;
                    counter++;
                }
                m--;

                if (x < n)
                {
                    for (int i = m - 1; i >= 0; i--)
                    {
                        M[n - 1, i] = counter;
                        counter++;
                    }
                    n--;
                }

                if (y < m)
                {
                    for (int i = n - 1; i >= x; i--)
                    {
                        M[i, y] = counter;
                        counter++;
                    }
                    y++;
                }
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static Random rnd = new Random();

        private static void MatriceSpirala1()
        {
            int m, n;

            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());

            int[,] M = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    M[i, j] = rnd.Next(10);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int x = 0, y = 0;

            while (x < n && y < m)
            {
                for (int i = y; i < m; i++)
                {
                    Console.Write(M[x, i] + " ");
                }
                x++;

                for (int i = x; i < n; i++)
                {
                    Console.Write(M[i, m - 1] + " ");
                }
                m--;

                if (x < n)
                {
                    for (int i = m - 1; i >= 0; i--)
                    {
                        Console.Write(M[n - 1, i] + " ");
                    }
                    n--;
                }

                if (y < m)
                {
                    for (int i = n - 1; i >= x; i--)
                    {
                        Console.Write(M[i, y] + " ");
                    }
                    y++;
                }
            }
            Console.WriteLine();
        }
    }
}
