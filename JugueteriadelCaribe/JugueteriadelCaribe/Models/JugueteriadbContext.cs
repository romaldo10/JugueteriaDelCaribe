using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JugueteriadelCaribe.Models;

public partial class JugueteriadbContext : DbContext
{
    public JugueteriadbContext()
    {
    }

    public JugueteriadbContext(DbContextOptions<JugueteriadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Juguete> Juguetes { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
     //   => optionsBuilder.UseSqlServer("server=cuspry\\SQLEXPRESS; database=jugueteriadb; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Juguete>(entity =>
        {
            entity.HasKey(e => e.PkJuguete).HasName("PK__Juguetes__73EF4C0364CBF4C6");

            entity.Property(e => e.PkJuguete).HasColumnName("pkJuguete");
            entity.Property(e => e.Costo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("dateTime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
