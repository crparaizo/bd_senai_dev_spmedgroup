using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using Senai.SpMedGroup.WebApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Senai.Spmedgroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
        }

        /*
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SpMedGroupContext ctx = new SpMedGroupContext())
                {
                    return Ok(ctx.Consultas.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }
        */
        

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Consultas consultaProcurada = ConsultaRepository.BuscarPorId(id);

            if (consultaProcurada == null)
            {
                return NotFound();
            }

            return Ok(consultaProcurada);
        }

        [Authorize]
        [HttpGet]
        [Route("paciente/{id}")]
        public IActionResult ListarUmPaciente(int id)
        {
            try
            {
                return Ok(ConsultaRepository.ListarUmPaciente(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("medico/{id}")]
        public IActionResult ListarUmMedico(int id)
        {
            try
            {
                return Ok(ConsultaRepository.ListarUmMedico(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Consultas consulta)
        {
            try
            {
                if (consulta.IdMedico == null)
                {
                    return BadRequest(new { mensagem = " Vincule um m�dico � consulta!!!" });
                }
                ConsultaRepository.Cadastrar(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize(Roles = "Administrador, Medico")]
        [HttpPut]
        public IActionResult Alterar(Consultas consulta)
        {
            try
            {
                Consultas consultaProcurada = ConsultaRepository.BuscarPorId(consulta.Id);

                if (consultaProcurada == null)
                {
                    return NotFound();
                }

                ConsultaRepository.Alterar(consulta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }


        [Authorize(Roles = "Administrador")]
        [HttpPut] //Colocar Patch para alterar somente um elemento
        [Route("excluir")]
        public IActionResult ExcluirAlteracao(Consultas consulta) //M�todo de alterar o estado de visibilidade da consultas
        {
            try
            {
                Consultas consultaProcurada = ConsultaRepository.BuscarPorId(consulta.Id);

                if (consultaProcurada == null)
                {
                    return NotFound();
                }

                ConsultaRepository.ExcluirAlteracao(consulta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult ExcluirDefinitivamente(int id)  //M�todo de exluir definitivamente os elementos
        {
            try
            {
                Consultas consultaProcurada = ConsultaRepository.BuscarPorId(id);

                if (consultaProcurada == null)
                {
                    return NotFound();
                }

                ConsultaRepository.ExcluirDefinitivamente(consultaProcurada);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int IdUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string IdTypeUser = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value;

                var listaConsultas = ConsultaRepository.Listar(IdUser, IdTypeUser);
                               
                return Ok(listaConsultas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }
    }
}