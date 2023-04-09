namespace Api_Oxigeno.DTO.DatosModelos
{
    public class DatosOrdenTrabajoDTO
    {
        public ulong id_orden { get; set; }

        public DateOnly fecha_validacion { get; set; }

        public string? mes_corriente { get; set; }

        public DateOnly? fecha_entra_oxigeno { get; set; }

        public int status { get; set; }

    }
}