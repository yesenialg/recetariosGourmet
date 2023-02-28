// See https://aka.ms/new-console-template for more information
using Gourmet;

Console.WriteLine("Hello, World!");


var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
var receta1 = new Receta("Receta1", ingredientes1);

Dictionary<IngredienteCuantitativo, double> ingredientes2 = new Dictionary<IngredienteCuantitativo, double>
        {
            { pechuga, 1},
            { brocoli, 1},
        };

var receta2 = new Receta("Receta2", ingredientes2);

List<Receta> recetas = new List<Receta>() { receta2 };

var recetario = new Recetario("Recetario1", recetas);

Ranking ranking1 = new("Ranking1", true);
ranking1.AgregarReceta(receta1);


recetario.SuscribirRanking(ranking1);
recetario.AgregarReceta(receta1);

Console.WriteLine(ranking1.Recetas[receta1]);