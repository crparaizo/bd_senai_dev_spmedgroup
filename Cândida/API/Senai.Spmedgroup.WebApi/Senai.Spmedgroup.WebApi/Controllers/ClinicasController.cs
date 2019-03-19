using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using Senai.SpMedGroup.WebApi.Repositories;

namespace Senai.SpMedGroup.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository ClinicaRepository { get; set; }

        public ClinicasController()
        {
            ClinicaRepository = new ClinicaRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SpMedGroupContext ctx = new SpMedGroupContext ())
                {
                    return Ok(ctx.Clinicas.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post (Clinicas clinica)
        {
            try
            {
                ClinicaRepository.Cadastrar(clinica);
                return Ok();
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
            Clinicas clinicaProcurada = ClinicaRepository.BuscarPorId(id);

            if (clinicaProcurada == null)
            {
                return NotFound();
            }

            return Ok(clinicaProcurada);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Alterar(Clinicas clinica)
        {
            try
            {
                Clinicas clinicaProcurada = ClinicaRepository.BuscarPorId(clinica.Id);

                if (clinicaProcurada == null)
                {
                    return NotFound();
                }

                ClinicaRepository.Alterar(clinica);

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
                Clinicas clinicaProcurada = ClinicaRepository.BuscarPorId(id);

                if (clinicaProcurada == null)
                {
                    return NotFound();
                }

                ClinicaRepository.Excluir(clinicaProcurada);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }
    }
}