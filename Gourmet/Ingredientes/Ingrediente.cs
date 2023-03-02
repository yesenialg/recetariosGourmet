﻿namespace Gourmet;

public enum Tipo
{
    carnes, 
    legumbres,
    vegetales,
    cereales,
    lacteos
};

public enum Unidad
{
    gramos,
    libra,
    unidad
}

public class Ingrediente
{
    public string Nombre { get; set; }
    public int Calorias { get; set; }
    public Unidad Unidad { get; set; }
    public Tipo Tipo { get; set; }

    public Ingrediente(string nombre, int calorias, Unidad unidad, Tipo tipo)
    {
        Nombre = nombre;
        Calorias = calorias;
        Unidad = unidad;
        Tipo = tipo;
    }

    public double CalcularCalorias() => Calorias;
}