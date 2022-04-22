using System;
using AwaitableCoroutine;

namespace ACSMExample
{
    sealed class MainSelect
    {
        public Coroutine Run()
        {
            Console.WriteLine("MainSelect started.");
            return Impl();
        }

        private async Coroutine Impl()
        {
            var input = await Utility.ReceiveInputCoroutine();

            switch(input)
            {
                case "game": {
                    var game = new Game();
                    var result = await game.Run();
                    Console.WriteLine("Back to MainSelect. I know you {0}.", result ? "win" : "lose");
                    break;
                }
                case "settings": {
                    var settings = new Settings();
                    await settings.Run();
                    Console.WriteLine("Back to MainSelect.");
                    break;
                }
                case "quit": return;
                case "help": {
                    Console.WriteLine(@"
* game - play the game.
* setting - change options.
* quit - quit application.
* help - You can read what you are reading now.
");
                    break;
                }
                default: {
                    Console.WriteLine($"Unknown command '{input}'.");
                    break;
                }
            }

            // recursive!
            await Impl();
        }
    }
}
