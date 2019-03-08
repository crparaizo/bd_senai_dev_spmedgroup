using Senai.SpMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    public interface IConsultaRepository
    {
        List<Consultas> Listar();

        void Alterar(Consultas consultas);

        Consultas BuscarPorId(int id);

        void Cadastrar(Consultas consultas);

        void Excluir(Consultas consultas);
    }
}