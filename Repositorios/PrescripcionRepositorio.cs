using Api_Oxigeno.Config;
using Api_Oxigeno.Models;
using Microsoft.EntityFrameworkCore;
using Api_Oxigeno.DTO.DatosModelos;
using Api_Oxigeno.DTO.ResponseCodeStatus;
using Api_Oxigeno.DTO.PrescripcionDTO.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Oxigeno.Repositorios
{
    public class PrescripcionRepositorio
    {
        private readonly MysqlContext _context;
        private readonly ILogger<PrescripcionRepositorio> _logger;
        private readonly IMapper _mapper;

        public PrescripcionRepositorio(ILogger<PrescripcionRepositorio> logger, MysqlContext context, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetPrescripcionByIdResponseDTO> getPrescripcionById(ulong prescripcion_id)
        {
            var prescripcion = await _context.InscripcionOxigenos
                .Include(p => p.paciente)
                .Where(query => query.Id == prescripcion_id)
                .FirstOrDefaultAsync();

            var orden_trabajo = await _context.OrdenTrabajo
            .Where(query => query.InscripcionOxigenoId == prescripcion_id)
            .ToListAsync();

            GetPrescripcionByIdResponseDTO dto_response_prescripcion  = new GetPrescripcionByIdResponseDTO();
            if (prescripcion == null)
            {
                dto_response_prescripcion.response_status = 404;
                dto_response_prescripcion.Mensaje = $"Elemento no encontrado: {prescripcion_id}";
            }
            else
            {
                dto_response_prescripcion.response_status = 200;
                dto_response_prescripcion.Mensaje = $"Elemento encontrado: {prescripcion_id}";
                dto_response_prescripcion.id_prescripcion = prescripcion.Id;
                dto_response_prescripcion.oxigeno = prescripcion.Oxigeno;
                dto_response_prescripcion.litros_minuto = prescripcion.LitrosMinuto;
                dto_response_prescripcion.periodicidad = prescripcion.Periodicidad;
                dto_response_prescripcion.oxigeno_fijo = prescripcion.OxigenoFijo;
                dto_response_prescripcion.concentrador = prescripcion.Concentrador;
                dto_response_prescripcion.oxigeno_portatil = prescripcion.OxigenoPortatil;
                dto_response_prescripcion.ventilacion_mecanica_no_invasiva = prescripcion.VentilacionMecanicanoinvasiva;
                dto_response_prescripcion.cpap = prescripcion.Cpap;
                dto_response_prescripcion.bipap = prescripcion.Bipap;
                dto_response_prescripcion.mes_uso_oxigeno = prescripcion.MesUsoOxigeno;
                dto_response_prescripcion.status = prescripcion.Status;
                dto_response_prescripcion.datosPaciente = _mapper.Map<DatosPacienteDTO>(prescripcion.paciente);
                dto_response_prescripcion.datosOrdenTrabajo = _mapper.Map<List<DatosOrdenTrabajoDTO>>(orden_trabajo);
            }
            return dto_response_prescripcion;
        }

        public async Task<GetOrdenTrabajoByIdResponseDTO> getOrdenTrabajoById(ulong orden_trabajo_id)
        {
            var orden_trabajo_data = await _context.OrdenTrabajo
                .Include(I => I.InscripcionOxigeno)
                .ThenInclude(inscripcionoxigeno => inscripcionoxigeno.paciente)
                .ThenInclude(paciente => paciente.direccion)
                .Where(query => query.Id == orden_trabajo_id)
                .FirstOrDefaultAsync();


            GetOrdenTrabajoByIdResponseDTO dto_response_orden_trabajo = new GetOrdenTrabajoByIdResponseDTO();

            if (orden_trabajo_data is null)
            {
                dto_response_orden_trabajo.response_status = 404;
                dto_response_orden_trabajo.Mensaje = $"Elemento no encontrado: {orden_trabajo_id}";
            }
            else
            {
                dto_response_orden_trabajo.response_status = 200;
                dto_response_orden_trabajo.Mensaje = $"Elemento encontrado: {orden_trabajo_id}";
                dto_response_orden_trabajo.id_orden = orden_trabajo_data.Id;
                dto_response_orden_trabajo.fecha_validacion = orden_trabajo_data.FechasValidacion;
                dto_response_orden_trabajo.mes_corriente = orden_trabajo_data.MesCorriente;
                dto_response_orden_trabajo.fecha_entra_oxigeno = orden_trabajo_data.FechaEntregaOxigeno;
                dto_response_orden_trabajo.status = orden_trabajo_data.Status;
                // dto_response_orden_trabajo.DatosOrdenTrabajoDTO = _mapper.Map<DatosOrdenTrabajoDTO>(orden_trabajo_data);
                dto_response_orden_trabajo.DatosPrescripcion = _mapper.Map<DatosPrescripcionDTO>(orden_trabajo_data.InscripcionOxigeno);
                dto_response_orden_trabajo.DatosPrescripcion.DatosPaciente = _mapper.Map<DatosPacienteDTO>(orden_trabajo_data.InscripcionOxigeno.paciente);
                dto_response_orden_trabajo.DatosPrescripcion.DatosPaciente.DatosDireccion = _mapper.Map<DatosDireccionDTO>(orden_trabajo_data.InscripcionOxigeno.paciente.direccion);
            }
            return dto_response_orden_trabajo;
        }

    }
}