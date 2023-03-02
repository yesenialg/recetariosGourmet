namespace Gourmet;

public class Ranking
{
    public string Nombre { get; set; }
    public Dictionary<Receta, double> Recetas { get; set; }
    public bool Activo { get; set; }
    public Ranking(string nombre, bool activo)
    {
        this.Nombre = nombre;
        this.Activo = activo;
        this.Recetas = new Dictionary<Receta, double>();
    }

    public void CambiarEstado(bool estado) => this.Activo = estado;

    public void AgregarReceta(Receta receta) => Recetas.Add(receta, 0);
    
    public void SumarPuntos(Receta receta, double puntos)
    {
        try
        {
            Recetas[receta] = Recetas[receta] + puntos;
        }catch (Exception ex)
        {
            Console.WriteLine("La receta no existe en el Ranking");
            Console.WriteLine(ex.Message);
        }
    }
}