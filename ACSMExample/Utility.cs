using System;
using System.IO;
using System.Threading.Tasks;

using AwaitableCoroutine;

namespace ACSMExample
{
    static class Utility
    {
        public static async Task<string?> ReadLineAsync()
        {
            using var s = Console.OpenStandardInput();
            using var sr = new StreamReader(s);
            return await sr.ReadLineAsync();
        }

        public static Coroutine<string?> ReceiveInputCoroutine()
        {
            Console.Write("> ");
            return Coroutine.AwaitTask<string?>(ReadLineAsync());
        }
    }
}
