using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Gourmet;

public class MyContext : DbContext
{
    public DbSet<Tipo> Tipos { get; set; }
    public DbSet<Unidad> Unidades { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingrediente>()
        .HasOne(b => b.Tipo)
        .WithOne();

        modelBuilder.Entity<Ingrediente>()
        .HasOne(b => b.Unidad)
        .WithOne();
    }

    public string DbPath { get; }

    public MyContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "recetarios.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}