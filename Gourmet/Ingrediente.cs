namespace Gourmet;

public class Ingrediente
{
    public string Nombre { get; set; }
    public int Caloriasporunidad { get; set; }
    public Unidad Unidad { get; set; }
    public Tipo Tipo { get; set; }

    public Ingrediente(string nombre, int calorias, Unidad unidad, Tipo tipo)
    {
        this.Nombre = nombre;
        this.Caloriasporunidad = calorias;
        this.Unidad = unidad;
        this.Tipo = tipo;
    }
}