using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Jwt;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;

namespace Application.Tools
{
    public class JwtTools(IOptions<JwtSettings> jwtOptions)
    {
        public string GenerateToken(string email , string role)
        {
            // génération de la clé de sécurité
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QD8S90F7QDS09F7Q0S9DF7QS09DFQ0SD99F60Q0QSDF"));

            // créer les crédential
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            // créer les claims 
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Country , "Belgium"),
                new Claim(ClaimTypes.Role,role),
                new Claim("Role",role),
                new Claim("Email",email)
            };

            // génération du token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer : "https://localhost:7045",// emmetteur
                audience : "https://localhost:4200", // recepteur
                claims : claims,
                expires : DateTime.Now.AddMinutes(60),
                signingCredentials : credentials
                );

            // renvoie le token en string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
