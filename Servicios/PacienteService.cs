using Microsoft.AspNetCore.Mvc;
using Api_Oxigeno.Config;
using Api_Oxigeno.Models;
using Api_Oxigeno.DTO.PacienteDTO;
using Api_Oxigeno.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Api_Oxigeno.Repositorios;


namespace Api_Oxigeno.Servicios
{
    public class PacienteService
    {

        private MysqlContext _context;
        private IMapper _mapper;
        private PacienteRepositorio _repositorio;

        public PacienteService(MysqlContext context, IMapper mapper,PacienteRepositorio repositorio)
        {
            _context = context;
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<getPacienteDTO> getById(ulong id)
        {
            var paciente = await _context.Pacientes.Where(query => query.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<getPacienteDTO>(paciente);
        }

        public async Task<ResponsePaciente>  getByIdPacientePrescripcion(ulong id)
        {
             var paciente_pres = await _repositorio.getPacientePrescripcion(id);

            return paciente_pres;
        }


        public async Task<Paciente> existPaciente(ulong paciente_id)
        {
            var paciente_pres = await _context.Pacientes.Where(query => query.Id == paciente_id).FirstOrDefaultAsync();
            return paciente_pres;
        }
    }
}