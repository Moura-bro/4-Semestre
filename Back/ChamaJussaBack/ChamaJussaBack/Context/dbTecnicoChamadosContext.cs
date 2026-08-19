using System;
using System.Collections.Generic;
using ChamaJussaBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ChamaJussaBack.Context;

public partial class dbTecnicoChamadosContext : DbContext
{
    public dbTecnicoChamadosContext()
    {
    }

    public dbTecnicoChamadosContext(DbContextOptions<dbTecnicoChamadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chamado> Chamados { get; set; }

    public virtual DbSet<Notificacao> Notificacaos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=dbTecnico_Chamados;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chamado>(entity =>
        {
            entity.HasKey(e => e.IdChamado).HasName("PK__Chamado__F79110FFA7B1D3A4");

            entity.Property(e => e.IdChamado).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Chamados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chamado__IdUsuar__628FA481");
        });

        modelBuilder.Entity<Notificacao>(entity =>
        {
            entity.HasKey(e => e.IdNotificacao).HasName("PK__Notifica__4955F61DAF18B49F");

            entity.Property(e => e.IdNotificacao).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DataNotificacao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Verificada).HasDefaultValue(false);

            entity.HasOne(d => d.IdChamadoNavigation).WithMany(p => p.Notificacaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__IdCha__68487DD7");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificacaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__IdUsu__693CA210");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A66AB94017");

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
