using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Oxigeno.Models
{
    public class InscripcionOxigeno
    {
        public ulong Id { get; set; }

        public int IdUser { get; set; }


        public int IdTipomedico { get; set; }

        public int IdUnidad { get; set; }

        public string? IdUnidadPaciente { get; set; }

        public int IdStatusInscripcion { get; set; }

        public int IdMedico { get; set; }

        public int IdPrescripcionPaciente { get; set; }

        public int Oxigeno { get; set; }

        public int LitrosMinuto { get; set; }

        public int Periodicidad { get; set; }

        public int OxigenoFijo { get; set; }

        public int Concentrador { get; set; }

        public int OxigenoPortatil { get; set; }

        public int VentilacionMecanicanoinvasiva { get; set; }

        public int Cpap { get; set; }

        public int Bipap { get; set; }

        public int VentilacionMecanicainvasiva { get; set; }

        public int MesUsoOxigeno { get; set; }


        public int Status { get; set; }

        /// <summary>
        /// Este campo es para validar la entrega del servicio por primera vez
        /// </summary>
        public int? StatusFechaValidacion { get; set; }

        [ForeignKey("PacienteId")]
        public ulong PacienteId { get; set; }

        public virtual Paciente Paciente { get; set; } = null!;
    }
}