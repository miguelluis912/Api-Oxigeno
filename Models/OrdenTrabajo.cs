using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Oxigeno.Models
{
    public class OrdenTrabajo
    {
        public ulong Id { get; set; }
        public int IdUser { get; set; }
        public DateOnly FechasValidacion { get; set; }

        public string? MesCorriente { get; set; }

        public DateOnly? FechaEntregaOxigeno { get; set; }

        /// <summary>
        /// Este campo es cuando se valida la orden
        /// </summary>

        public DateTime? FechaValidacionConsumo { get; set; }

        /// <summary>
        /// Este campo es cuando se da de baja la orden por algun motivo
        /// </summary>

        public DateTime? FechaBajaConsumo { get; set; }

        public DateTime FechaRegistro { get; set; }


        public int Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        [ForeignKey("InscripcionOxigenoId")]
        public ulong InscripcionOxigenoId { get; set; }

        public virtual InscripcionOxigeno? InscripcionOxigeno { get; set; }

    }
}