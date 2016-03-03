using System;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace Epam.Wunderlist.MvcPL.Identity
{
    public static class IdentityUserExtentions
    {
        public static T GetUserId<T>(this IIdentity identity) where T : IConvertible
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            var ci = identity as ClaimsIdentity;
            var id = ci?.FindFirst(ClaimTypes.NameIdentifier);
            if (id != null)
            {
                return (T)Convert.ChangeType(id.Value, typeof(T), CultureInfo.InvariantCulture);
            }
            return default(T);
        }

        public static string GetUserEmail(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            var ci = identity as ClaimsIdentity;
            var email = ci?.FindFirst(ClaimTypes.Email)?.Value;
            return email ?? String.Empty;
        }
    }
}