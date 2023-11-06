using System;
using System.Collections.Generic;
using Core.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public partial class EjercicioContext : DbContext
{
    public EjercicioContext()
    {
    }

    public EjercicioContext(DbContextOptions<EjercicioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dependencium> Dependencia { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }
    public virtual DbSet<Respuesta> Respuesta { get; set; }
    public object Dependencias { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dependencium>(entity =>
        {
            entity.ToTable("dependencia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreDependencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_dependencia");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.ToTable("empresa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DireccionEmpresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion_empresa");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_empresa");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable("personas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.IdDependencias).HasColumnName("id_dependencias");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Identificacion).HasColumnName("identificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sexo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("sexo");
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo_identificacion");

           
            
            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_personas_empresa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
