using igreja.Domain.Interfaces;
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

        //Ativar validação de usuário logado
        public Guid GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return string.IsNullOrEmpty(userIdClaim) ? Guid.Empty : Guid.Parse(userIdClaim);
        }

        ////Travado para testes
        //public Guid GetCurrentUserId()
        //{
        //    // GUID fixo para testes ou ambiente de desenvolvimento
        //    return Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9");
        //}
    }
}
