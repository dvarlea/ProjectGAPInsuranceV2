using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GAPInsuranceApp.DTOs;
using GAPInsuranceApp.Interfaces;
using GAPInsuranceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GAPInsuranceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository authRepo, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _authRepo = authRepo;
            _mapper = mapper;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO userRegDTO)
        {

            //no se aceptan nombres o ids duplicados
            userRegDTO.Username = userRegDTO.Username.ToLower();

            if (await _authRepo.UserExists(userRegDTO.Username))
            {
                return BadRequest("Username already exists. Please choose a different username.");
            }
            if (await _authRepo.IdExists(userRegDTO.id))
            {
                return BadRequest("Identification already exists. Please check.");
            }

            User userToCreate = _mapper.Map<User>(userRegDTO);
           
            var createdUser = await _authRepo.Register(userToCreate, userRegDTO.Password);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LogginUserDTO userLoginDTO)
        {
            var userFromRepo = await _authRepo.Login(userLoginDTO.Username.ToLower(), userLoginDTO.Password);

            if (userFromRepo == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                id = userFromRepo.Id,
                role = userFromRepo.Role
            });
        }
    }
}
