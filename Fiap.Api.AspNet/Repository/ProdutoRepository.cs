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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(
            DataContext context)
        {
            _context = context;
        }

        public IList<ProdutoModel> FindAll()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        public ProdutoModel FindById(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
        }

        public int Insert(ProdutoModel produtoModel)
        {
            _context.Produtos.Add(produtoModel);
            _context.SaveChanges();
            return produtoModel.ProdutoId;
        }

        public void Update(ProdutoModel produtoModel)
        {
            _context.Produtos.Update(produtoModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = new ProdutoModel()
            {
                ProdutoId = id
            };

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}
