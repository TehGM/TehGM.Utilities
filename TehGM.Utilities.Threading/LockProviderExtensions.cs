using System.Threading;
using System.Threading.Tasks;

namespace TehGM.Utilities
{
    /// <summary>A set of extensions for <see cref="ILockProvider"/>.</summary>
    public static class LockProviderExtensions
    {
        /// <summary>Asynchronously waits until the SemaphoreSlim is free.</summary>
        /// <param name="provider">Lock provider.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the wait operation.</param>
        /// <returns>Task which will be finished when SemaphoreSlim is released.</returns>
        public static Task WaitAsync(this ILockProvider provider, CancellationToken cancellationToken = default)
        {
            SemaphoreSlim @lock = provider.Get();
            return @lock.WaitAsync(cancellationToken);
        }
    }
}
