using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leonardo.LabschoolProjeto.Models;

public partial class LabSchoolContexto : DbContext
{
    public LabSchoolContexto()
    {
    }

    public LabSchoolContexto(DbContextOptions<LabSchoolContexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Pedagogo> Pedagogos { get; set; }

    public virtual DbSet<Professor> Professores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0DDC6L9\\SQLEXPRESS;Database=Leonardo.Labschoolbd;User ID=sa;Password=321lelele;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Aluno__06370DAD4AF933C0");

            entity.ToTable("Aluno");

            entity.HasIndex(e => e.Telefone, "UQ__Aluno__2A16D97F3A89CA5F").IsUnique();

            entity.HasIndex(e => e.Nome, "UQ__Aluno__7D8FE3B26C774E0D").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__Aluno__C1FF930971915FB4").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DataDeNascimento)
                .HasColumnType("datetime")
                .HasColumnName("Data_De_Nascimento");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.QtdAtendimentos).HasColumnName("Qtd_Atendimentos");
            entity.Property(e => e.SituacaoDaMatricula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Situacao_Da_Matricula");
            entity.Property(e => e.Telefone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Pedagogo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Pedagogo__06370DAD4ECBB21B");

            entity.ToTable("Pedagogo");

            entity.HasIndex(e => e.Telefone, "UQ__Pedagogo__2A16D97F8129F702").IsUnique();

            entity.HasIndex(e => e.Nome, "UQ__Pedagogo__7D8FE3B2002A6FD4").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__Pedagogo__C1FF9309D7A4AFDC").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DataDeNascimento)
                .HasColumnType("datetime")
                .HasColumnName("Data_De_Nascimento");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.QtdAtendimento).HasColumnName("Qtd_Atendimento");
            entity.Property(e => e.Telefone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Professo__06370DADB0A5C0AF");

            entity.HasIndex(e => e.Telefone, "UQ__Professo__2A16D97FE2006866").IsUnique();

            entity.HasIndex(e => e.Nome, "UQ__Professo__7D8FE3B2ABE3C28C").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__Professo__C1FF9309615C059E").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DataDeNascimento)
                .HasColumnType("datetime")
                .HasColumnName("Data_De_Nascimento");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Experiencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FormacaoAcademica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Formacao_Academica");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
