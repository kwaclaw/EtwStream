using System.Threading;

namespace EtwStream
{
    // shim of EtwStreamService
    public static class EtwStreamService
    {
        static readonly CancellationTokenSource source = new CancellationTokenSource();

        public static CancellationToken TerminateToken { get; }
        public static ISubscriptionContainer Container { get; }

        static EtwStreamService()
        {
            TerminateToken = source.Token;
            Container = new SubscriptionContainer();
        }

        public static void CompleteService()
        {
            source.Cancel();
            (Container as SubscriptionContainer)?.Dispose();
        }
    }
}
