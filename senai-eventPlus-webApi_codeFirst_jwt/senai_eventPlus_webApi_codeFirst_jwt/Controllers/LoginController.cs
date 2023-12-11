using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.DTO;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;
using senai_eventPlus_webApi_codeFirst_jwt.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_eventPlus_webApi_codeFirst_jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscaPorEmailSenha(usuario.email, usuario.senha);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.nome),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                    new Claim("role", usuarioBuscado.tiposUsuario.tipoUsuario),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-webapi-chave-autenticacao-ef"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "webapi-event+",
                        audience: "webapi-event+",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
