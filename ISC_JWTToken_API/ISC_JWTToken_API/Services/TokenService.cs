using ISC_JWTToken_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ISC_JWTToken_API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration) 
        {
            this._configuration = configuration;
        }
        public string CreateToken(ApplicationUser user, IList<string> roles)
        {
            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName!)
            };
            claim.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _configuration["JWT:Issuer"],
                                            audience: _configuration["JWT:Audience"],
                                            claims: claim,
                                            expires: DateTime.UtcNow.AddDays(2),
                                            signingCredentials: credentials
                                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
