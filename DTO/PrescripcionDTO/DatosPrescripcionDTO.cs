namespace Api_Oxigeno.DTO.PrescripcionDTO
{
    public class DatosPrescripcionDTO
    {
        public ulong id { get; set; }

        public int id_suario { get; set; }

        public int id_paciente { get; set; }
        public int id_prescripcion_paciente { get; set; }
    }
}