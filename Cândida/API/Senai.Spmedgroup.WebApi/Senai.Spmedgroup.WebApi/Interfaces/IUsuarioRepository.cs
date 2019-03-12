using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.ViewModel;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        void Alterar(Usuarios usuario);

        Usuarios BuscarPorId(int id);

        Usuarios BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(Usuarios usuario);

        void Excluir(Usuarios usuario);
    }
}