using Core.Extensions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;

namespace WebUIAspNetMvcCore.Services
{
    public class TokenSessionService : ITokenSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public TokenSessionService(IHttpContextAccessor  httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public AccessToken GetToken()
        {
            AccessToken tokenToCheck = _httpContextAccessor.HttpContext.Session.GetObject<AccessToken>("token");
            if (tokenToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("token", new AccessToken());
                tokenToCheck = _httpContextAccessor.HttpContext.Session.GetObject<AccessToken>("token");
            }
            return tokenToCheck;
        }

        public void SetToken(AccessToken token)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("token", token);
          
        }
    }
}
