using System;
using System.Threading;

namespace TehGM.Utilities.Services
{
    /// <inheritdoc/>
    /// <summary>Service for sharing SemaphoreSlim based on a type.</summary>
    /// <typeparam name="TCaller">Type the SemaphoreSlim is for.</typeparam>
    public class LockProvider<TCaller> : ILockProvider<TCaller>, IDisposable
    {
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        /// <inheritdoc/>
        public SemaphoreSlim Get()
            => this._lock;

        /// <inheritdoc/>
        public void Release()
            => this._lock.Release();

        /// <inheritdoc/>
        public void Dispose()
        {
            try { this._lock?.Dispose(); } catch { }
        }
    }
}
