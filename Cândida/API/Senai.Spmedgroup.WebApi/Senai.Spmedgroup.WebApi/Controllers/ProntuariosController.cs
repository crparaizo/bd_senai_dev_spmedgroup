using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using Senai.SpMedGroup.WebApi.Repositories;

namespace Senai.SpMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuariosController : ControllerBase
    {
        private IProntuarioRepository ProntuarioRepository { get; set; }

        public ProntuariosController()
        {
            ProntuarioRepository = new ProntuarioRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SpMedGroupContext ctx = new SpMedGroupContext())
                {
                    return Ok(ProntuarioRepository.Listar());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            Prontuarios prontuarioProcurado = ProntuarioRepository.BuscarPorId(id);

            if (prontuarioProcurado == null)
            {
                return NotFound();
            }

            return Ok(prontuarioProcurado);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar (Prontuarios prontuario)
        {
            try
            {
                prontuario.Consultas = null;
                ProntuarioRepository.Cadastrar(prontuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult Alterar (Prontuarios prontuario)
        {
            try
            {
                Prontuarios prontuarioProcurado = ProntuarioRepository.BuscarPorId(prontuario.Id);

                if (prontuarioProcurado == null)
                {
                    return NotFound();
                }

                ProntuarioRepository.Alterar(prontuario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize]
        [HttpDelete ("{id}")]
        public IActionResult Excluir (int id)
        {
            try
            {
                Prontuarios prontuarioProcurado = ProntuarioRepository.BuscarPorId(id);

                if (prontuarioProcurado == null)
                {
                    return NotFound();
                }

                ProntuarioRepository.Excluir(prontuarioProcurado);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }
    }
}