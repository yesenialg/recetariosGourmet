namespace Gourmet;
using Gourmet.Ingredientes;
using SQLitePCL;

public partial class IngredientesReceta
{
    public long Id { get; set; }
    public double CantidadIngrediente { get; set; }

    public Ingrediente Ingrediente { get; set; }
    public Receta Receta { get; set; }

    public virtual long IngredienteId { get; set; }
    public virtual long? RecetaId { get; set; }

    public double CalcularCalorias() => Ingrediente.CalcularCalorias(CantidadIngrediente);

    public bool PresenciaDeIngrediente(Ingrediente ingrediente) => Ingrediente.Nombre.Equals(ingrediente.Nombre);

    public bool PresenciaDeGrupoAlimenticio(Tipo grupo) => Ingrediente.Tipo.Equals(grupo);


}