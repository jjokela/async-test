﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var task = Task.Factory.StartNew<int>(SlowOperation);

            var task = SlowOperationAsync();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Slow operation result: {0}", task.Result);
            Console.WriteLine("Main complete on {0}", Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();
        }

        static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(5000);
            Console.WriteLine("Slow operation complete on {0}", Thread.CurrentThread.ManagedThreadId);

            return 42;
        }

        static int SlowOperation()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("Slow operation complete on {0}", Thread.CurrentThread.ManagedThreadId);

            return 42;
        }
    }
}
