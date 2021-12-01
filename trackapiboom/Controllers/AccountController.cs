using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trackapiboom.DTOs;
using trackapiboom.Repository.InterfaceServiceTypes;

namespace trackapiboom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignupAsync([FromBody] SignupDTO signupDTO)
        {


            IdentityResult result = await _accountRepository.SignupAsync(signupDTO);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();


        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {


            string result = await _accountRepository.LoginAsync(loginDTO);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);


        }
    }
}
