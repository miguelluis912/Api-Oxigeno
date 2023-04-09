using System.ComponentModel.DataAnnotations.Schema;


namespace Api_Oxigeno.Models
{
    public class Direccion
    {
        public ulong Id { get; set; }

        public int IdUser { get; set; }
        public int IdEntidad { get; set; }

        public int IdMunicipio { get; set; }

        public int IdAsentamiento { get; set; }

        public string Direccion_completa { get; set; } = null!;

        public string? NumInterior { get; set; }

        public string? NumExterior { get; set; }

        public string? CodigoPostal { get; set; }

        public string? Referencia { get; set; }

        public int? IdTipoDireccion { get; set; }

        public string? Calle { get; set; }

        public DateOnly FechaRegistro { get; set; }

        public TimeOnly HoraRegistro { get; set; }

        public int Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("PacienteId")]
        public ulong PacienteId { get; set; }
        // public virtual Paciente paciente { get; set; } = null!;

    }
}