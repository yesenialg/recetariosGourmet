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

    public void AgregarReceta(Receta receta)
    {
        Recetas.Add(receta, 0);
    }
    
    public void SumarPuntos(Receta receta, double puntos)
    {
        var recetaEnRanking = from rec in Recetas
                              where rec.Equals(receta)
                       select rec;
        if(recetaEnRanking.ToList().Count != 0 )
        {
            Recetas[receta] = Recetas[receta] + puntos;
        }
    }

    public void CambiarEstado(bool estado)
    {
        this.Activo = estado;
    }
}