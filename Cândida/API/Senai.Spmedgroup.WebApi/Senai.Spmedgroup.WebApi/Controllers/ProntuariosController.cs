using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.Spmedgroup.WebApi.Domains;
using Senai.Spmedgroup.WebApi.Interfaces;
using Senai.Spmedgroup.WebApi.Repositories;

namespace Senai.Spmedgroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuariosController : ControllerBase
    {
        private IProntuarioRepository ProntuarioRepository { get; set; }

        public ProntuariosController ()
        {
            ProntuarioRepository = new ProntuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (MedGroupContext ctx = new MedGroupContext())
                {
                    return Ok(ctx.Prontuarios.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });                    
            }
        }
    }
}