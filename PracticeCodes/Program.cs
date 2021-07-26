using System;
using System.Threading.Tasks;

namespace PracticeCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BreakfastAsync breakfast = new BreakfastAsync();
            Console.WriteLine($"currentTask's Id: {Task.CurrentId}");
            breakfast.MakeBreakfast();

            Console.WriteLine("With await.");
            Console.ReadLine();
        }
    }
}
