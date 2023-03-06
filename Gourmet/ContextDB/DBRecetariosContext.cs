namespace Gourmet.ContextDB;
using Gourmet;
using Gourmet.Ingredientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

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
    public virtual DbSet<RecetasRecetario> RecetasRecetarios { get; set; } = null!;
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


        modelBuilder.Entity<IngredientesReceta>(entity =>
        {
            entity.HasOne(d => d.IdIngredienteNavigation)
                .WithMany(p => p.IngredientesReceta)
                .HasForeignKey(d => d.IdIngrediente);

            entity.HasOne(d => d.IdRecetaNavigation)
                .WithMany(p => p.IngredientesReceta)
                .HasForeignKey(d => d.IdReceta);
        });

        modelBuilder.Entity<Recetario>(entity =>
        {
            entity.ToTable("Recetarios");
        });

        modelBuilder.Entity<RecetasRecetario>(entity =>
        {
            entity.ToTable("RecetasRecetario");

            entity.HasOne(d => d.IdRecetaNavigation)
                .WithMany(p => p.RecetasRecetario)
                .HasForeignKey(d => d.IdReceta);

            entity.HasOne(d => d.IdRecetarioNavigation)
                .WithMany(p => p.RecetasRecetarios)
                .HasForeignKey(d => d.IdRecetario);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

