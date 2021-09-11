using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository.Interface;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fiap.Api.AspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IList<MarcaModel>> GetAll(
            [FromServices] IMarcaRepository marcaRepository)
        {
            var marca = marcaRepository.FindAll();

            if (marca.Count == 0)
            {
                return NoContent();
            }

            return Ok(marca);
        }

        [HttpGet("{id:int}")]
        public ActionResult<MarcaModel> GetById(
            [FromRoute] int id,
            [FromServices] IMarcaRepository marcaRepository)
        {
            var marca = marcaRepository.FindById(id);

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        [HttpPost]
        public ActionResult<MarcaModel> Post(
            [FromServices] IMarcaRepository marcaRepository,
            [FromBody] MarcaModel marcaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var marcaId = marcaRepository.Insert(marcaModel);
                marcaModel.MarcaId = marcaId;

                var location = new Uri(Request.GetEncodedUrl() + marcaId);

                return Created(location, marcaModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a marca. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<MarcaModel> Put(
            [FromRoute] int id,
            [FromServices] IMarcaRepository marcaRepository,
            [FromBody] MarcaModel marcaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (marcaModel.MarcaId != id)
            {
                return NotFound();
            }

            try
            {
                marcaRepository.Update(marcaModel);
                
                return Ok(marcaModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a marca. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<MarcaModel> Delete(
             [FromRoute] int id,
             [FromServices] IMarcaRepository marcaRepository)
        {
            marcaRepository.Delete(id);

            return Ok();
        }

    }
}
