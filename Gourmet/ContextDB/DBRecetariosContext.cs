namespace Gourmet.ContextDB;
using Gourmet;
using Microsoft.EntityFrameworkCore;

public partial class DBRecetariosContext : DbContext
{
    public DBRecetariosContext()
    {
    }
    public DBRecetariosContext(DbContextOptions<DBRecetariosContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Recetario> Recetarios { get; set; } = null!;
    public virtual DbSet<Receta> Recetas { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ylopez\\AppData\\Local\\DBRecetariosEnfasis.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Receta>();

        modelBuilder.Entity<Recetario>(entity =>
        {
            entity.ToTable("Recetarios");
        });

        modelBuilder.Entity<Recetario>()
            .HasMany(p => p.Recetas)
            .WithMany(p => p.Recetarios)
            .UsingEntity(j => j.ToTable("RecetasRecetario"));   

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

