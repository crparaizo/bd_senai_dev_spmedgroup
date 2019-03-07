using System;
using System.Collections.Generic;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Consulta
    {
        public int Id { get; set; }
        public int? IdProntuario { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DataHoraConsulta { get; set; }
        public int? IdSituacao { get; set; }
        public string Descricao { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Prontuarios IdProntuarioNavigation { get; set; }
        public Situacoes IdSituacaoNavigation { get; set; }
    }
}
