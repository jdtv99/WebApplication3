using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication3.Models
{
    public partial class Prueba01Context : DbContext
    {
        public Prueba01Context()
        {
        }

        public Prueba01Context(DbContextOptions<Prueba01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Direccione> Direcciones { get; set; } = null!;
        public virtual DbSet<Instructore> Instructores { get; set; } = null!;
        public virtual DbSet<Perfile> Perfiles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NCursos).HasColumnName("nCursos");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Duracion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Ilustracion).IsUnicode(false);

                entity.Property(e => e.InstructorTitularId).HasColumnName("InstructorTitular_Id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cursos_categoria");

                entity.HasOne(d => d.InstructorAuxiliarNavigation)
                    .WithMany(p => p.CursoInstructorAuxiliarNavigations)
                    .HasForeignKey(d => d.InstructorAuxiliar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cursos_instructores1");

                entity.HasOne(d => d.InstructorTitular)
                    .WithMany(p => p.CursoInstructorTitulars)
                    .HasForeignKey(d => d.InstructorTitularId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cursos_instructores");
            });

            modelBuilder.Entity<Direccione>(entity =>
            {
                entity.ToTable("direcciones");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Calle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Instructore>(entity =>
            {
                entity.ToTable("instructores");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apaterno)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APaterno");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoraClase).HasColumnName("horaClase");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlFoto).IsUnicode(false);
            });

            modelBuilder.Entity<Perfile>(entity =>
            {
                entity.ToTable("perfiles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APaterno");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FecNac).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.HasOne(d => d.Direccion)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.DireccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarios_direcciones");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarios_perfiles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
