using Api_Oxigeno.Config;
using Api_Oxigeno.Models;
using Microsoft.EntityFrameworkCore;
using Api_Oxigeno.DTO.PacienteDTO;
using Api_Oxigeno.DTO.PrescripcionDTO;
using AutoMapper;

namespace Api_Oxigeno.Repositorios
{
    public class PacienteRepositorio
    {
        private readonly MysqlContext _context;
        private readonly ILogger<PacienteRepositorio> _logger;
        private readonly IMapper _mapper;

        public PacienteRepositorio(ILogger<PacienteRepositorio> logger, MysqlContext context,IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<PacientePrescripcionDTO> getPacientePrescripcion(ulong id_paciente)
        {
            Paciente? paciente = await _context.Pacientes
                                        .Include(p => p.InscripcionOxigeno)
                                        .Where(p => p.Id == id_paciente)
                                        .Where(p => p.InscripcionOxigeno.Status == 1)
                                        .FirstOrDefaultAsync();

            PacientePrescripcionDTO dtoPacPres = new PacientePrescripcionDTO();

            if(paciente is not null)
            {
                dtoPacPres.id = paciente.Id;
                dtoPacPres.nombres = paciente.Nombre;
                dtoPacPres.apellido_materno = paciente.ApellidoMaterno;
                dtoPacPres.apellido_paterno = paciente.ApellidoPaterno;
                dtoPacPres.curp = paciente.Curp;
                dtoPacPres.correo = paciente.Correo;
                dtoPacPres.prescripcion = _mapper.Map<DatosPrescripcionDTO>(paciente);
            }
            else
            {
                dtoPacPres.response_status = 404;
                dtoPacPres.Mensaje = "DATOS NO ENCONTRADOS";
            }
            return dtoPacPres;
        }
    }
}
