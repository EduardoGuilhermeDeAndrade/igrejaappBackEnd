using igreja.Domain.Interfaces;
using igreja.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace igreja.Infrastructure.Providers
{
    public class UserContextProvider : IUserContextProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentTenantId()
        {
            var tenantIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.GivenName)?.Value;
            return string.IsNullOrEmpty(tenantIdClaim) ? Guid.Empty : Guid.Parse(tenantIdClaim);
        }

        public Guid GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.GivenName)?.Value; 
            return string.IsNullOrEmpty(userIdClaim) ? Guid.Empty : Guid.Parse(userIdClaim);
        }
    }
}

