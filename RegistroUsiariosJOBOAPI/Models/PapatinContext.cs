using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RegistroUsiariosJOBOAPI.Models;

public partial class PapatinContext : DbContext
{
    public PapatinContext()
    {
    }

    public PapatinContext(DbContextOptions<PapatinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioAuditorium> UsuarioAuditoria { get; set; }

    public virtual DbSet<VUsuario> VUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__DF3D425281547A05");

            entity.ToTable("usuario", tb => tb.HasTrigger("Tr_Usuario_Alta"));

            entity.HasIndex(e => e.Correo, "UQ__usuario__60695A1924041B26").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioAuditorium>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioauditoria).HasName("PK__usuarioA__5617D5F9EC4956D1");

            entity.ToTable("usuarioAuditoria");

            entity.Property(e => e.IdUsuarioauditoria).HasColumnName("ID_usuarioauditoria");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaAuditoria)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Movimientoauditoria)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuarioauditoria)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Usuario");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
