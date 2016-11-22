using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MainProgram
{



    public class Program
    {

        static void Main(string[] args)
        {

            int p = 5;
            int[] rndMass = new int[] { 2, 5, 3, 1, 6, 8, 7, 2, 1, 10 };

            try
            {
                Solver.PrintMass(rndMass);
                var usred = Solver.GetMass(rndMass, p);
                Solver.PrintMass(usred);
                Solver.PrintMass(Solver.AttitudeMass(rndMass, p));

            }
            catch (Exception e)
            {
                if (e is IsZeroException)
                {
                    Console.WriteLine("p != 0");
                    Solver.PrintMass(Solver.AttitudeMass(rndMass, p));
                }
                else if (e is IsNullMass)
                {
                    Console.WriteLine("Массив не создан");
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }






        }


    }
}
