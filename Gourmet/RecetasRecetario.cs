namespace Gourmet;
using Gourmet;

public partial class RecetasRecetario
{
    public long Id { get; set; }
    public long IdReceta { get; set; }
    public long IdRecetario { get; set; }

    public virtual Recetas? IdRecetaNavigation { get; set; }
    public virtual Recetarios? IdRecetarioNavigation { get; set; }

    public void EliminarRecetaRecetario()
    {
        using var context = new DBRecetariosContext();
        context.RecetasRecetarios.Remove(this);
        context.SaveChanges();
    }
}