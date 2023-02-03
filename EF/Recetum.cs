using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Recetum
    {
        public Recetum()
        {
            IngredientesReceta = new HashSet<IngredientesRecetum>();
            RecetasRecetarios = new HashSet<RecetasRecetario>();
        }

        public long Id { get; set; }
        public string? Titulo { get; set; }

        public virtual ICollection<IngredientesRecetum> IngredientesReceta { get; set; }
        public virtual ICollection<RecetasRecetario> RecetasRecetarios { get; set; }
    }
}
