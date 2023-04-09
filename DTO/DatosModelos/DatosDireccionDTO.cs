namespace Api_Oxigeno.DTO.DatosModelos
{
    public class DatosDireccionDTO
    {
        public ulong id_direccion { get; set; }

        public string direccion_completa { get; set; } = null!;

        public string? numero_interior { get; set; }

        public string? numero_exterior { get; set; }

        public string? codigo_postal { get; set; }

        public string? referencia { get; set; }

        public string? calle { get; set; }

    }
}