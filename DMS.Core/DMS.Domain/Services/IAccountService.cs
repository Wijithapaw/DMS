using DMS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Services
{
    public interface IAccountService
    {
        Task<int> RegisterUser(UserDto userDto);

        Task<AuthToken> CreateToken(LoginDto loginDto);

        Task<UserDto> GetCurentUser(ClaimsPrincipal user);
    }
}
