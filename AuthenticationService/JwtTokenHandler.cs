using AuthenticationService.DTOs;
using AuthenticationService.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService
{
    public  class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "WojsoOOJODSAMDMSsjfdihs5451jsoaf";
        public const int JWT_TOKEN_VALIDATE_MIN = 20;
        private readonly List<UserAcount> _userAcountList;
        public JwtTokenHandler() 
        {
            _userAcountList = new List<UserAcount>
            {
                new UserAcount{UserName="admin", Password="password", Role="admin"},
                new UserAcount{UserName="owner", Password="password", Role="owner"},
                new UserAcount{UserName="user", Password="password", Role="user"},
            };
        }
        public  AuthenticationResponseDto GenerateJwtToken(AuthenticationRequestDto authenticationRequestDto)
        {
            if(string.IsNullOrWhiteSpace(authenticationRequestDto.UserName) || string.IsNullOrWhiteSpace(authenticationRequestDto.Password))
                return new AuthenticationResponseDto() { Message="username and password are required",Token=null,tokenLifelemit=0};
            var userAcount = _userAcountList.FirstOrDefault(item => item.UserName == authenticationRequestDto.UserName && item.Password == authenticationRequestDto.Password);
            if(userAcount == null)
                return   new AuthenticationResponseDto() { Message = "Wrong user info", Token = null, tokenLifelemit = 0 };
            
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var tokenlifetime = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDATE_MIN);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,authenticationRequestDto.UserName),
                new Claim("Role",userAcount.Role)
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var sercurityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=claimsIdentity,
                Expires=tokenlifetime,
                SigningCredentials=signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(sercurityTokenDescriptor);
            var token=jwtSecurityTokenHandler.WriteToken(securityToken);
            return new AuthenticationResponseDto() {
                Message = "login successfully",
                Token = token,
                UserName = authenticationRequestDto.UserName,
                tokenLifelemit =(int)tokenlifetime.Subtract(DateTime.Now).TotalSeconds
                };

        }
    }
}
