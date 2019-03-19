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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SpMedGroupContext ctx = new SpMedGroupContext())
                {
                    return Ok(ctx.Usuarios.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }

        [Authorize(Roles = "Administrador,Medico")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Usuarios usuarioProcurado = UsuarioRepository.BuscarPorId(id);

            if (usuarioProcurado == null)
            {
                return NotFound();
            }

            return Ok(usuarioProcurado);
        }


        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + " ERROOO" });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Alterar(Usuarios usuario)
        {
            try
            {
                Usuarios usuarioProcurado = UsuarioRepository.BuscarPorId(usuario.Id);

                if (usuarioProcurado == null)
                {
                    return NotFound();
                }

                UsuarioRepository.Alterar(usuario);

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
                Usuarios usuarioProcurado = UsuarioRepository.BuscarPorId(id);

                if (usuarioProcurado == null)
                {
                    return NotFound();
                }

                UsuarioRepository.Excluir(usuarioProcurado);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERROOO" });
            }
        }
    }
}