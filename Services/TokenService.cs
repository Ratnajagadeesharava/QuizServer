using QuizCreatorServer.Interfaces;
using QuizCreatorServer.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;


namespace QuizCreatorServer.Services
{
        public class TokenService : ITokenService
        {
            private readonly SymmetricSecurityKey _key;
            public TokenService(IConfiguration config)
            {
                _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            }
            
                public string CreateToken(User user)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
                    };
                    var creds = new SigningCredentials(key: _key, algorithm: SecurityAlgorithms.HmacSha512Signature);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddDays(31),
                        SigningCredentials = creds
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
        }
}