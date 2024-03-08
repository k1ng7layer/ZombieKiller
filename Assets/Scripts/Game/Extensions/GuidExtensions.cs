using System;

namespace Game.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Creates a GUID which is guaranteed not to equal the empty GUID
        /// </summary>
        /// <returns>A 24 character long string</returns>
        public static string CreateShortGuid(this Guid guid)
        {
            guid = Guid.Empty;
            while (Guid.Empty == guid)
            {
                guid = Guid.NewGuid();
            }

            // Uses base64 encoding the guid.(Or  ASCII85 encoded)
            // But not recommend using Hex, as it is less efficient.
            return Convert.ToBase64String(guid.ToByteArray());
        }
    }
}