using Api_Oxigeno.Models;

namespace Api_Oxigeno.DTO.DatosModelos
{
    public class DatosPrescripcionDTO
    {
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
        public int response_status { get; set; }
        public string? Mensaje { get; set; }

        public virtual DatosPacienteDTO DatosPaciente { get; set; }
    }
}