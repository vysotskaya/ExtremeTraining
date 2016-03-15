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

        public static string GetUserAvatar(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            var ci = identity as ClaimsIdentity;
            var avatar = ci?.FindFirst("Avatar")?.Value;
            return avatar ?? String.Empty;
        }

        public static void UpdateClaim(this IPrincipal currentPrincipal, string key, string value, string type)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;

            var existingClaim = identity.FindFirst(key);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            identity.AddClaim(new Claim(key, value, type));
        }
    }
}