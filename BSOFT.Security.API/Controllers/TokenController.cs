using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSOFT.Security.API.ViewObject;
using BSOFT.Security.Business.Services;
using BSOFT.Security.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BSOFT.Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public TokenController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost]
        public ActionResult Post([FromBody] UserVO userRequest)
        {

            try
            {
                bool authorize = _userService.ValidateUser(userRequest.Username, userRequest.Password);
                if (!authorize)
                {
                    throw new UnauthorizedAccessException();
                }
                var token = new JsonWebTokenVO
                {
                    Expires_in = int.Parse(_configuration["Auth:Jwt:TokenExpirationInMinutes"]),
                    Refresh_Token = "30 Minutes"
                };

                Response.Headers.Add("access-control-expose-headers", "Authorization");
                Response.Headers.Add("Authorization", "Bearer " + CreateToken());

                return Ok(token);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        private string CreateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Auth:Jwt:Issuer"],
             _configuration["Auth:Jwt:Audience"],
              expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Auth:Jwt:TokenExpirationInMinutes"])),
              signingCredentials: creds);

            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            return _token;
        }
    }
}