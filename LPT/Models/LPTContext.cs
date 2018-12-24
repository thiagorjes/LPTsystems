using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LPT.Models
{
    public partial class LPTContext : DbContext
    {
        public LPTContext()
        {
        }

        public LPTContext(DbContextOptions<LPTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DadoColetado> DadoColetado { get; set; }
        public virtual DbSet<Experimento> Experimento { get; set; }
        public virtual DbSet<Grandeza> Grandeza { get; set; }
        public virtual DbSet<MedidorExperimento> MedidorExperimento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=10.10.10.211;port=3306;user=root;password=godz3Ufes:@;database=LPT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<DadoColetado>(entity =>
            {
                entity.HasKey(e => e.IdDadoColetado);

                entity.ToTable("dadoColetado", "LPT");

                entity.HasIndex(e => e.Experimento)
                    .HasName("fk_experimento_dadocoletado_idx");

                entity.HasIndex(e => e.TipoDeGrandeza)
                    .HasName("fk_grandeza_dadocoletado_idx");

                entity.Property(e => e.IdDadoColetado)
                    .HasColumnName("idDadoColetado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ColetadoEm).HasColumnName("coletadoEm");

                entity.Property(e => e.Experimento)
                    .HasColumnName("experimento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Hwid)
                    .IsRequired()
                    .HasColumnName("HWID")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeGrandeza)
                    .HasColumnName("tipoDeGrandeza")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorLido).HasColumnName("valorLido");

                entity.HasOne(d => d.ExperimentoNavigation)
                    .WithMany(p => p.DadoColetado)
                    .HasForeignKey(d => d.Experimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_experimento_dadocoletado");

                entity.HasOne(d => d.TipoDeGrandezaNavigation)
                    .WithMany(p => p.DadoColetado)
                    .HasForeignKey(d => d.TipoDeGrandeza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_grandeza_dadocoletado");
            });

            modelBuilder.Entity<Experimento>(entity =>
            {
                entity.HasKey(e => e.IdExperimento);

                entity.ToTable("experimento", "LPT");

                entity.Property(e => e.IdExperimento)
                    .HasColumnName("idExperimento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataFim).HasColumnName("dataFim");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<Grandeza>(entity =>
            {
                entity.HasKey(e => e.IdGrandeza);

                entity.ToTable("grandeza", "LPT");

                entity.Property(e => e.IdGrandeza)
                    .HasColumnName("idGrandeza")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedidorExperimento>(entity =>
            {
                entity.HasKey(e => e.IdMedidorExperimento);

                entity.ToTable("medidorExperimento", "LPT");

                entity.HasIndex(e => e.Experimento)
                    .HasName("fk_experimento_medidor_idx");

                entity.Property(e => e.IdMedidorExperimento)
                    .HasColumnName("idMedidorExperimento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Experimento).HasColumnType("int(11)");

                entity.Property(e => e.Medidor)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExperimentoNavigation)
                    .WithMany(p => p.MedidorExperimento)
                    .HasForeignKey(d => d.Experimento)
                    .HasConstraintName("fk_experimento_medidor");
            });
        }
    }
}
