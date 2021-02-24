using System.Diagnostics;

namespace PractikaASP.Infrastructure
{
    public class UptimeService
    {
        private Stopwatch timer;

        public UptimeService()
        {
            timer = Stopwatch.StartNew();
        }
        public long Update() => timer.ElapsedMilliseconds;
    }
}
