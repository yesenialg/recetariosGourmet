namespace Gourmet;
using Gourmet;
using Gourmet.ContextDB;
using Gourmet.Repositories;
using Gourmet.Services;
using Gourmet.Services.Contracts;

public partial class Recetario
{
    private readonly IRecetasRecetarioService _recetasRecetarioService = new RecetasRecetarioService(new RecetasRecetarioRepository(new DBRecetariosContext()));

    public Recetario()
    {
        RecetasRecetarios = new HashSet<RecetasRecetario>();
    }

    public long Id { get; set; }
    public string? Titulo { get; set; }

    public virtual ICollection<RecetasRecetario> RecetasRecetarios { get; set; }

    public int CantidadRecetas()
    {
        return _recetasRecetarioService.GetRecetasDeRecetario(Id).Count();
    }
}