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

        public virtual DbSet<InscripcionOxigeno> InscripcionOxigenos { get; set; }

        public virtual DbSet<OrdenTrabajo> OrdenTrabajo { get; set; }
        public virtual DbSet<Direccion> Direcciones { get; set; }




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

                // entity.HasOne(e => e.InscripcionOxigeno)
                //     .WithOne(p => p.Paciente)
                //     .HasForeignKey<InscripcionOxigeno>(p => p.IdPaciente)
                //     .HasPrincipalKey<Paciente>(p => p.Id)
                //     .HasConstraintName("FK_datos_medico");

            });

            modelBuilder.Entity<InscripcionOxigeno>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("inscripcion_oxigeno")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Bipap).HasColumnName("bipap");
                entity.Property(e => e.Concentrador).HasColumnName("concentrador");
                entity.Property(e => e.Cpap).HasColumnName("cpap");
                entity.Property(e => e.IdMedico).HasColumnName("id_medico");
                entity.Property(e => e.PacienteId).HasColumnName("id_paciente");
                entity.Property(e => e.IdPrescripcionPaciente).HasColumnName("id_prescripcion_paciente");
                entity.Property(e => e.IdStatusInscripcion).HasColumnName("id_status_inscripcion");
                entity.Property(e => e.IdTipomedico).HasColumnName("id_tipomedico");
                entity.Property(e => e.IdUnidad).HasColumnName("id_unidad");
                entity.Property(e => e.IdUnidadPaciente)
                    .HasMaxLength(191)
                    .HasColumnName("id_unidad_paciente");
                entity.Property(e => e.IdUser).HasColumnName("id_user");
                entity.Property(e => e.LitrosMinuto).HasColumnName("litros_minuto");
                entity.Property(e => e.MesUsoOxigeno).HasColumnName("mes_uso_oxigeno");
                entity.Property(e => e.Oxigeno).HasColumnName("oxigeno");
                entity.Property(e => e.OxigenoFijo).HasColumnName("oxigeno_fijo");
                entity.Property(e => e.OxigenoPortatil).HasColumnName("oxigeno_portatil");
                entity.Property(e => e.Periodicidad).HasColumnName("periodicidad");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.StatusFechaValidacion)
                    .HasDefaultValueSql("'1'")
                    .HasComment("Este campo es para validar la entrega del servicio por primera vez")
                    .HasColumnName("status_fecha_validacion");
                entity.Property(e => e.VentilacionMecanicainvasiva).HasColumnName("ventilacion_mecanicainvasiva");
                entity.Property(e => e.VentilacionMecanicanoinvasiva).HasColumnName("ventilacion_mecanicanoinvasiva");
            });

            modelBuilder.Entity<OrdenTrabajo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("orden_trabajo")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.InscripcionOxigenoId, "id_adscripcion");

                entity.HasIndex(e => e.IdUser, "id_user");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");
                entity.Property(e => e.FechaBajaConsumo)
                    .HasComment("Este campo es cuando se da de baja la orden por algun motivo")
                    .HasColumnName("fecha_baja_consumo");
                entity.Property(e => e.FechaEntregaOxigeno).HasColumnName("fecha_entrega_oxigeno");
                entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
                entity.Property(e => e.FechaValidacionConsumo)
                    .HasComment("Este campo es cuando se valida la orden")
                    .HasColumnName("fecha_validacion_consumo");
                entity.Property(e => e.FechasValidacion).HasColumnName("fechas_validacion");
                entity.Property(e => e.InscripcionOxigenoId).HasColumnName("id_adscripcion");
                entity.Property(e => e.IdUser).HasColumnName("id_user");
                entity.Property(e => e.MesCorriente)
                    .HasMaxLength(191)
                    .HasColumnName("mes_corriente");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });


            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("direcciones")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Calle)
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'SIN DATO'")
                    .HasColumnName("calle");
                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("codigo_postal");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");
                entity.Property(e => e.Direccion_completa)
                    .HasMaxLength(191)
                    .HasColumnName("direccion");
                entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
                entity.Property(e => e.HoraRegistro)
                    .HasColumnType("time")
                    .HasColumnName("horaRegistro");
                entity.Property(e => e.IdAsentamiento).HasColumnName("id_asentamiento");
                entity.Property(e => e.IdEntidad).HasColumnName("id_entidad");
                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
                entity.Property(e => e.PacienteId).HasColumnName("id_paciente");
                entity.Property(e => e.IdTipoDireccion).HasColumnName("id_tipo_direccion");
                entity.Property(e => e.IdUser).HasColumnName("id_user");
                entity.Property(e => e.NumExterior)
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("num_exterior");
                entity.Property(e => e.NumInterior)
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("num_interior");
                entity.Property(e => e.Referencia)
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'sin referencia'")
                    .HasColumnName("referencia");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
