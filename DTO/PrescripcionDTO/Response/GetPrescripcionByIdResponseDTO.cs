using Api_Oxigeno.DTO.DatosModelos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Oxigeno.DTO.PrescripcionDTO.Response
{
    public class GetPrescripcionByIdResponseDTO
    {
        public int response_status { get; set; }
        public string? Mensaje { get; set; }
        public ulong id_prescripcion { get; set; }

        public int oxigeno { get; set; }

        public int litros_minuto { get; set; }

        public int periodicidad { get; set; }

        public int oxigeno_fijo { get; set; }

        public int concentrador { get; set; }

        public int oxigeno_portatil { get; set; }

        public int ventilacion_mecanica_no_invasiva { get; set; }

        public int cpap { get; set; }

        public int bipap { get; set; }

        public int mes_uso_oxigeno { get; set; }

        public int status { get; set; }

        [ForeignKey("PacienteId")]
        public ulong PacienteId { get; set; }
        public virtual DatosPacienteDTO? datosPaciente { get; set; } = null!;
        public virtual List<DatosOrdenTrabajoDTO>? datosOrdenTrabajo { get; set; } = null!;
    }
}