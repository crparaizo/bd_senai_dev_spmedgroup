using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Alterar(Usuarios usuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Usuarios.Find(id);
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Excluir(Usuarios usuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}