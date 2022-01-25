using JeweleryApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryApp.Services
{
    public class JeweleryService : IJeweleryService
    {

        readonly IJeweleryRepository repository;
        public JeweleryService(IJeweleryRepository repository)
        {
            this.repository = repository;
        }

        public string GenerateToken(string userId)
        {
            var claims = new[]
            {
                new Claim("userId",userId)
           };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("auth_key_4_employee_api"));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "AuthAPI",
                audience: "AuthClient",
                expires: DateTime.UtcNow.AddMinutes(1),
                claims: claims,
                signingCredentials: signature
                );

            var tokenResponse = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return JsonConvert.SerializeObject(tokenResponse);
        }

        public async Task<decimal> DiscountCalculator(decimal price, int weight, decimal? discount)
        {
            return await repository.DiscountCalculator(price, weight, discount??0);           
        }
    }
}
