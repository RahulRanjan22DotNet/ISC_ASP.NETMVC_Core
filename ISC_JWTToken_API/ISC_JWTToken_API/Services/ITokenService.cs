using ISC_JWTToken_API.Models;

namespace ISC_JWTToken_API.Services
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUser user, IList<string> roles);
        
    }
}
