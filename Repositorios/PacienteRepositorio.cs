using Api_Oxigeno.Config;
using Api_Oxigeno.Models;
using Microsoft.EntityFrameworkCore;
using Api_Oxigeno.DTO;
using Api_Oxigeno.DTO.PrescripcionDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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


        public async Task<ResponsePaciente> getPacientePrescripcion(ulong id_paciente)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.Inscripcionoxigeno)
                .Where(query => query.Id == id_paciente)
                .FirstOrDefaultAsync();

            ResponsePaciente dtoPacPres = new ResponsePaciente();
            if (paciente == null)
            {
                dtoPacPres.response_status = 404;
                dtoPacPres.Mensaje = "DATOS NO ENCONTRADOS";
                // return NotFound();
            }else{
                dtoPacPres.response_status = 200;
                dtoPacPres.Mensaje = "Informacion general";
                dtoPacPres.id = paciente.Id;
                dtoPacPres.nombres = paciente.Nombre;
                dtoPacPres.apellido_materno = paciente.ApellidoMaterno;
                dtoPacPres.apellido_paterno = paciente.ApellidoPaterno;
                dtoPacPres.datosPrescripcion = _mapper.Map<List<DatosPrescripcion>>(paciente.Inscripcionoxigeno);
            }
            return dtoPacPres;
        }
    }
}
