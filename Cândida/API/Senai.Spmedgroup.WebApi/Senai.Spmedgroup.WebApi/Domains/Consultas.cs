using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public int? IdProntuario { get; set; }
        [Required(ErrorMessage = "Informe o id do médico!")]
        public int? IdMedico { get; set; }
        public DateTime DataHoraConsulta { get; set; }
        public int? IdSituacao { get; set; }
        public string Descricao { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Prontuarios IdProntuarioNavigation { get; set; }
        public Situacoes IdSituacaoNavigation { get; set; }
    }
}