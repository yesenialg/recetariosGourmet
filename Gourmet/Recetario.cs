namespace Gourmet;
using Gourmet;
using System.Linq;

public class Recetario
{
    public string Titulo { get; set; }
    public List<Receta> Recetas { get; set; }
    public List<UsuarioPerfil> UsuariosSuscritos { get; set; }
    public List<Ranking> RankingSuscritos { get; set; }

    public List<IPerfil> Perfiles;
    
    public Recetario(string titulo, List<Receta> recetas)
    {
        this.Titulo = titulo;
        this.Recetas = recetas;
        this.UsuariosSuscritos = new List<UsuarioPerfil>();
        this.RankingSuscritos = new List<Ranking>();
        Perfiles = new List<IPerfil>
        {
            new Celiaco(),
            new Carnivoro(),
            new Vegano(),
            new Vegetariano()
        };
    }

    public int CantidadRecetas() => Recetas.Count;
    
    public void SuscribirUsuario(UsuarioPerfil suscripcion) => UsuariosSuscritos.Add(suscripcion);

    public void SuscribirRanking(Ranking suscripcion) => RankingSuscritos.Add(suscripcion);

    public bool DesuscribirUsuario(UsuarioPerfil suscripcion)
    {
        var eliminar = from sus in UsuariosSuscritos
                       where sus.Equals(suscripcion)
                       select sus;
        if (eliminar.ToList().Count != 0)
        {
            UsuariosSuscritos.Remove(eliminar.ToList()[0]);
            return true;
        }
        return false;
    }

    public Receta AgregarReceta(Receta receta)
    {
        Recetas.Add(receta);
        foreach (Ranking ranking in RankingSuscritos)
        {
            if (ranking.Activo)
            {
                ranking.SumarPuntos(receta, 10);
            }
        }
        var perfilesAptos = new List<System.Type>();

        foreach (var perfil in Perfiles)
        {
            if (perfil.RecetaApta(receta))
                perfilesAptos.Add(perfil.GetType());
        }

        foreach (UsuarioPerfil suscrito in UsuariosSuscritos)
        {
            if (perfilesAptos.Contains(suscrito.Perfil.GetType()) && suscrito.Notificar)
            {
                suscrito.EnviarNotificacion(receta);
            }
        }

        return receta;
    }

    public bool DesuscribirRanking(Ranking suscripcion)
    {
        var eliminar = from sus in RankingSuscritos
                       where sus.Equals(suscripcion)
                       select sus;
        if (eliminar.ToList().Count != 0)
        {
            RankingSuscritos.Remove(eliminar.ToList()[0]);
            return true;
        }
        return false;
    }
}