using Senai.SpMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IClinicaRepository 
    {
        List <Clinicas> Listar();

        void Cadastrar(Clinicas clinica);

        void Alterar(Clinicas clinica);

        Clinicas BuscarPorId(int id);

        void Excluir(Clinicas clinica);
    }
}