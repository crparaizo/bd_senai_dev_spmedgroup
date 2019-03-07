using System;
using System.Collections.Generic;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string HorarioFuncionamento { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
