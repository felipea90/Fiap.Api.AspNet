using Fiap.Api.AspNet.Data;
using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
