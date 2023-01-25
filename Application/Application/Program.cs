// See https://aka.ms/new-console-template for more information
using Gourmet;

Console.WriteLine("Hello, World!");


var vegetales = new Tipo("vegetales");
var cereales = new Tipo("cereales");
var carnes = new Tipo("cereales");

var gramos = new Unidad("gramos");
var libra = new Unidad("libra");
var unidad = new Unidad("unidad");

var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
var pechuga = new IngredienteCuantitativo("Pechuga", 115, unidad, carnes);

Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
var receta1 = new Receta("Receta1", ingredientes1);

var carnivoro = new Perfil("carnivoro");

var apta = carnivoro.RecetaApta(receta1);

Console.WriteLine("Apta {0}", apta);