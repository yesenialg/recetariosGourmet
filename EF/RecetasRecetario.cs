using System;
using System.Collections.Generic;

namespace EF
{
    public partial class RecetasRecetario
    {
        public long Id { get; set; }
        public long? IdReceta { get; set; }
        public long? IdRecetario { get; set; }

        public virtual Recetum? IdRecetaNavigation { get; set; }
        public virtual Recetario? IdRecetarioNavigation { get; set; }
    }
}
