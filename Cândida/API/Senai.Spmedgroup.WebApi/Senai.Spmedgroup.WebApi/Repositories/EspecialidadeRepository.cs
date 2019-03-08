using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        public void Alterar(Especialidades especialidade)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Especialidades.Update(especialidade);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Especialidades especialidade)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Especialidades.Add(especialidade);
                ctx.SaveChanges();
            }
        }

        public void Excluir(Especialidades especialidade)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Especialidades.Remove(especialidade);
                ctx.SaveChanges();
            }
        }

        public List<Especialidades> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Especialidades.ToList();
            }
        }
    }
}