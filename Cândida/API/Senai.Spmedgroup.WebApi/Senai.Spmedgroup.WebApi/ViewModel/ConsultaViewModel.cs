using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.ViewModel
{
    public class ConsultaViewModel
    {
        public int ID { get; set; }
        public string NomeMedico { get; set; }
        public string EmailPaciente { get; set; }
        public string NomePaciente { get; set; }
        public string EmailMedico { get; set; }
        public string Especialidade { get; set; }

        public string DataConsulta { get; set; }
        public string Situacao { get; set; }
        public string Descricao { get; set; }
    }
}
