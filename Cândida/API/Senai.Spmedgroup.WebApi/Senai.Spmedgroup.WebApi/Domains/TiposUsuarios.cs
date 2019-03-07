using System;
using System.Collections.Generic;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
