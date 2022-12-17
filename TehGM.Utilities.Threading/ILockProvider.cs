using System.Threading;

namespace TehGM.Utilities
{
    /// <summary>Service for sharing SemaphoreSlim based on a type.</summary>
    /// <typeparam name="TCaller">Type the SemaphoreSlim is for.</typeparam>
    public interface ILockProvider<TCaller> : ILockProvider { }

    /// <summary>Service for sharing SemaphoreSlim.</summary>
    public interface ILockProvider
    {
        /// <summary>Gets SemaphoreSlim instance.</summary>
        /// <returns>SemaphoreSlim instance.</returns>
        SemaphoreSlim Get();
        /// <summary>Releases a SemaphoreSlim.</summary>
        void Release();
    }
}
