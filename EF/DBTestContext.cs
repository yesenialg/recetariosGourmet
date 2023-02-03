using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF
{
    public partial class DBTestContext : DbContext
    {
        public DBTestContext()
        {
        }

        public DBTestContext(DbContextOptions<DBTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingrediente> Ingredientes { get; set; } = null!;
        public virtual DbSet<IngredientesRecetum> IngredientesReceta { get; set; } = null!;
        public virtual DbSet<Recetario> Recetarios { get; set; } = null!;
        public virtual DbSet<RecetasRecetario> RecetasRecetarios { get; set; } = null!;
        public virtual DbSet<Recetum> Receta { get; set; } = null!;
        public virtual DbSet<Tipo> Tipos { get; set; } = null!;
        public virtual DbSet<Unidad> Unidads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\ylopez\\AppData\\Local\\DBTest.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.ToTable("Ingrediente");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Ingredientes)
                    .HasForeignKey(d => d.IdTipo);

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.Ingredientes)
                    .HasForeignKey(d => d.IdUnidad);
            });

            modelBuilder.Entity<IngredientesRecetum>(entity =>
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
                entity.ToTable("Recetario");
            });

            modelBuilder.Entity<RecetasRecetario>(entity =>
            {
                entity.ToTable("RecetasRecetario");

                entity.HasOne(d => d.IdRecetaNavigation)
                    .WithMany(p => p.RecetasRecetarios)
                    .HasForeignKey(d => d.IdReceta);

                entity.HasOne(d => d.IdRecetarioNavigation)
                    .WithMany(p => p.RecetasRecetarios)
                    .HasForeignKey(d => d.IdRecetario);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("Tipo");
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.ToTable("Unidad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
