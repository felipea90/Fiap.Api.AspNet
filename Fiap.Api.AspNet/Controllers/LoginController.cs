using Fiap.Api.AspNet.Data;
using Fiap.Api.AspNet.Model;
using Fiap.Api.AspNet.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Api.AspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult<dynamic> Index(
            [FromBody] UsuarioModel usuarioRequest,
            [FromServices] DataContext dataContext)
        {
            var usuario = dataContext.Usuarios
                .AsNoTracking()
                .Where(u => u.NomeUsuario == usuarioRequest.NomeUsuario &&
                            u.Senha == usuarioRequest.Senha)
                .SingleOrDefault();

            if (usuario == null)
            {
                return Unauthorized();
            }

            string token = AuthenticationService.GetToken(usuario);

            var retorno = new
            {
                usuario = usuario,
                token = token
            };

            return Ok(retorno);
        }
    }
}
