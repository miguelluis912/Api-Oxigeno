using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api_Oxigeno.Models;

namespace Api_Oxigeno.Config
{
    public partial class MysqlContext : DbContext
    {
        public MysqlContext()
        {
        }

        public MysqlContext(DbContextOptions<MysqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseMySql("server=localhost;database=db_oxigeno;uid=luis;pwd=luis", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("pacientes");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.IdEntidad, "id_entidad");

                entity.HasIndex(e => e.IdTipoDerechohabiencia, "id_tipo_derechohabiencia");

                entity.HasIndex(e => e.IdUnidad, "id_unidad");

                entity.HasIndex(e => e.IdUser, "id_user");

                entity.HasIndex(e => new { e.IdUnidad, e.IdEntidad }, "pacientes_unidad");

                entity.HasIndex(e => e.TipoPaciente, "tipo_paciente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(191)
                    .HasColumnName("apellidoMaterno")
                    .HasDefaultValueSql("'sin dato'");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(191)
                    .HasColumnName("apellidoPaterno");

                entity.Property(e => e.Correo)
                    .HasMaxLength(191)
                    .HasColumnName("correo");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Curp)
                    .HasMaxLength(191)
                    .HasColumnName("curp");

                entity.Property(e => e.Expediente)
                    .HasMaxLength(191)
                    .HasColumnName("expediente")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");

                entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");

                // entity.Property(e => e.HoraRegistro)
                //     .HasColumnType("time")
                //     .HasColumnName("horaRegistro");

                entity.Property(e => e.IdEntidad).HasColumnName("id_entidad");

                entity.Property(e => e.IdTipoDerechohabiencia).HasColumnName("id_tipo_derechohabiencia");

                entity.Property(e => e.IdUnidad).HasColumnName("id_unidad");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(191)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rfc)
                    .HasMaxLength(191)
                    .HasColumnName("rfc");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(191)
                    .HasColumnName("sexo");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(191)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoPaciente).HasColumnName("tipo_paciente");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
