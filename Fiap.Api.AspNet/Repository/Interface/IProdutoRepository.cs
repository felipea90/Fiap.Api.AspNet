using Fiap.Api.AspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Api.AspNet.Repository.Interface
{
    public interface IProdutoRepository
    {
        public IList<ProdutoModel> FindAll();
        public ProdutoModel FindById(int id);
        public int Insert(ProdutoModel produtoModel);
        public void Delete(int id);
        public void Update(ProdutoModel produtoModel);
    }
}
