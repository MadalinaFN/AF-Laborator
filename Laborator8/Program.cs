using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Laborator8
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSort();
            NumerePrime();
            CybersecurityRSA();
        }

        static Stopwatch sw = new Stopwatch();
        private static void CybersecurityRSA()
        {
            Test1();
        }
        private static void ShowRuntime(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine();
            Console.WriteLine($"Runtime " + elapsedTime);
            Console.WriteLine();
        }
        private static void Test1()
        {
            sw.Start();
            BigInteger e, N, d;
            (e, N, d) = GetLock();
            Console.WriteLine($"{e} {N}");
            Console.WriteLine("**************************");
            BigInteger C = GetEncriptedMessage(e, N);
            Console.WriteLine($"C={C}");
            BigInteger mD = GetDecriptedMessage(e, N, d, C);
            Console.WriteLine($"message ={mD}");
            sw.Stop();
            ShowRuntime(sw.Elapsed);
        }
        private static BigInteger GetDecriptedMessage(BigInteger e, BigInteger n, BigInteger d, BigInteger C)
        {
            //m = (C ^ d) % n;
            BigInteger m = BigInteger.ModPow(C, d, n);
            return m;
        }
        private static BigInteger GetEncriptedMessage(BigInteger e, BigInteger n)
        {
            BigInteger m = 1234;
            BigInteger C = BigInteger.ModPow(m, e, n);
            return C;
        }
        private static (BigInteger e, BigInteger N, BigInteger d) GetLock()
        {
            //BigInteger p = 2; BigInteger q = 7;
            //BigInteger p = 7; BigInteger q = 13;
            //BigInteger p = 53; BigInteger q = 59;
            BigInteger p = 10691; BigInteger q = 11813;
            //BigInteger p = 44893; BigInteger q = 46273;
            //BigInteger p = 103993; BigInteger q = 101681;
            BigInteger N = p * q;
            Console.WriteLine($"N={N}");
            BigInteger phiN = (p - 1) * (q - 1);
            Console.WriteLine($"phiN={phiN}");
            BigInteger e = Chose_e(phiN, N);
            Console.WriteLine($"e={e}");
            BigInteger d = Chose_d(e, phiN);
            Console.WriteLine($"d={d}");
            return (e, N, d);
        }
        private static BigInteger Chose_d(BigInteger e, BigInteger phiN)
        {
            // d*e % phiN = 1;
            for (BigInteger i = 2; i < phiN; i++)
            {
                if ((i * e) % phiN == 1) return i;
            }
            return -1;
        }
        private static BigInteger RandomNumber(int n)
        {
            Random rnd = new Random();
            return rnd.Next(2, n);
        }
        /// <summary>
        /// Chose the encription code, with properties:
        /// 1 < encriptionCode < phiN;
        /// e is co-prime with both of N and phiN; 
        /// </summary>
        /// <param name="phiN"></param>
        /// <param name="N"></param>
        /// <returns>The encription code</returns>
        private static BigInteger Chose_e(BigInteger phiN, BigInteger N)
        {
            for (BigInteger i = 2; i < phiN; i++)
            {
                if (coprime(i, phiN) && coprime(i, N)) return i;
            }
            return -1;
        }
        // function to check and prBigInteger if
        // two numbers are co-prime or not
        /// <summary>
        /// Function to check and prBigInteger if two numbers are co-prime or not
        /// Two numbers A and B are said to be Co-Prime if the Greatest Common Divisor of them is 1.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static bool coprime(BigInteger a, BigInteger b)
        {

            BigInteger div = BigInteger.GreatestCommonDivisor(a, b);

            if (div == 1)
                return true;
            else
                return false;
        }

        private static void NumerePrime()
        {
            
        }

        private static void BubbleSort()
        {
            
        }
    }
}
