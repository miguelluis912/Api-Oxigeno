namespace Api_Oxigeno.DTO
{
    public class DatosPrescripcion
    {
        public ulong id { get; set; }

        public int id_suario { get; set; }

        public int id_paciente { get; set; }
        public int id_prescripcion_paciente { get; set; }
    }
}