using System;

using AwaitableCoroutine;

namespace ACSMExample
{
    sealed class Settings
    {
        public async Coroutine Run()
        {
            Console.WriteLine("Setting started.");
            Console.WriteLine("Wait 60 count");
            await Coroutine.DelayCount(30, Console.WriteLine);
        }
    }
}