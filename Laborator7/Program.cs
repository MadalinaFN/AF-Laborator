﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator7
{
    class Program
    {
        static void Main(string[] args)
        {
            ProblemaReginelor();
        }

        private static void ProblemaReginelor()
        {
            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            int[] row = new int[N];
            bool[] vis = new bool[N];
            Generate(0, N, row, vis);
            Console.WriteLine();
        }

        static int count = 1;
        static void Generate(int k, int n, int[] row, bool[] vis)
        {
            if (k >= n)
            {
                bool ok = true;
                for (int i = 0; i < n - 1; i++)
                    for (int j = i + 1; j < n; j++)
                        if (Math.Abs(i - j) == Math.Abs(row[i] - row[j]))
                        {
                            ok = false;
                            break;
                        }
                if (ok)
                {
                    Console.Clear();
                    Console.WriteLine($"Solution {count}:");
                    View(n, row);
                    count++;
                    Console.ReadKey();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!vis[i])
                    {
                        vis[i] = true;
                        row[k] = i;
                        Generate(k + 1, n, row, vis);
                        vis[i] = false;
                    }
                }
            }
        }

        static void View(int size, int[] row)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j % 2 == 0 && i % 2 != 0 || j % 2 != 0 && i % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.BackgroundColor = ConsoleColor.Gray;


                    if (j == row[i])
                        Console.Write($" Q ");
                    else
                        Console.Write("   ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
