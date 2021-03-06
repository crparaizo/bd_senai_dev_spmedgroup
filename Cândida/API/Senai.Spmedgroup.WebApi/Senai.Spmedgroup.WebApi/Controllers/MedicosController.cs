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

    public class MedicosController : ControllerBase
    {
        private IMedicoRepository MedicoRepository { get; set; }

        public MedicosController()
        {
            MedicoRepository = new MedicoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SpMedGroupContext ctx = new SpMedGroupContext())
                {
                    return Ok(MedicoRepository.Listar());
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
            Medicos medicoProcurado = MedicoRepository.BuscarPorId(id);

            if (medicoProcurado == null)
            {
                return NotFound();
            }

            return Ok(medicoProcurado);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Medicos medico)
        {
            try
            {
                MedicoRepository.Cadastrar(medico);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Alterar(Medicos medico)
        {
            try
            {
                Medicos medicoProcurado = MedicoRepository.BuscarPorId(medico.Id);

                if (medicoProcurado == null)
                {
                    
                }

                MedicoRepository.Alterar(medico);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                Medicos medicoProcurado = MedicoRepository.BuscarPorId(id);

                if (medicoProcurado == null)
                {
                    return NotFound();
                }

                MedicoRepository.Excluir(medicoProcurado);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }
    }
}