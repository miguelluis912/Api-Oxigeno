using Microsoft.AspNetCore.Mvc;
using Api_Oxigeno.Config;
using Api_Oxigeno.Servicios;
using Api_Oxigeno.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Oxigeno.Controllers;
[ApiController]
[Route("oxigeno")]
public class PacienteController : ControllerBase
{
    private PacienteService _service;

    public PacienteController(PacienteService service)
    {
        _service = service;
    }

    [HttpGet("paciente/{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> getPaciente(ulong id)
    {
        /* Checking if the artist exists. */
        Paciente? paciente = await _service.getById(id);

        /* Checking if the artist exists. */
        if (paciente is not null)
        {
            return Ok(paciente);
        }

        /* Returning a 404 status code and a message. */
        return NotFound(new { message = "elemento no encontrado", status = 404 });
    }


}