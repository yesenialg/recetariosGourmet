namespace Gourmet;

public class Ingrediente
{
    public string Nombre { get; set; }
    public int Caloriasporunidad { get; set; }
    public string Unidad { get; set; }
    public string Tipo { get; set; }

    public Ingrediente(string nombre, int calorias, string unidad, string tipo)
    {
        this.Nombre = nombre;
        this.Caloriasporunidad = calorias;
        this.Unidad = unidad;
        this.Tipo = tipo;
    }
}