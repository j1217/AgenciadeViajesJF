using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgenciadeViajesJF.Application.Features.GestionHoteles.Interfaces;
using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Exceptions;

namespace AgenciadeViajesJF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelesController : ControllerBase
    {
        private readonly IGestionHotelUseCase _gestionHotelUseCase;

        public HotelesController(IGestionHotelUseCase gestionHotelUseCase)
        {
            _gestionHotelUseCase = gestionHotelUseCase ?? throw new ArgumentNullException(nameof(gestionHotelUseCase));
        }

        [HttpPost]
        public async Task<ActionResult> CrearNuevoHotel([FromBody] HotelDTO hotelDTO)
        {
            try
            {
                await _gestionHotelUseCase.CrearNuevoHotel(
                    hotelDTO.Nombre,
                    hotelDTO.Direccion,
                    hotelDTO.Descripcion,
                    hotelDTO.Estrellas,
                    hotelDTO.Telefono,
                    hotelDTO.CorreoElectronico,
                    hotelDTO.SitioWeb
                );
                return Ok("Hotel creado exitosamente");
            }
            catch (Exception ex)
            {
                // Manejar el error de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al crear el hotel: {ex.Message}");
            }
        }

        [HttpPost("{idHotel}/habitaciones")]
        public async Task<ActionResult> AsignarHabitacionesAlHotel(int idHotel, [FromBody] List<HabitacionDTO> habitacionesDTO)
        {
            try
            {
                await _gestionHotelUseCase.AsignarHabitacionesAlHotel(idHotel, habitacionesDTO);
                return Ok("Habitaciones asignadas al hotel exitosamente");
            }
            catch (CustomException<ErrorCode> ex)
            {
                // Excepción personalizada ya manejada, puedes decidir si loguearla, notificar, etc.
                return BadRequest($"Error al asignar habitaciones al hotel: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al asignar habitaciones al hotel: {ex.Message}");
            }
        }

        [HttpPut("{idHotel}/habitaciones/{idHabitacion}")]
        public async Task<ActionResult> ModificarValoresHabitacion(int idHotel, int idHabitacion, [FromBody] HabitacionDTO habitacionDTO)
        {
            try
            {
                await _gestionHotelUseCase.ModificarValoresHabitacion(idHabitacion, habitacionDTO);
                return Ok("Valores de la habitación modificados exitosamente");
            }
            catch (CustomException<ErrorCode> ex)
            {
                // Excepción personalizada ya manejada, puedes decidir si loguearla, notificar, etc.
                return BadRequest($"Error al modificar valores de la habitación: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al modificar valores de la habitación: {ex.Message}");
            }
        }

        [HttpPut("{idHotel}")]
        public async Task<ActionResult> ModificarValoresHotel(int idHotel, [FromBody] HotelDTO hotelDTO)
        {
            try
            {
                await _gestionHotelUseCase.ModificarValoresHotel(idHotel, hotelDTO);
                return Ok("Valores del hotel modificados exitosamente");
            }
            catch (CustomException<ErrorCode> ex)
            {
                // Excepción personalizada ya manejada, puedes decidir si loguearla, notificar, etc.
                return BadRequest($"Error al modificar valores del hotel: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al modificar valores del hotel: {ex.Message}");
            }
        }

        [HttpPatch("{idHotel}")]
        public async Task<ActionResult> HabilitarDeshabilitarHotel(int idHotel, [FromBody] bool habilitado)
        {
            try
            {
                await _gestionHotelUseCase.HabilitarDeshabilitarHotel(idHotel, habilitado);
                return Ok($"El hotel fue {(habilitado ? "habilitado" : "deshabilitado")} exitosamente");
            }
            catch (CustomException<ErrorCode> ex)
            {
                // Excepción personalizada ya manejada, puedes decidir si loguearla, notificar, etc.
                return BadRequest($"Error al habilitar/deshabilitar el hotel: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al habilitar/deshabilitar el hotel: {ex.Message}");
            }
        }

        [HttpPatch("habitaciones/{idHabitacion}")]
        public async Task<ActionResult> HabilitarDeshabilitarHabitacion(int idHabitacion, [FromBody] bool habilitada)
        {
            try
            {
                await _gestionHotelUseCase.HabilitarDeshabilitarHabitacion(idHabitacion, habilitada);
                return Ok($"La habitación fue {(habilitada ? "habilitada" : "deshabilitada")} exitosamente");
            }
            catch (CustomException<ErrorCode> ex)
            {
                // Excepción personalizada ya manejada, puedes decidir si loguearla, notificar, etc.
                return BadRequest($"Error al habilitar/deshabilitar la habitación: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones de manera adecuada (log, notificar, etc.)
                return StatusCode(500, $"Error al habilitar/deshabilitar la habitación: {ex.Message}");
            }
        }
    }
}
