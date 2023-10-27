using System.Security.Claims;
using Family.Core.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BrainGame.Users.Utilities
{
    public class RequirePermissionAttribute : TypeFilterAttribute
    {
        public RequirePermissionAttribute(PermissionType permissionType) : base(typeof(RequireClaimFilter))
        {
            Arguments = new object[] { new Claim("permission", permissionType.ToString()) };
        }
    }
}
