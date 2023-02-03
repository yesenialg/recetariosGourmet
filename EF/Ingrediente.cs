using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            IngredientesReceta = new HashSet<IngredientesRecetum>();
        }

        public string Nombre { get; set; }
        public long Id { get; set; }
        public long IdTipo { get; set; }
        public long IdUnidad { get; set; }
        public long Calorias { get; set; }

        public virtual Tipo? IdTipoNavigation { get; set; }
        public virtual Unidad? IdUnidadNavigation { get; set; }
        public virtual ICollection<IngredientesRecetum> IngredientesReceta { get; set; }

        public long CalcularCalorias()
        {
            return Calorias;
        }
    }
}
