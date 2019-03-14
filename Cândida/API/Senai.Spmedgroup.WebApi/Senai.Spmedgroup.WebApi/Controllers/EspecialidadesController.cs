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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadeRepository EspecialidadeRepository { get; set; }

        public EspecialidadesController()
        {
            EspecialidadeRepository = new EspecialidadeRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SpMedGroupContext ctx = new SpMedGroupContext())
                {
                    return Ok(ctx.Especialidades.ToList());
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
            Especialidades especialidadeProcurada = EspecialidadeRepository.BuscarPorId(id);

            if (especialidadeProcurada == null)
            {
                return NotFound();
            }

            return Ok(especialidadeProcurada);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Especialidades especialidade)
        {
            try
            {
                EspecialidadeRepository.Cadastrar(especialidade);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Alterar(Especialidades especialidade)
        {
            try
            {
                Especialidades especialidadeProcurada = EspecialidadeRepository.BuscarPorId(especialidade.Id);

                if (especialidadeProcurada == null)
                {
                    return NotFound();
                }

                EspecialidadeRepository.Alterar(especialidade);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                Especialidades especialidadeProcurada = EspecialidadeRepository.BuscarPorId(id);

                if (especialidadeProcurada == null)
                {
                    return NotFound();
                }

                EspecialidadeRepository.Excluir(especialidadeProcurada);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }
    }
}