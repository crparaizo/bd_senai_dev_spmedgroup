using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o id do usuário!")]
        public int? IdUsuario { get; set; }
        public string Crm { get; set; }
        [Required(ErrorMessage = "Informe o id da especialidade!")]
        public int? IdEspecialidade { get; set; }
        [Required(ErrorMessage = "Informe o id da clínica!")]
        public int? IdClinica { get; set; }

        public Clinicas IdClinicaNavigation { get; set; }
        public Especialidades IdEspecialidadeNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}