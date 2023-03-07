namespace Gourmet;

public class Receta
{
    public string Titulo { get; set; }
    public List<IngredienteCantidad> IngredientesCantidad { get; set; }

    public Receta(string titulo, List<IngredienteCantidad> ingredientesreceta)
    {
        this.Titulo = titulo;
        this.IngredientesCantidad = ingredientesreceta;
    }

    public int CantidadIngredientes() => IngredientesCantidad.Count;

    public double CantidadCalorias() => IngredientesCantidad.Sum(ingrediente => ingrediente.CalcularCalorias());

    public bool PresenciaDeIngrediente(IngredienteCuantitativo ingrediente) => IngredientesCantidad.Any(i => i.CompararIngrediente(ingrediente));

    public bool PresenciaDeGrupoAlimenticio(Tipo grupo) => IngredientesCantidad.Any(ingrediente => ingrediente.GrupoAlimentario().Equals(grupo));
}