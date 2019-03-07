using System;
using System.Collections.Generic;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Situacoes
    {
        public Situacoes()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Consulta> Consulta { get; set; }
    }
}
