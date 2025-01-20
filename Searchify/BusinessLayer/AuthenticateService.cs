﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Searchify.Core.Interfaces;
using Searchify.Core.Model;

namespace Searchify.BusinessLayer
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IConfiguration _config;

        public AuthenticateService(IConfiguration config)
        {
            _config = config;   
        }

        public Task<string> AuthenticateUser(User user)
        {
            try
            {
                if (user.UserName == "Risha" && user.Password == "12345")
                {
                    var issuer = _config["Jwt:Issuer"];
                    var audience = _config["Jwt:Audience"];
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                    var claims = new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
        };

                    var jwtToken = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);

                    var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                    return Task.FromResult(token);
                }
                else
                {
                    throw new Exception("Username or Password incorrect");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in {nameof(AuthenticateUser)}: {ex.Message}", ex);
            }
        }
    }
    }

