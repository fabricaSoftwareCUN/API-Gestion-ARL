using API_ARLRequest.Infraestructure.Security.DTOs;
using API_ARLRequest.Infraestructure.Security.Models;
using API_ARLRequest.Infraestructure.Security.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API_ARLRequest.Infraestructure.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private IConfiguration _config;
        public AuthController(AuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            var user = await _authService.GetUser(userDTO);

            if (user == null)
            {
                return BadRequest(new { Status = false, Code = HttpStatusCode.BadRequest, Message = "Credenciales incorrectas" });
            }

            string jwtToken = GenerateToken(user);

            return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Autenticado correctamente.", token = jwtToken });
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Rol),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
