using AwaitableCoroutine;

namespace ACSMExample
{
    static class Program
    {
        private static void Main()
        {
            var runner = new CoroutineRunner();

            var coroutine = runner.Create(() => new MainSelect().Run());

            while (!coroutine.IsCompleted)
            {
                runner.Update();
                System.Threading.Thread.Sleep(17);
            }
        }
    }
}
