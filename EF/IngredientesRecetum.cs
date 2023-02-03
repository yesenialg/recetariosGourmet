using System;
using System.Collections.Generic;

namespace EF
{
    public partial class IngredientesRecetum
    {
        public long Id { get; set; }
        public long? IdIngrediente { get; set; }
        public long? IdReceta { get; set; }

        public virtual Ingrediente? IdIngredienteNavigation { get; set; }
        public virtual Recetum? IdRecetaNavigation { get; set; }
    }
}
