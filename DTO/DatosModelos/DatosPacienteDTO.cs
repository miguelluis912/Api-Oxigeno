namespace Api_Oxigeno.DTO.DatosModelos
{
    public class DatosPacienteDTO
    {
        public ulong id_paciente { get; set; }
        public string nombres { get; set; } = null!;
        public string apellido_paterno { get; set; } = null!;
        public string? apellido_materno { get; set; }
        public string sexo { get; set; } = null!;
        public string curp { get; set; } = null!;
        public string rfc { get; set; } = null!;

        public DatosDireccionDTO DatosDireccion { get; set; }
    }
}