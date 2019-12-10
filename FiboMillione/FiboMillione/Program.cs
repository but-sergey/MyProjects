using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace FiboMillione
{
    class Program
    {
        public static BigInteger Fib(BigInteger n)
        {
            if (n < 0)
                throw new ArgumentException("The fibo value cannot be negative");
            if (n <= 1)
                return n;

            BigInteger[,] result = { { 1, 0 }, { 0, 1 } };
            BigInteger[,] fiboM = { { 1, 1 }, { 1, 0 } };

            while (n > 0)
            {
                if (n % 2 == 1)
                    Mult2x2Matrix(result, fiboM);
                n /= 2;
                Mult2x2Matrix(fiboM, fiboM);
            }

            return result[1, 0];
        }

        private static void Mult2x2Matrix(BigInteger[,] m, BigInteger[,] n)
        {
            BigInteger a = m[0, 0] * n[0, 0] + m[0, 1] * n[1, 0];
            BigInteger b = m[0, 0] * n[0, 1] + m[0, 1] * n[1, 1];
            BigInteger c = m[1, 0] * n[0, 0] + m[1, 1] * n[0, 1];
            BigInteger d = m[1, 0] * n[0, 1] + m[1, 1] * n[1, 1];

            m[0, 0] = a;
            m[0, 1] = b;
            m[1, 0] = c;
            m[1, 1] = d;
        }

        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var bigInteger = Fib(1_000_000);
            sw.Stop();
            Console.WriteLine("Elapsed milliseconds = {0}, number length = {1} digits", sw.ElapsedMilliseconds, bigInteger.ToString().Length);

            Console.ReadLine();
        }
    }
}
