using Microsoft.AspNetCore.Mvc;
using Api_Oxigeno.Servicios;
using Api_Oxigeno.DTO.PrescripcionDTO.Response;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Api_Oxigeno.Controllers
{
    [ApiController]
    [Route("oxigeno")]
    public class PrescripcionController : ControllerBase
    {
        private PrescripcionService _prescripcion_service;
        private IMapper _mapper;
        private ILogger _logger;


        public PrescripcionController(PrescripcionService prescripcion_service, IMapper mapper, ILogger<PrescripcionController> logger)
        {
            _prescripcion_service = prescripcion_service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("prescripcion/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> getPrescripcionById(ulong id)
        {
            try
            {
                GetPrescripcionByIdResponseDTO? prescripcion = await _prescripcion_service.getPrescripcionById(id);
                if (prescripcion.id_prescripcion == 0)
                {
                    return NotFound(new { message = $"Elemento no encontrado: {id}", code_status = 404 });
                }
                /* Checking if the artist exists. */
                if (prescripcion is not null)
                {
                    return Ok(prescripcion);
                }
                /* Returning a 404 code_status code and a message. */
                return NotFound(new { message = $"Elemento no encontrado: {id}", code_status = 404 });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("***************************** ERROR ENDPOINT CONSULTA PRESCRIPCION *********************************************");
                _logger.LogInformation($"{ex.Message}");
                return BadRequest(new { message = "Error del servidor", code_status = 500 });
            }

        }

        [HttpGet("prescripcion/orden/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> getOrdenTrabajoById(ulong id)
        {
            try
            {
                GetOrdenTrabajoByIdResponseDTO? orden_trabajo = await _prescripcion_service.getOrdenTrabajoById(id);
                if (orden_trabajo.id_orden == 0)
                {
                    return NotFound(new { message = $"Elemento no encontrado: {id}", code_status = 404 });
                }
                /* Checking if the artist exists. */
                if (orden_trabajo is not null)
                {
                    return Ok(orden_trabajo);
                }
                /* Returning a 404 code_status code and a message. */
                return NotFound(new { message = $"Elemento no encontrado: {id}", code_status = 404 });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("***************************** ERROR ENDPOINT CONSULTA ORDEN DE TRABAJO *********************************************");
                _logger.LogInformation($"{ex.Message}");
                return BadRequest(new { message = "Error del servidor", code_status = 500 });
            }

        }
    }
}