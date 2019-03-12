using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using Senai.SpMedGroup.WebApi.Repositories;
using System;
using System.Linq;

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

        [Authorize]
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

        [Authorize]
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

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Consultas consulta)
        {
            try
            {
                if (consulta.IdMedico == null)
                {
                    return BadRequest(new { mensagem = " Vincule um médico à consulta!!!" });
                }
                ConsultaRepository.Cadastrar(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize(Roles = "1,3")]
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

        [Authorize(Roles = "1")]
        [HttpPut]
        [Route("excluir")]
        public IActionResult Excluir(Consultas consulta)
        {
            try
            {
                Consultas consultaProcurada = ConsultaRepository.BuscarPorId(consulta.Id);

                if (consultaProcurada == null)
                {
                    return NotFound();
                }

                ConsultaRepository.Excluir(consulta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }
    }
}