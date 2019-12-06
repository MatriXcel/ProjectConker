using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using WebApiServerApp.Searching;
using Microsoft.AspNetCore.Cors;

using ProjectConker.Roadmaps;
using ProjectConker.Searching;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ProjectConker.Controllers
{
    public struct RegisterInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
    
    public class LoginInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AccountsInfo
    {
        public string DisplayName { get; set; }
    }

    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {

        UserManager<IdentityUser> UserManager { get; }
        SignInManager<IdentityUser> SignInManager { get; }

        public AccountsController(UserManager<IdentityUser> userManager,
                                  SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        [Route("info")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<AccountsInfo> GetInfo()
        {
            
            var usernameClaim = User.Claims.SingleOrDefault(c => c.Type == "username");
            Console.WriteLine(usernameClaim.Value, ConsoleColor.Red);

            var user = await UserManager.FindByNameAsync(usernameClaim.Value);
            

            return new AccountsInfo{ DisplayName = user.UserName };
        }
  
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterInfo registerInfo)
        {
            var user = new IdentityUser { UserName = registerInfo.Username, Email = registerInfo.Email };
             
            var result = await UserManager.CreateAsync(user, registerInfo.Password);

            if(result.Succeeded)
            {
                //await SignInManager.SignInAsync(user, isPersistent: false);
            }
            
             return Ok();
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginInfo credentials)
        {
            if (credentials == null)
            {
                return BadRequest("Invalid client request");
            }

            var user = await UserManager.FindByNameAsync(credentials.Username);
            await SignInManager.SignInAsync(user, isPersistent: false);

            var result = await SignInManager.PasswordSignInAsync(user, 
            credentials.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new List<Claim>(){
                            new Claim("username", credentials.Username)
                    }),
                    Expires = DateTime.Now.AddMinutes(5),
                    SigningCredentials = signinCredentials,
                    IssuedAt = DateTime.Now,
                    NotBefore = DateTime.Now,
                    Issuer = "http://localhost:5000",
                    Audience = "http://localhost:5000"
                    
                };
    
                 var tokenHandler = new JwtSecurityTokenHandler();
                 var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { Token = tokenHandler.WriteToken(token), UserName = user.UserName });

                
            }
            else
            {
                return Unauthorized();
            }
        }

        
    }
}