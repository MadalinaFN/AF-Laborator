using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Partial_2
{
    class Program
    {
        static int n;
        static int[,] mat;
        static void load(string fileName)
        {
            TextReader dataLoad = new StreamReader(fileName);
            List<string> data = new List<string>();
            string buffer;
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                data.Add(buffer);
            }
            n = data.Count;
            mat = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                List<int> linie = data[i].Split(' ').Select(Int32.Parse).ToList();
                for (int j = 0; j < n; j++)
                {
                    mat[i, j] = linie[j];
                }
            }
        }

        static void output(int[,] mat, int n)
        {
            using (StreamWriter outputFile = new StreamWriter(@"..\..\ex02.out", true))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        outputFile.Write(mat[i, j] + " ");
                    }
                    outputFile.WriteLine();
                }
                outputFile.WriteLine();
            }
        }

        static void computeMat(int[,] mat, int n)
        {
            int[,] newMat = new int[n / 2, n / 2];
            int ii = 0, jj = 0;
            if (n == 1)
            {
                return;
            }
            for (int i = 0; i < n; i = i + 2)
            {
                jj = 0;
                for (int j = 0; j < n; j = j + 2)
                {
                    newMat[ii, jj] = mat[i, j] * mat[i + 1, j + 1] - mat[i, j + 1] * mat[i + 1, j];
                    jj++;
                }
                ii++;
            }
            output(newMat, n / 2);
            computeMat(newMat, n / 2);
        }

        static void Main(string[] args)
        {
            load(@"..\..\ex02.in");
            output(mat, n);
            computeMat(mat, n);
        }
    }
}
