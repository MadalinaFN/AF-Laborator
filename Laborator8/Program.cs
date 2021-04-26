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
            //BubbleSort();
            //Encriptare();
            //CybersecurityRSA();
            //MargeSort();
            //Fibonacci();
        }

        private static void Fibonacci()
        {
            int p;
            float a = 0, b = 1, x, i;
            Console.WriteLine("Introduceti Pozitia: ");
            p = int.Parse(Console.ReadLine());
            int[] v = new int[p];
            if (a == 0 && b == 1)
            {
                for (i = 0; i < v.Length; i++)
                {
                    x = a + b;
                    a = b;
                    b = x;
                }
            }
            if (p == 0) Console.WriteLine("Numarul de pe pozitia {0} este: {1}", p, a);
            else Console.WriteLine("Numarul de pe pozitia {0} este: {1}", p, b);


            Console.ReadKey();
        }

        private static void MargeSort()
        {
            Random rnd = new Random();

            Console.WriteLine("Cate elemente doriti sa aiba vectorul?");
            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];

            for (int i = 0; i < n; i++)
            {
                vector[i] = rnd.Next(-100, 101);
            }

            Console.WriteLine("\nVectorul dat");
            Afisare_Vector(vector);
            Console.ReadKey();


            Sort(vector, 0, vector.Length - 1);


            Console.WriteLine("\nVectorul Sortat");
            Afisare_Vector(vector);
            Console.ReadKey();
        }
        // Interclaseaza doi subvectori ai vectorului initial 
        // Primul subvector este v [left.. middle]
        // Al doilea subvector este v [middle+1..right]
        static void Merge(int[] v, int left, int middle, int right)
        {
            // Calculam lungimea celor doua jumatati 
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Cream vectori temporari
            int[] L = new int[n1]; //vectorul din stanga
            int[] R = new int[n2]; //vectorul din dreapta


            // Copiem informatiile in cei doi vectori temporari

            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = v[left + i];
            for (j = 0; j < n2; ++j)
                R[j] = v[middle + 1 + j];



            // Urmeaza sa interclasam cei doi vectori temporari 

            // indexul initial pentru cei doi subvectori
            i = 0;
            j = 0;

            // Indexul initial al subvectorului interclasat 
            int k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    v[k] = L[i];
                    i++;
                }
                else
                {
                    v[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copiem orice elemente ramase din Left (daca mai exista)
            while (i < n1)
            {
                v[k] = L[i];
                i++;
                k++;
            }

            // Copiem orice elemente ramase din Right (daca mai exista)
            while (j < n2)
            {
                v[k] = R[j];
                j++;
                k++;
            }
        }
        // Functia SORT care sorteaza un vector de la indexul Left la indexul Right folosind functia MERGE() 
        static void Sort(int[] v, int left, int right)
        {
            if (left < right)
            {
                // Aflam punctul de mijloc
                int middle = left + (right - left) / 2;

                // Sortam prima jumatate si a doua jumatate (left / right)
                Sort(v, left, middle);
                Sort(v, middle + 1, right);

                // Interclasam cele doua jumatati
                Merge(v, left, middle, right);
            }
        }
        // Functie pentru afisarea unui vector
        static void Afisare_Vector(int[] v)
        {
            for (int i = 0; i < v.Length; ++i)
                Console.Write($"{v[i]} ");
            Console.WriteLine();
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

        private static void Encriptare()
        {
/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
 
namespace RSAEncryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
 
        }
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
 
                return null;
            }
 
        }
 
        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
 
                return null;
            }
 
        }
 
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;
        private void button1_Click(object sender, EventArgs e)
        {
            plaintext = ByteConverter.GetBytes(txtplain.Text);
            encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
            txtencrypt.Text = ByteConverter.GetString(encryptedtext);
 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] decryptedtex = Decryption(encryptedtext, RSA.ExportParameters(true), false);
            txtdecrypt.Text = ByteConverter.GetString(decryptedtex);
        }
        private void txtplain_TextChanged(object sender, EventArgs e)
        {
 
        }
    }
}*/
        }

        private static void BubbleSort()
        {
            Console.WriteLine("----------BUBBLE SORT----------");
            int[] a = { 4, 10, 0, 6, -3, 5, 1 };
            int t;

            Console.WriteLine("Original array :");
            foreach (int number in a)
                Console.Write(number + " ");
            for (int p = 0; p <= a.Length - 2; p++)
            {

                for (int i = 0; i <= a.Length - 2; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        t = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = t;

                    }
                }
            }
            Console.WriteLine("\n" + "Sorted array :");
            foreach (int number in a)
                Console.Write(number + " ");
            Console.Write("\n");
        }
    }
}
