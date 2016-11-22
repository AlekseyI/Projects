using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Deadlock
{
    class  Program
    {
        private readonly object _object1 = new object();
        private readonly object _object2 = new object();

        public void Func1()
        {
            while (true)
            {
                lock (_object1)
                {
                    Thread.Sleep(1);
                    lock (_object2)
                    {
                        Console.WriteLine(1);
                    }
                }
            }
            
        }

        public void Func2()
        {
            while (true)
            {
                lock (_object2)
                {
                    Thread.Sleep(1);
                    lock (_object1)
                    {
                        Console.WriteLine(2);
                    }
                }
            }
            

        }

        static void Main()
        {
            var program = new Program();

            var thread1 = new Thread((ThreadStart)program.Func1);
            var thread2 = new Thread((ThreadStart)program.Func2);

            thread1.Start();
            thread2.Start();


        }


    }
}
