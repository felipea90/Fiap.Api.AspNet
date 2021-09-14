using Fiap.Api.AspNet.Data;
using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Api.AspNet.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DataContext _context;

        public MarcaRepository(
            DataContext context)
        {
            _context = context;
        }

        public IList<MarcaModel> FindAll()
        {
            return _context.Marcas.AsNoTracking().ToList();
        }

        public IList<MarcaModel> FindAll(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        //public IList<MarcaModel> FindAll(int pagina, int tamanho)
        //{
        //    var query = _context.Marcas.AsNoTracking().ToListAsync();
        //    var totalGeral = query.Count();
        //    var totalPaginas = (int)Math.Ceiling((double)totalGeral / tamanho);
        //    var anterior = pagina > 0 ? $"produto?pagina={pagina - 1}&tamanho={tamanho}" : "";
        //    var proximo = pagina < totalPaginas - 1 ? $"produto?pagina={pagina + 1}&tamanho={tamanho}" : "";
        //    IEnumerable<MarcaModel> listaMarcas = query.Skip(tamanho * pagina).Take(tamanho).ToList();
        //}

        public MarcaModel FindById(int id)
        {
            return _context.Marcas.FirstOrDefault(x => x.MarcaId == id);
        }

        public int Insert(MarcaModel marcaModel)
        {
            _context.Marcas.Add(marcaModel);
            _context.SaveChanges();
            return marcaModel.MarcaId;
        }

        public void Update(MarcaModel marcaModel)
        {
            _context.Marcas.Update(marcaModel);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var marca = new MarcaModel()
            {
                MarcaId = id
            };

            _context.Marcas.Remove(marca);
            _context.SaveChanges();
        }

    }
}
