using System;
using System.Threading;
using System.Threading.Tasks;

namespace asyncawait
{
    class Program
    {
        static void Main(string[] args)
        {
            callMethod();
            Console.ReadKey();
            //Results
            //Method 2
            // Method 1
            // Method 2
            // Method 1
            // Method 1
            // Method 2
            // Method 1
            // Method 2
            // Method 2
            // Method 1
            // Method 1
            // Method 1
            // Method 1
            // Method 1
            // Method 1
            //Total count is 10
 
        }

        public static async void callMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = 0;
            Method3(count);
            count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(" Method 1");
                    Thread.Sleep(1000);
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" Method 2");
                Thread.Sleep(1000);
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
}
