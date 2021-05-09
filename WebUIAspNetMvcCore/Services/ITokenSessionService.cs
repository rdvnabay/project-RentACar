using Core.Utilities.Security.Jwt;

namespace WebUIAspNetMvcCore.Services
{
    public interface ITokenSessionService
    {
        AccessToken GetToken();
        void SetToken(AccessToken token);
    }
}
