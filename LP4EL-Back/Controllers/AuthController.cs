using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopJoin.API.Data;
using ShopJoin.API.Dtos;
using ShopJoin.API.Models;

namespace ShopJoin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            try
            {
                //validate request

                if (userForRegisterDto.Tipo == "U")
                {

                    if (await _repo.UserExists(userForRegisterDto.Documento, userForRegisterDto.Email))
                    {
                        return BadRequest("Informações do usuário incorretas");
                    }

                    var userToCreate = new User
                    {
                        Email = userForRegisterDto.Email,
                        Name = userForRegisterDto.Name,
                        Cpf = userForRegisterDto.Documento
                    };

                    userToCreate = await _repo.Register(userToCreate, userForRegisterDto.Password);

                    return Ok(CreateToken(userToCreate.Id.ToString(),
                                          userToCreate.Email,
                                          "U"));

                }
                else
                {
                    if (await _repo.HospitalExists(userForRegisterDto.Email))
                        return BadRequest("Hospital já está cadastrado");

                    var hospitalToCreate = new Hospital
                    {
                        Name = userForRegisterDto.Name,
                        Cnpj = userForRegisterDto.Documento,
                        Autorizado = false
                    };

                    hospitalToCreate = await _repo.Register(hospitalToCreate, userForRegisterDto.Password);

                    return Ok(CreateToken(hospitalToCreate.Id.ToString(),
                                          hospitalToCreate.Cnpj,
                                          "H"));
                }

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = new User { };
            var hospFromRepo = new Hospital { };
            if (userForLoginDto.Tipo == "U")
            {
                userFromRepo = await _repo.Login(userForLoginDto.Email, userForLoginDto.Password);
            }
            else
            {
                hospFromRepo = await _repo.LoginHospital(userForLoginDto.Documento, userForLoginDto.Password);
            }

            if (userFromRepo == null || hospFromRepo == null)
                return Unauthorized();

            return Ok(CreateToken(userForLoginDto.Tipo == "U" ? userFromRepo.Id.ToString() : hospFromRepo.Id.ToString(), 
                        userForLoginDto.Tipo == "U" ? userFromRepo.Email : hospFromRepo.Cnpj, 
                            userForLoginDto.Tipo));
        }

        private SecurityToken CreateToken(string id, string documento, string tipo)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Name, documento),
                new Claim(ClaimTypes.Actor, tipo)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}