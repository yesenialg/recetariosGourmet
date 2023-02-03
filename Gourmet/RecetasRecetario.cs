namespace Gourmet;
using Gourmet;

public partial class RecetasRecetario
{
    public long Id { get; set; }
    public long IdReceta { get; set; }
    public long IdRecetario { get; set; }

    public virtual Receta? IdRecetaNavigation { get; set; }
    public virtual Recetario? IdRecetarioNavigation { get; set; }

    public void EliminarRecetaRecetario()
    {
        using var context = new DBRecetariosContext();
        context.RecetasRecetarios.Remove(this);
        context.SaveChanges();
    }
}