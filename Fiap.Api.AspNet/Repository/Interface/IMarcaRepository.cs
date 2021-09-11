using Fiap.Api.AspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Api.AspNet.Repository.Interface
{
    public interface IMarcaRepository
    {
        public IList<MarcaModel> FindAll();
        public MarcaModel FindById(int id);
        public int Insert(MarcaModel marcaModel);
        public void Delete(int id);
        public void Update(MarcaModel marcaModel);
    }
}