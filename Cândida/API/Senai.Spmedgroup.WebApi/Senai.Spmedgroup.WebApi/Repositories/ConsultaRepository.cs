using Microsoft.EntityFrameworkCore;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using Senai.SpMedGroup.WebApi.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void Alterar(Consultas consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consultas.Update(consulta);
                ctx.SaveChanges();
            }
        }

        public Consultas BuscarPorId(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consultas.Find(id);
            }
        }

        public void Cadastrar(Consultas consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public void Excluir(Consultas consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consultas.Update(consulta);
                ctx.SaveChanges();
            }
        }

        /*
        public List<Consultas> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consultas.ToList();
            }
        }
        */

        public List<Consultas> Listar(int IdUser, string IdUserType)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext ())
            {
                if (IdUserType == "Administrador")
                {
                    // return ctx.Consultas               
                    List<Consultas> listaConsulta = ctx.Consultas
                        .Include(x => x.IdProntuarioNavigation)
                        .Include(x => x.IdProntuarioNavigation.IdUsuarioNavigation)
                        .Include(x => x.IdMedicoNavigation)
                        .Include(x => x.IdMedicoNavigation.IdUsuarioNavigation)
                        .Include(x => x.IdMedicoNavigation.IdEspecialidadeNavigation)
                        .Include(x => x.IdSituacaoNavigation)
                        .ToList();
                    foreach (var item in listaConsulta)
                    {
                        item.IdProntuarioNavigation.Consultas = null;
                        item.IdMedicoNavigation.Consultas = null;
                        item.IdSituacaoNavigation.Consultas = null;
                    }
                    return listaConsulta;
                }

                if (IdUserType == "Medico")
                {
                    Medicos medico = ctx.Medicos.FirstOrDefault(x => x.IdUsuario == IdUser);
                    List<Consultas> listaConsulta = ctx.Consultas

                        .Include(x => x.IdProntuarioNavigation)
                        .Include(x => x.IdProntuarioNavigation.IdUsuarioNavigation)
                        .Include(x => x.IdMedicoNavigation)
                        .Include(x => x.IdMedicoNavigation.IdUsuarioNavigation)
                        .Include(x => x.IdMedicoNavigation.IdEspecialidadeNavigation)
                        .Include(x => x.IdSituacaoNavigation)
                        .Where(x => x.IdMedico == medico.Id)
                        .ToList();

                    //Usar framework DAPPER                    

                    foreach (var item in listaConsulta)
                    {
                        item.IdProntuarioNavigation.Consultas = null;
                        item.IdMedicoNavigation.Consultas = null;
                        item.IdSituacaoNavigation.Consultas = null;
                    }
                    return  listaConsulta;
                }

                if (IdUserType == "Paciente")
                {
                    Prontuarios prontuario = ctx.Prontuarios.Where(x => x.Id == IdUser).FirstOrDefault();
                    List<Consultas> listaConsulta = ctx.Consultas
                        .Include(x => x.IdProntuarioNavigation)
                        .Include(x => x.IdProntuarioNavigation.IdUsuarioNavigation)
                        .Include(x => x.IdMedicoNavigation)
                        .Include(x => x.IdMedicoNavigation.IdUsuarioNavigation)
                        .Include(x => x.IdMedicoNavigation.IdEspecialidadeNavigation)
                        .Include(x => x.IdSituacaoNavigation)
                        .Where(x => x.IdProntuario == prontuario.Id)
                        .ToList();

                    foreach (var item in listaConsulta)
                    {
                        item.IdProntuarioNavigation.Consultas = null;
                        item.IdMedicoNavigation.Consultas = null;
                        item.IdSituacaoNavigation.Consultas = null;
                    }
                    return listaConsulta;
                }

                return null;
            }
        }

        public List<Consultas> ListarUmMedico(int id) //Listar todas as consultas de um médico pelo ID na URL
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consultas.Where(x => x.IdMedico == id).ToList();
            }
        }

        public List<Consultas> ListarUmPaciente(int id) //Listar todas as consultas de um paciente pelo ID na URL
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consultas.Where(x => x.IdProntuario == id).ToList();
            }
        }

        public List<ConsultaViewModel> TransformaEmConsultasViewModel(List<Consultas> consultas)
        {
            List<ConsultaViewModel> consultasViewModel = new List<ConsultaViewModel>();

            foreach (Consultas consulta in consultas)
            {
                ConsultaViewModel consultaViewModel = new ConsultaViewModel()
                {
                    ID = consulta.Id,
                    NomePaciente = consulta.IdProntuarioNavigation.IdUsuarioNavigation.Nome,
                    EmailPaciente = consulta.IdProntuarioNavigation.IdUsuarioNavigation.Email,
                    NomeMedico = consulta.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                    EmailMedico = consulta.IdMedicoNavigation.IdUsuarioNavigation.Email,
                    Especialidade = consulta.IdMedicoNavigation.IdEspecialidadeNavigation.Nome,
                    Descricao = consulta.Descricao,
                    DataConsulta = consulta.DataHoraConsulta.ToString(),
                    Situacao = consulta.IdSituacaoNavigation.Nome
                };

                consultasViewModel.Add(consultaViewModel);
            }
            return consultasViewModel;
        }
    }
}