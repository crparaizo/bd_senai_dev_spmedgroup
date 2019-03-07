using Senai.Spmedgroup.WebApi.Domains;
using Senai.Spmedgroup.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Spmedgroup.WebApi.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        public void Alterar(Prontuarios prontuario)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Prontuarios.Update(prontuario);
                ctx.SaveChanges();
            }
        }

        public Prontuarios BuscarPorId(int id)
        {
            using(MedGroupContext ctx = new MedGroupContext())
            {
                return ctx.Prontuarios.Find(id);
            }
        }

        public void Cadastrar(Prontuarios prontuario)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Prontuarios.Add(prontuario);
                ctx.SaveChanges();
            }
        }

        public void Excluir(Prontuarios prontuario)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Prontuarios.Remove(prontuario);
                ctx.SaveChanges();
            }
        }

        public List<Prontuarios> Listar()
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                return ctx.Prontuarios.ToList();
            }
        }
    }
}