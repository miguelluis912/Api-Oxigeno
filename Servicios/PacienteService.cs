using Microsoft.AspNetCore.Mvc;
using Api_Oxigeno.Config;
using Api_Oxigeno.Models;
using Api_Oxigeno.Servicios;
using Microsoft.EntityFrameworkCore;

namespace Api_Oxigeno.Servicios
{
    public class PacienteService
    {

        private MysqlContext _context;

        public PacienteService(MysqlContext context)
        {
            _context = context;
        }

        public async Task<Paciente>? getById(ulong id)
        {
            // Se utiliza LINQ para realizar consultas a la bd
            var paciente = await _context.Pacientes.Where(query => query.Id == id).FirstOrDefaultAsync();
            return paciente;
        }
    }
}