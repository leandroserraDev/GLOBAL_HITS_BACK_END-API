using ClaroCell.Application.InterfacesService;
using ClaroCell.Domain.Entities;
using ClaroCell.Service.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClaroCell.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public AuthController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            // Recupera o usuário
            var user = await _userAppService.GetLogin(model.Login, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = GenerateToken(user);

            // Oculta a senha
            user.SetPassword("");

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<dynamic>> Create([FromBody] User model)
        {
            // Recupera o usuário
            var result = await _userAppService.Add(model);

            // Verifica se o usuário existe
            if (!result)
                return NotFound(new { message = "Não foi possivel cadastrar o usuario" });


            return Ok();
        }

        // GET api/<UserController>/5
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _userAppService.GetAll();
            if (users == null) return NotFound();

            foreach(var user in users)
            {
                user.SetPassword("");
            }

            return Ok(users);
        }

        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtTokenConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
