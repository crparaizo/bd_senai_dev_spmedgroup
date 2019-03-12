using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void Alterar(Clinicas clinica)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Clinicas.Update(clinica);
                ctx.SaveChanges();
            }
        }

        public Clinicas BuscarPorId(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Clinicas.Find(id);
            }
        }

        public void Cadastrar(Clinicas clinica)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Clinicas.Add(clinica);
                ctx.SaveChanges();
            }
        }

        public void Excluir(Clinicas clinica)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Clinicas.Remove(clinica);
                ctx.SaveChanges();
            }
        }

        public List<Clinicas> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Clinicas.ToList();
            }
        }
    }
}