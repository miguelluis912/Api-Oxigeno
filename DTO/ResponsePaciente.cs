namespace Api_Oxigeno.DTO
{
    public class ResponsePaciente
    {
        public ulong id { get; set; }
        public string nombres { get; set; } = null!;
        public string apellido_materno { get; set; } = null!;
        public string? apellido_paterno { get; set; }
        public int response_status { get; set; }
        public string? Mensaje { get; set; }

        public List<DatosPrescripcion>? datosPrescripcion { get; set; } = null!;

    }
}