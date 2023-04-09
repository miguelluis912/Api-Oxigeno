using Microsoft.AspNetCore.Mvc;
using Api_Oxigeno.Config;
using Api_Oxigeno.Servicios;
using Api_Oxigeno.DTO.PacienteDTO;
using Api_Oxigeno.Models;
using Api_Oxigeno.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Api_Oxigeno.Controllers;
[ApiController]
[Route("oxigeno")]
public class PacienteController : ControllerBase
{
    private PacienteService _service;
    private IMapper _mapper;
    private ILogger _logger;

    public PacienteController(IMapper mapper, PacienteService service,ILogger<PacienteController> logger)
    {
        _mapper = mapper;
        _service = service;
        _logger = logger;
    }

    // [HttpGet("paciente/{id}")]
    // [Produces("application/json")]
    // public async Task<IActionResult> getPaciente(ulong id)
    // {
    //     /* Checking if the artist exists. */
    //     var paciente = await _service.getById(id);

    //     /* Checking if the artist exists. */
    //     if (paciente is not null)
    //     {
    //         return Ok(paciente);
    //     }
    //     /* Returning a 404 status code and a message. */
    //     return NotFound(new { message = "elemento no encontrado", status = 404 });
    // }

    // [HttpGet("paciente/prescripcion/{id}")]
    // [Produces("application/json")]
    // public async Task<IActionResult> getPacientePrescripcion(ulong paciente_id)
    // {
    //     ResponsePaciente? paciente_pres = await _service.getByIdPacientePrescripcion(paciente_id);
    //     if (paciente_pres.id == 0)
    //     {
    //         return NotFound(new { message = $"El paciente con el identificador: {paciente_id} no se encontro.", status = 404 });
    //     }
    //     /* Checking if the artist exists. */
    //     if (paciente_pres is not null)
    //     {
    //         return Ok(paciente_pres);
    //     }
    //     /* Returning a 404 status code and a message. */
    //     return NotFound(new { message = "elemento no encontrado", status = 404 });
    // }

}