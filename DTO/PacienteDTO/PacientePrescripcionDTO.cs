using Api_Oxigeno.DTO.DatosModelos;

namespace Api_Oxigeno.DTO.PacienteDTO
{
    public class PacientePrescripcionDTO
    {
        public ulong id { get; set; }
        public string nombres { get; set; } = null!;
        public string apellido_paterno { get; set; } = null!;
        public string? apellido_materno { get; set; }
        public string curp { get; set; } = null!;
        public string rfc { get; set; } = null!;
        public string? correo { get; set; }
        public string? telefono { get; set; }

        public int response_status { get; set; }

        public string? Mensaje {get;set;}


        public DatosPrescripcionDTO? prescripcion {get;set;}
    }
}