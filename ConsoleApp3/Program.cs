using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n, k, n1;
            double z;
            double[,] A = new double[50,50];
            double[] B = new double[50];
            double[] eps =new double[50];
            double[] X = new double[50];
            double[] et = new double[50];
            Console.WriteLine( "Vvedite razmernost matrici: ");
            string n2 = Console.ReadLine();
            n1 = Convert.ToInt32(n2);
            Console.WriteLine ( "Vvedite " + n1 + " strok po " + n1 + " chisel:");
            for (i = 0; i < n1; i++)
                for (k = 0; k < n1; k++)
                    A[i , k] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine ( "Matrix A:" );
            for (i = 0; i < n1; i++)
            {
                for (k = 0; k < n1; k++)
                {
                    Console.Write("{0}\t", A[i, k]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine ( "Vvedite " + n1 + " chisel:" );
            for (i = 0; i < n1; i++)
            {
                B[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine( "Matrix B:" );
            for (i = 0; i < n1; i++)
            {
                Console.WriteLine(B[i]);
            }

            n = n1 - 1;
            eps[0] = -A[0,1] / A[0,0];
            et[0] = B[0] / A[0,0];

            for (i = 1; i < n; i++)
            {
                z = A[i,i] + A[i, i - 1] * eps[i - 1];
                eps[i] = -A[i, i + 1] / z;
                et[i] = (B[i] - A[i, i - 1] * et[i - 1]) / z;
            }

            X[n] = (B[n] - A[n, n - 1] * et[n - 1]) / (A[n, n] + A[n, n - 1] * eps[n - 1]);

            for (i = n - 1; i >= 0; i--)
            {
                X[i] = eps[i] * X[i + 1] + et[i];
            }

            Console.WriteLine( "Matrix X:" );
            for (i = 0; i < n1; i++)
            {
                Console.WriteLine(X[i]);
            }

            Console.ReadLine();

        }
    }
}
