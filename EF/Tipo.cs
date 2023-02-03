using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Tipo
    {
        public Tipo()
        {
            Ingredientes = new HashSet<Ingrediente>();
        }

        public string? Nombre { get; set; }
        public long Id { get; set; }

        public virtual ICollection<Ingrediente> Ingredientes { get; set; }
    }
}
