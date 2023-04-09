using Microsoft.AspNetCore.Mvc;
using Api_Oxigeno.Config;
using Api_Oxigeno.DTO.PrescripcionDTO.Response;
using AutoMapper;
using Api_Oxigeno.Repositorios;

namespace Api_Oxigeno.Servicios
{
    public class PrescripcionService
    {
        private MysqlContext _context;
        private IMapper _mapper;
        private PrescripcionRepositorio _prescripcion_repositorio;
        public PrescripcionService(MysqlContext context, IMapper mapper, PrescripcionRepositorio prescripcion_repositorio)
        {
            _context = context;
            _mapper = mapper;
            _prescripcion_repositorio = prescripcion_repositorio;
        }

        public async Task<GetPrescripcionByIdResponseDTO> getPrescripcionById(ulong prescripcion_id)
        {
            var prescripcion_data = await _prescripcion_repositorio.getPrescripcionById(prescripcion_id);

            return prescripcion_data;
        }

        public async Task<GetOrdenTrabajoByIdResponseDTO> getOrdenTrabajoById(ulong orden_trabajo_id)
        {
            var orden_trabajo_data = await _prescripcion_repositorio.getOrdenTrabajoById(orden_trabajo_id);

            return orden_trabajo_data;
        }
    }
}