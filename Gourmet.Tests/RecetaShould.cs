using Xunit;
using Gourmet;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;

public class RecetaShould
{

    [Fact]
    public void TestCantidadIngredientes()
    {
        var context = new DBRecetariosContext();

        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        context.Recetas.Add(receta);
        context.SaveChanges();

        var ingredienteReceta = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.libra,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        int cantidad = receta.CantidadIngredientes();

        Assert.Equal(2, cantidad);
    }

    [Fact]
    public void TestCantidadCalorias()
    {
        var context = new DBRecetariosContext();

        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        context.Recetas.Add(receta);
        context.SaveChanges();

        var ingredienteReceta = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.libra,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        double cantidad = receta.CantidadCalorias();

        Assert.Equal(700, cantidad);
    }

    [Fact]
    public void TestPresenciaDeIngredientes()
    {
        var context = new DBRecetariosContext();

        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        context.Recetas.Add(receta);
        context.SaveChanges();

        var ingredienteReceta = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        bool presencia = receta.PresenciaDeIngrediente(ingredienteReceta2.IdIngredienteNavigation);

        Assert.Equal(true, presencia);
    }

    [Fact]
    public void TestPresenciaDeGrupoAlimenticio()
    {
        var context = new DBRecetariosContext();

        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        context.Recetas.Add(receta);
        context.SaveChanges();

        var ingredienteReceta = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.libra,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        bool presencia = receta.PresenciaDeGrupoAlimenticio(Tipo.lacteos);

        Assert.Equal(true, presencia);
    }
}
