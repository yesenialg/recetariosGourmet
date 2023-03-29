namespace Gourmet.ContextDB;
using Gourmet;
using Gourmet.Ingredientes;
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
    public virtual DbSet<Ingrediente> Ingredientes { get; set; } = null!;
    public virtual DbSet<IngredienteCuantitativo> IngredienteCuantitativo { get; set; } = null!;
    public virtual DbSet<IngredientesReceta> IngredientesReceta { get; set; } = null!;
    public virtual DbSet<Recetario> Recetarios { get; set; } = null!;
    public virtual DbSet<Receta> Recetas { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ylopez\\AppData\\Local\\DBRecetarios.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.ToTable("Ingredientes");
        });


        modelBuilder.Entity<Receta>()
            .HasMany(p => p.Ingredientes)
            .WithMany(p => p.Recetas)
            .UsingEntity<IngredientesReceta>(
                j => j
                    .HasOne(pt => pt.Ingrediente)
                    .WithMany(t => t.IngredientesReceta)
                    .HasForeignKey(pt => pt.IngredienteId),
                j => j
                    .HasOne(pt => pt.Receta)
                    .WithMany(p => p.IngredientesReceta)
                    .HasForeignKey(pt => pt.RecetaId),
                j =>
                {
                    j.Property(pt => pt.CantidadIngrediente);
                    j.HasKey(t => new { t.RecetaId, t.IngredienteId });
                });

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

