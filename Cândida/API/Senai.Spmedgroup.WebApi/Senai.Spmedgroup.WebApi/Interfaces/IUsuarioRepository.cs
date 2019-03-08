using Senai.SpMedGroup.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        void Alterar(Usuarios usuario);

        Usuarios BuscarPorId(int id);

        void Cadastrar(Usuarios usuario);

        void Excluir(Usuarios usuario);
    }
}