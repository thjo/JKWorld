using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCodes
{
    class BreakfastAsync
    {
        public async Task MakeBreakfast()
        {
            Console.WriteLine($"MakeBreakfastTask's Id: {Task.CurrentId}");
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready.");

            var eggsTask = Task.Run(() => FryEggsAsync(2));
            Console.WriteLine($"eggsTask's Id: {eggsTask.Id}");
            var baconTask = FryBaconAsync(3);
            Console.WriteLine($"baconTask's Id: {baconTask.Id}");
            var toastTask = MakeToastWithButterAndJamAsync(2);
            Console.WriteLine($"toastTask's Id: {toastTask.Id}");
            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }


        private Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
        private async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            
            return new Egg();
        }
        private async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }
        private async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }
        private async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }
        private void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
    }

    class Coffee { }
    class Egg { }
    class Bacon { }
    class Toast { }
    class Juice { }
}
