using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ToDoListBdContext : DbContext
{
    public ToDoListBdContext()
    {
    }

    public ToDoListBdContext(DbContextOptions<ToDoListBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Tarea1> Tareas1 { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioTareasAsignada> UsuarioTareasAsignadas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=ToDoListBD;Trusted_Connection=True; User ID=sa; Password=pass@word1;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC1B23936DC");

            entity.ToTable("Estado");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__EADE90982E463275");

            entity.ToTable("Tarea");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Tarea__IdEstado__145C0A3F");
        });

        modelBuilder.Entity<Tarea1>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tareas__EADE9098C6801E26");

            entity.ToTable("Tareas");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Tarea1s)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Tareas__IdEstado__1B0907CE");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tarea1s)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Tareas__IdUsuari__1BFD2C07");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF9760646F80");

            entity.ToTable("Usuario");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioTareasAsignada>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.IdTareaNavigation).WithMany()
                .HasForeignKey(d => d.IdTarea)
                .HasConstraintName("FK__UsuarioTa__IdTar__173876EA");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioTa__IdUsu__164452B1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
