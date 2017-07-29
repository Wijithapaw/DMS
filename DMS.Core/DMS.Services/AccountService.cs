using DMS.Data.Entities;
using DMS.Domain.Dtos;
using DMS.Domain.Services;
using DMS.Utills.CustomExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class AccountService : IAccountService
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signinManager;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

        public async Task<int> RegisterUser(UserDto userDto)
        {
            var user = new ApplicationUser
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Birthday = userDto.Birthday,
                Active = userDto.Active,
                UserName = userDto.Email,
                //CreatedBy = 1,
                //CreatedDate = DateTime.Now,
                //LastUpdatedBy = 1,
                //LastUpdatedDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, "Pwd123");
            if (result.Succeeded)
                return user.Id;

            throw new DMSException("Error creating user");

        }

        public async Task<AuthToken> CreateToken(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user != null)
            {
                if (_signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false).Result.Succeeded)
                {
                    var userClaims = await _userManager.GetClaimsAsync(user);

                    var claims = new[]
                    {
                                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                                new Claim(ClaimTypes.Email, user.Email)

                            }.Union(userClaims);

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey_GetThisFromAppSettings"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "http://localhost:4200",
                        audience: "http://localhost:4200",
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(15),
                        signingCredentials: creds
                        );

                    var authToken = new AuthToken
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    };

                    return authToken;
                }
            }

            throw new DMSException("Invalid username or password");
        }

        public async Task<UserDto> GetCurentUser(ClaimsPrincipal user)
        {
            var applicationUser = await _userManager.GetUserAsync(user);

            var userDto = new UserDto
            {
                Id = applicationUser.Id,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Active = applicationUser.Active,
                Birthday = applicationUser.Birthday,
                Email = applicationUser.Email
            };

            return userDto;
        }
    }
}
