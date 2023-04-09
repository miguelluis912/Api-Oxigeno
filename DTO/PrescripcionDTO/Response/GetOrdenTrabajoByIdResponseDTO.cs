using Api_Oxigeno.DTO.DatosModelos;
namespace Api_Oxigeno.DTO.PrescripcionDTO.Response
{
    public class GetOrdenTrabajoByIdResponseDTO
    {
        // public virtual DatosOrdenTrabajoDTO? DatosOrdenTrabajoDTO { get; set; }
        public int response_status { get; set; }
        public string? Mensaje { get; set; }
        public ulong id_orden { get; set; }

        public DateOnly fecha_validacion { get; set; }

        public string? mes_corriente { get; set; }

        public DateOnly? fecha_entra_oxigeno { get; set; }

        public int status { get; set; }
        public virtual DatosPrescripcionDTO? DatosPrescripcion { get; set; }
    }
}