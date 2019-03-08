using Senai.SpMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    public interface IMedicoRepository
    {
        List<Medicos> Listar();

        void Alterar(Medicos medico);

        Medicos BuscarPorId(int id);

        void Cadastrar(Medicos medico);

        void Excluir(Medicos medico);
    }
}