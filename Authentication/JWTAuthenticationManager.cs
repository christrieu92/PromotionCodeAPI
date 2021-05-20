using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PromotionCodeAPI.Authentication
{
    /// <summary>
    /// JWT to Authenticate user for a Token to be authorised
    /// </summary>
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {

        private readonly string _tokenKey;


        public JWTAuthenticationManager(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        /// <summary>
        /// Method used to authenticate user username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A bearer token for authorisation</returns>
        public string Authenticate(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                            {
                    new Claim(ClaimTypes.Name, username)
                            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
