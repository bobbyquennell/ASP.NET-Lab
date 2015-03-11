using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SlowOperation();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Slow operation result:{0}", result);
            Console.WriteLine("Main complete on {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }

        private static object SlowOperation()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("Slow operation complete on {0}",Thread.CurrentThread.ManagedThreadId);
            return 42;
        }
    }
}
