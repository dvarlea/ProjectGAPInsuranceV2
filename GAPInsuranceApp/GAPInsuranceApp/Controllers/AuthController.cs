using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GAPInsuranceApp.DTOs;
using GAPInsuranceApp.Interfaces;
using GAPInsuranceApp.Models;
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
            // 1st validate the request
            // (This action is handled by the api/Controller annotation at the top of the controller)
            // (User response validation is being handled by the DTO required annotations)

            // 2nd convert username to lowercase (don't accept duplicate usernames)
            userRegDTO.Username = userRegDTO.Username.ToLower();

            // 3rd check if username is taken
            if (await _authRepo.UserExists(userRegDTO.Username))
            {
                return BadRequest("Username already exists. Please choose a different username.");
            }

            // 4th actually create the user from the register call
            User userToCreate = _mapper.Map<User>(userRegDTO);
           
            var createdUser = await _authRepo.Register(userToCreate, userRegDTO.Password);

            // 5th will eventually return CreatedAtRoute, for now using StatusCode(201)
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LogginUserDTO userLoginDTO)
        {
            // 1st get the user from DB
            var userFromRepo = await _authRepo.Login(userLoginDTO.Username.ToLower(), userLoginDTO.Password);

            // 2nd return only unathorized to prevent clues about what may or may not exist in the DB
            if (userFromRepo == null) return Unauthorized();

            // 3rd-a (creating the claims to be included with the Json Web Token (JWT))
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            // 3rd-b (creating the hashed Key to sign the JWT)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            // 3rd-c (creating signing credentials for the key)
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // 3rd-d (creating security token descriptor. This contains claims,  expiration date for the token and the signing credentials)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            // 3rd-e (creating the token handler)
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 4th now return the created token back to client as an object
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                id = userFromRepo.Id,
                role = userFromRepo.Role
            });
        }
    }
}
