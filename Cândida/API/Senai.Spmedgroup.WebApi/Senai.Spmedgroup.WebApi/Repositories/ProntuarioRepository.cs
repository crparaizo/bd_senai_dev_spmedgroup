using Microsoft.EntityFrameworkCore;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        public void Alterar(Prontuarios prontuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Prontuarios.Update(prontuario);
                ctx.SaveChanges();
            }
        }

        public Prontuarios BuscarPorId(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Prontuarios.Find(id);
            }
        }

        public void Cadastrar(Prontuarios prontuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Prontuarios.Add(prontuario);
                ctx.SaveChanges();
            }
        }

        public void Excluir(Prontuarios prontuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Prontuarios.Remove(prontuario);
                ctx.SaveChanges();
            }
        }

        public List<Prontuarios> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Prontuarios.Include(x => x.IdUsuarioNavigation).ToList();
            }
        }
    }
}