using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DMS.Domain.Dtos;
using DMS.Domain.Services;

namespace DMS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<int> RegisterUser(UserDto userDto)
        {
            var id = await _accountService.RegisterUser(userDto);
            return id;
        }

        public async Task<AuthToken> Login(LoginDto loginDto)
        {
            var authToken = await _accountService.CreateToken(loginDto);
            return authToken;
        }

        public async Task<UserDto> GetCurrentUser()
        {
            var user = await _accountService.GetCurentUser(this.User);
            return user;
        }

    }
}