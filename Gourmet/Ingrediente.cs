namespace Gourmet;

public class Ingrediente
{
    public string Nombre { get; set; }
    public int Calorias { get; set; }
    public Unidad Unidad { get; set; }
    public Tipo Tipo { get; set; }

    public Ingrediente(string nombre, int calorias, Unidad unidad, Tipo tipo)
    {
        this.Nombre = nombre;
        this.Calorias = calorias;
        this.Unidad = unidad;
        this.Tipo = tipo;
    }

    public double calcularCalorias()
    {
        return Calorias;
    }
}