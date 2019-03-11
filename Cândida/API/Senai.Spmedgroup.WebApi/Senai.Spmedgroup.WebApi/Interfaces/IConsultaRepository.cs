using Senai.SpMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    public interface IConsultaRepository
    {
        List<Consultas> Listar();

        List<Consultas> ListarUmPaciente(int id);

        List<Consultas> ListarUmMedico(int id);

        void Alterar(Consultas consulta);

        Consultas BuscarPorId(int id);

        void Cadastrar(Consultas consulta);

        void Excluir(Consultas consulta);
    }
}