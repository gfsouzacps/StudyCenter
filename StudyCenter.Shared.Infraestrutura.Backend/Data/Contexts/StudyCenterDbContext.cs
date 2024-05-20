using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

public partial class StudyCenterDbContext : DbContext
{
    public StudyCenterDbContext()
    {
    }

    public StudyCenterDbContext(DbContextOptions<StudyCenterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnotacoesTopicos> AnotacoesTopicos { get; set; }

    public virtual DbSet<Materias> Materias { get; set; }

    public virtual DbSet<SessaoTopicos> SessaoTopicos { get; set; }

    public virtual DbSet<Sessoes> Sessoes { get; set; }

    public virtual DbSet<Topicos> Topicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=StudyCenter;User Id=sa;Password=admin;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnotacoesTopicos>(entity =>
        {
            entity.HasKey(e => e.IdAnotacaoTopico).HasName("PK__ANOTACOE__1BA58A28055811C1");

            entity.ToTable("ANOTACOES_TOPICOS");

            entity.Property(e => e.IdAnotacaoTopico)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_anotacao_topico");
            entity.Property(e => e.Anotacao).HasColumnName("anotacao");
            entity.Property(e => e.IdSessaoTopico).HasColumnName("id_sessao_topico");

            entity.HasOne(d => d.IdSessaoTopicoNavigation).WithMany(p => p.AnotacoesTopicos)
                .HasForeignKey(d => d.IdSessaoTopico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ANOTACOES__id_se__7F2BE32F");
        });

        modelBuilder.Entity<Materias>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__MATERIA__7E03FD393345A71A");

            entity.ToTable("MATERIAS");

            entity.Property(e => e.IdMateria)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_materia");
            entity.Property(e => e.NomeMateria)
                .HasMaxLength(100)
                .HasColumnName("nome_materia");
        });

        modelBuilder.Entity<SessaoTopicos>(entity =>
        {
            entity.HasKey(e => e.IdSessaoTopico).HasName("PK__SESSAO_T__04AEBD2336966A8E");

            entity.ToTable("SESSAO_TOPICOS");

            entity.Property(e => e.IdSessaoTopico)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_sessao_topico");
            entity.Property(e => e.DuracaoEstudo)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("duracao_estudo");
            entity.Property(e => e.IdSessao).HasColumnName("id_sessao");
            entity.Property(e => e.IdTopico).HasColumnName("id_topico");

            entity.HasOne(d => d.IdSessaoNavigation).WithMany(p => p.SessaoTopicos)
                .HasForeignKey(d => d.IdSessao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SESSAO_TO__id_se__74AE54BC");

            entity.HasOne(d => d.IdTopicoNavigation).WithMany(p => p.SessaoTopicos)
                .HasForeignKey(d => d.IdTopico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SESSAO_TO__id_to__4E88ABD4");
        });

        modelBuilder.Entity<Sessoes>(entity =>
        {
            entity.HasKey(e => e.IdSessao).HasName("PK__SESSOES__D45775D4E1DE3145");

            entity.ToTable("SESSOES");

            entity.Property(e => e.IdSessao)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_sessao");
            entity.Property(e => e.AnotacaoSessao).HasColumnName("anotacao_sessao");
            entity.Property(e => e.DthrFimSessao)
                .HasColumnType("datetime")
                .HasColumnName("dthr_fim_sessao");
            entity.Property(e => e.DthrInicioSessao)
                .HasColumnType("datetime")
                .HasColumnName("dthr_inicio_sessao");
            entity.Property(e => e.NomeSessao)
                .HasMaxLength(200)
                .HasColumnName("nome_sessao");
        });

        modelBuilder.Entity<Topicos>(entity =>
        {
            entity.HasKey(e => e.IdTopico).HasName("PK__TOPICOS__C013E49EA500749A");

            entity.ToTable("TOPICOS");

            entity.Property(e => e.IdTopico)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_topico");
            entity.Property(e => e.IdMateria).HasColumnName("id_materia");
            entity.Property(e => e.NomeTopico)
                .HasMaxLength(100)
                .HasColumnName("nome_topico");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.Topicos)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__TOPICOS__id_mate__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
