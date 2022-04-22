using System;

using AwaitableCoroutine;

namespace ACSMExample
{
    sealed class Game
    {
        public async Coroutine<bool> Run()
        {
            Console.WriteLine("Enter your name.");
            var name = await Utility.ReceiveInputCoroutine();

            Console.WriteLine($"Hello, {name}. Game started!");

            var randomValue = new System.Random().Next();

            await Coroutine.DelayCount(30)
                .UntilCompleted(() =>
                    Coroutine.DelayCount(5)
                        .OnCompleted(() => Console.WriteLine("."))
                );

            var result = randomValue % 2 == 0;

            if (result)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }

            return result;
        }
    }
}