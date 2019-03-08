using Senai.SpMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    public interface IEspecialidadeRepository
    {
        List<Especialidades> Listar();

        void Alterar(Especialidades especialidade);

        void Cadastrar(Especialidades especialidade);

        void Excluir(Especialidades especialidade);
    }
}