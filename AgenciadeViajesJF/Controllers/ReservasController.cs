using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgenciadeViajesJF.Application.Features.GestionReservas.Interfaces;
using AgenciadeViajesJF.Application.Features.GestionReservas.DTOs;
using AgenciadeViajesJF.Application.Features.GestionReservas;

namespace AgenciadeViajesJF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IGestionReservasUseCase _gestionReservasUseCase;

        public ReservasController(IGestionReservasUseCase gestionReservasUseCase)
        {
            _gestionReservasUseCase = gestionReservasUseCase ?? throw new ArgumentNullException(nameof(gestionReservasUseCase));
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservaDTO>>> ObtenerReservasDeHoteles()
        {
            try
            {
                var reservas = await _gestionReservasUseCase.ObtenerReservasDeHoteles();
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                // Manejar el error de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al obtener las reservas: {ex.Message}");
            }
        }

        [HttpGet("{idReserva}")]
        public async Task<ActionResult<ReservaDTO>> ObtenerDetalleReserva(int idReserva)
        {
            try
            {
                var reserva = await _gestionReservasUseCase.ObtenerDetalleReserva(idReserva);
                if (reserva == null)
                {
                    return NotFound($"No se encontró la reserva con ID {idReserva}");
                }

                return Ok(reserva);
            }
            catch (Exception ex)
            {
                // Manejar el error de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al obtener el detalle de la reserva: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CrearReserva(CrearReservaDTO crearReservaDTO)
        {
            try
            {
                await _gestionReservasUseCase.CrearReserva(crearReservaDTO);
                return Ok("Reserva creada exitosamente");
            }
            catch (Exception ex)
            {
                // Manejar el error de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al crear la reserva: {ex.Message}");
            }
        }

        [HttpPut("{idReserva}")]
        public async Task<ActionResult> ActualizarReserva(int idReserva, ActualizarReservaDTO actualizarReservaDTO)
        {
            try
            {
                actualizarReservaDTO.IdReserva = idReserva;
                await _gestionReservasUseCase.ActualizarReserva(actualizarReservaDTO);
                return Ok($"Reserva con ID {idReserva} actualizada exitosamente");
            }
            catch (Exception ex)
            {
                // Manejar el error de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al actualizar la reserva: {ex.Message}");
            }
        }
    }
}
