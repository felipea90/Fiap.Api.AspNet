using Fiap.Api.AspNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Api.AspNet.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public IList<UsuarioModel> FindAll();
        public UsuarioModel FindById(int id);
        public UsuarioModel FindByName(string name);
        public IList<UsuarioModel> FindByRegra(string regra);
        public int Insert(UsuarioModel usuarioModel);
        public void Delete(int id);
        public void Update(UsuarioModel usuarioModel);
    }
}
