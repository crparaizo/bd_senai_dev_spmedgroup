using Microsoft.EntityFrameworkCore;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public void Alterar(Medicos medico)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Medicos.Update(medico);
                ctx.SaveChanges();
            }
        }

        public Medicos BuscarPorId(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Medicos.Find(id);
            }
        }

        public void Cadastrar(Medicos medico)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Medicos.Add(medico);
                ctx.SaveChanges();
            }
        }

        public void Excluir(Medicos medico)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Medicos.Remove(medico);
                ctx.SaveChanges();
            }
        }

        public List<Medicos> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                List<Medicos> listaMedicos = ctx.Medicos
                        .Include(x => x.IdUsuarioNavigation)
                        .Include(x => x.IdEspecialidadeNavigation)
                        .Include(x => x.IdClinicaNavigation)
                        .ToList();
                foreach (var item in listaMedicos)
                {
                    item.IdUsuarioNavigation.Medicos = null;
                    item.IdEspecialidadeNavigation.Medicos = null;
                    item.IdClinicaNavigation.Medicos = null;
                }
                return listaMedicos;
            }
        }
    }
}