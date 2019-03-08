using Senai.SpMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    public interface IProntuarioRepository
    {
        List<Prontuarios> Listar();

        void Alterar(Prontuarios prontuario);

        Prontuarios BuscarPorId(int id);

        void Cadastrar(Prontuarios prontuario);

        void Excluir(Prontuarios prontuario);
    }
}