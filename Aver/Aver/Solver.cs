using System;
using System.Globalization;
using System.Linq;

namespace MainProgram
{
    public class IsZeroException : Exception { }

    public class IsNullMass : Exception { }

    public class Solver
    {
        static public int[] GetRandomMass(int dim)
        {
            Random rndNumber = new Random();
            int[] rndMass = new int[dim];

            for (int i = 0; i < dim; i++)
            {
                rndMass[i] = rndNumber.Next(0, 25);

            }
            return rndMass;
        }

        static public void PrintMass(int[] rndMass)
        {
            if (rndMass == null)
            {
                throw new IsNullMass();
            }

            for (int i = 0; i < rndMass.GetLength(0); i++)
            {

                Console.Write("{0} ", rndMass[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static public void PrintMass(double[] rndMass)
        {
            if (rndMass == null)
            {
                throw new IsNullMass();
            }

            for (int i = 0; i < rndMass.GetLength(0); i++)
            {

                Console.Write("{0} ", rndMass[i].ToString(CultureInfo.InvariantCulture));
            }
            Console.WriteLine();
            Console.WriteLine();
        }

   

        public static double Usred(int[] mass, int i, int p)
        {
            double res = 0;
            if (p == 0)
            {
                throw new IsZeroException();
            }

            if (p > i + 1)
            {
                return mass[i];
            }
            for (int j = i; j >= 0; j--)
            {
                res += mass[j];
            }
            return res / p;
        }

        public static double[] GetMass(int[] mass, int p)
        {
            if (mass != null)
            {
                double[] m = new double[mass.Length];
                for (int i = 0; i < m.Length; i++)
                {
                    m[i] = Solver.Usred(mass, i, p);
                }
                return m;
            }
            throw new IsNullMass();
        }

        public static double[] AttitudeMass(int[] mass, int p)
        {
            if (mass != null)
            {
                return mass.Select(value => p == 0 ? double.NaN : (double)value/ p).ToArray();
            }
            throw new IsNullMass();
        }
    }
}