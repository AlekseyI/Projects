using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainProgram;



namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRezult1()
        {
            int[] inputMass = new int[] { 2, 5, 3, 1, 6, 8, 7, 2, 1, 10 };
            int p = 5;
            double[] expected = new double[] { 2, 5 ,3, 1, 3.4, 5, 6.4, 6.8, 7, 9 };
            double[] getMass = Solver.GetMass(inputMass, p);
            CollectionAssert.AreEquivalent(expected, getMass);
        }

        [TestMethod]
        [ExpectedException(typeof(IsZeroException))]
        public void TestRezultException()
        {
            int[] inputMass = new int[] { 19, 1, 15, 23, 23, 15, 4, 0, 0, 14 };
            int p = 0;
            double[] expected = new double[] { 19, 10, 8, 19, 23, 19, 2, 0, 7, 7 };
            double[] getMass = Solver.GetMass(inputMass, p);
            CollectionAssert.AreEquivalent(expected, getMass);
        }




    }
}
