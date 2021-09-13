using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Api.AspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IList<ProdutoModel>> GetAll(
            [FromServices] IProdutoRepository produtoRepository)
        {
            var produto = produtoRepository.FindAll();

            if (produto.Count == 0)
            {
                return NoContent();
            }

            return Ok(produto);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProdutoModel> GetById(
            [FromRoute] int id,
            [FromServices] IProdutoRepository produtoRepository)
        {
            var produto = produtoRepository.FindById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<ProdutoModel> Post(
            [FromServices] IProdutoRepository produtoRepository,
            [FromBody] ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var categoriaId = produtoRepository.Insert(produtoModel);
                produtoModel.ProdutoId = categoriaId;

                var location = new Uri(Request.GetEncodedUrl() + categoriaId);

                return Created(location, produtoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a marca. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoriaModel> Put(
            [FromRoute] int id,
            [FromServices] IProdutoRepository produtoRepository,
            [FromBody] ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (produtoModel.ProdutoId != id)
            {
                return NotFound();
            }

            try
            {
                produtoRepository.Update(produtoModel);

                return Ok(produtoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a marca. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CategoriaModel> Delete(
            [FromRoute] int id,
            [FromServices] IProdutoRepository produtoRepository)
        {
            produtoRepository.Delete(id);

            return Ok();
        }
    }
}
