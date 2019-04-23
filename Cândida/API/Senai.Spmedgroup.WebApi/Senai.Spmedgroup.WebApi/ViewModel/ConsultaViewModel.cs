using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.ViewModel
{
    public class ConsultaViewModel
    {
        public string NomeMedico { get; set; }
        public string NomePaciente { get; set; }

        public DateTime DataConsulta { get; set; }
        public string Situacao { get; set; }
        public string Descricao { get; set; }
    }
}
