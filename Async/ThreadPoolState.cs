using System.Threading;

namespace Async
{
    public class ThreadState
    {
        public AutoResetEvent WaitHandle { get; set; }
        public int Factorial { get; set; }

        public ThreadState()
        {
            WaitHandle = new AutoResetEvent(false);            
        }
    }
}
