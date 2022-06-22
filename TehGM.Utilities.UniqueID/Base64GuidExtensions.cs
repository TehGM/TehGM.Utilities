using System;

namespace TehGM.Utilities
{
    /// <summary>Unique ID extensions for <see cref="Guid"/>.</summary>
    public static class Base64GuidExtensions
    {
        /// <summary>Converts <see cref="Guid"/> to a <see cref="Base64Guid"/> wrapper.</summary>
        /// <param name="guid">Guid to convert.</param>
        /// <returns>Guid wrapped into Base64 representation.</returns>
        public static Base64Guid ToBase64Guid(this Guid guid)
            => new Base64Guid(guid);

        /// <summary>Converts <see cref="Guid"/> to a <see cref="Base64Guid"/> string.</summary>
        /// <param name="guid">Guid to convert.</param>
        /// <returns>Guid wrapped into Base64 string representation.</returns>
        public static string ToBase64GuidString(this Guid guid)
            => ToBase64Guid(guid).ToString();
    }
}
