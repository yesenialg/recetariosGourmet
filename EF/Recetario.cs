using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Recetario
    {
        public Recetario()
        {
            RecetasRecetarios = new HashSet<RecetasRecetario>();
        }

        public long Id { get; set; }
        public string? Titulo { get; set; }

        public virtual ICollection<RecetasRecetario> RecetasRecetarios { get; set; }
    }
}
