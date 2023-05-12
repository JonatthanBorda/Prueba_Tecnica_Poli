using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Tecnica_Poli.Models;

public partial class DbAppPoliContext : DbContext
{
    public DbAppPoliContext()
    {
    }

    public DbAppPoliContext(DbContextOptions<DbAppPoliContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<TipoDocto> TipoDoctos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=Jonathan_Borda; Database=db_App_Poli; Integrated security=true; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor);

            entity.ToTable("Autor");

            entity.Property(e => e.IdAutor).HasColumnName("id_autor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.FecNacimiento)
                .HasColumnType("date")
                .HasColumnName("fec_nacimiento");
            entity.Property(e => e.IdTipoDocto).HasColumnName("id_tipo_docto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumDocto).HasColumnName("num_docto");

            entity.HasOne(d => d.IdTipoDoctoNavigation).WithMany(p => p.Autors)
                .HasForeignKey(d => d.IdTipoDocto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Autor_Tipo_docto");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.IdEditorial);

            entity.ToTable("Editorial");

            entity.Property(e => e.IdEditorial).HasColumnName("id_editorial");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro);

            entity.ToTable("Libro");

            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.FecPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fec_publicacion");
            entity.Property(e => e.IdAutor).HasColumnName("id_autor");
            entity.Property(e => e.IdEditorial).HasColumnName("id_editorial");
            entity.Property(e => e.NumPaginas).HasColumnName("num_paginas");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libro_Autor");

            entity.HasOne(d => d.IdEditorialNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdEditorial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libro_Editorial");
        });

        modelBuilder.Entity<TipoDocto>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocto);

            entity.ToTable("Tipo_docto");

            entity.Property(e => e.IdTipoDocto).HasColumnName("id_tipo_docto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
