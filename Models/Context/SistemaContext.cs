using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Models.Context;

public partial class SistemaContext : DbContext
{
    public SistemaContext()
    {
    }

    public SistemaContext(DbContextOptions<SistemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<ClienteProveedor> ClienteProveedors { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<SubCategoria> SubCategoria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SistemaDeGestion;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07437C86A5");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClienteProveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClienteP__3214EC07D7EF095A");

            entity.ToTable("ClienteProveedor");

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cuit)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07D288070F");

            entity.Property(e => e.Cantidad).HasDefaultValue(0);
            entity.Property(e => e.CostoDolar).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CostoPesos).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.ValorDolar).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValorDolarMomentoCompra).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValorPesos).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ClienteProveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ClienteProveedorId)
                .HasConstraintName("FK__Productos__Clien__3F466844");

            entity.HasOne(d => d.SubCategoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.SubCategoriaId)
                .HasConstraintName("FK__Productos__SubCa__403A8C7D");
        });

        modelBuilder.Entity<SubCategoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubCateg__3214EC07DEBB6F73");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.SubCategoria)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__Categ__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
