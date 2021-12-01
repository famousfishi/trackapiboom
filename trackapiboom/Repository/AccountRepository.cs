using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using trackapiboom.DTOs;
using trackapiboom.Models;
using trackapiboom.Repository.InterfaceServiceTypes;

namespace trackapiboom.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        //Signup
        public async Task<IdentityResult> SignupAsync(SignupDTO signupDTO)
        {
            //create a new user
            ApplicationUser user = new()
            {
                FirstName = signupDTO.FirstName,
                LastName = signupDTO.LastName,
                Email = signupDTO.Email,
                UserName = signupDTO.Email
            };

            return await _userManager.CreateAsync(user, signupDTO.Password);
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            //else if succeeded create claims
            List<Claim> authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, loginDTO.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //genrate the signin key
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            //generate a new token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)

                );

           return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}