using Senai.Spmedgroup.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface IProntuarioRepository
    {
        List <Prontuarios>Listar();

        void Alterar(Prontuarios prontuario);

        Prontuarios BuscarPorId(int id);

        void Cadastrar(Prontuarios prontuario);

        void Excluir(Prontuarios prontuario);
    }
}