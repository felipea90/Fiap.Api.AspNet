using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Api.AspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TesteController : ControllerBase
    {
        [HttpGet("anonimo")]
        [AllowAnonymous]
        public string Anonimo()
        {
            return "Anonimo";
        }

        [HttpGet("autenticado")]
        [Authorize(Roles = "Junior, Pleno, Senior")]
        public string Autenticado()
        {
            return "Autenticado";
        }

        [HttpGet("junior")]
        [Authorize(Roles = "Junior, Pleno, Senior")]
        public string Junior()
        {
            return "Junior";
        }

        [HttpGet("senior")]
        [Authorize(Roles = "Senior")]
        public string Senior()
        {
            return "Senior";
        }

    }
}
