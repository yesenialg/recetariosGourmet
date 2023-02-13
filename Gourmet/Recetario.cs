namespace Gourmet;
using Gourmet;
using System.Text.Json.Nodes;

public partial class Recetario
{
    public Recetario()
    {
        RecetasRecetarios = new HashSet<RecetasRecetario>();
    }

    public long Id { get; set; }
    public string? Titulo { get; set; }

    public virtual ICollection<RecetasRecetario> RecetasRecetarios { get; set; }
    

    public int CantidadRecetas()
    {
        return RecetasRecetarios.Count;
    }

    public int EditarRecetario(long id, string nuevoTitulo)
    {
        using var context = new DBRecetariosContext();
        var recetario = context.Recetarios.Find(id);
        recetario.Titulo = nuevoTitulo;
        return context.SaveChanges();
    }

    public void EliminarRecetario()
    {
        using var context = new DBRecetariosContext();
        var recetasDeRecetario = context.RecetasRecetarios.Where(s => s.IdRecetario == Id).ToList();

        foreach (var i in recetasDeRecetario)
        {
            i.EliminarRecetaRecetario();
        }
    }
}