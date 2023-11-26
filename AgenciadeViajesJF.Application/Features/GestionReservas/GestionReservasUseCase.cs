using AgenciadeViajesJF.Application.Features.GestionReservas.DTOs;
using AgenciadeViajesJF.Application.Features.GestionReservas.Interfaces;
using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Domain.Hoteles.Interfaces;
using AgenciadeViajesJF.Exceptions;
using AutoMapper;

namespace AgenciadeViajesJF.Application.Features.GestionReservas
{
    public class GestionReservasUseCase : IGestionReservasUseCase
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public GestionReservasUseCase(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _mapper = mapper;
        }

        public async Task<List<ReservaDTO>> ObtenerReservasDeHoteles()
        {
            // Lógica para obtener y mapear las reservas de los hoteles
            var reservas = await _reservaRepository.ObtenerReservasDeHoteles();
            return _mapper.Map<List<ReservaDTO>>(reservas.ToList());
        }

        public async Task<ReservaDTO> ObtenerDetalleReserva(int idReserva)
        {
            // Lógica para obtener y mapear el detalle de la reserva
            var reserva = await _reservaRepository.ObtenerDetalleReserva(idReserva);
            return _mapper.Map<ReservaDTO>(reserva);
        }

        public async Task CrearReserva(CrearReservaDTO crearReservaDTO)
        {
            // Realiza la lógica para crear una reserva utilizando el repositorio
            var reserva = _mapper.Map<Reserva>(crearReservaDTO);
            await _reservaRepository.AgregarReserva(reserva);
        }

        public async Task ActualizarReserva(ActualizarReservaDTO actualizarReservaDTO)
        {
            try
            {
                // Obtener la reserva existente
                var reservaExistente = await _reservaRepository.ObtenerReservaPorId(actualizarReservaDTO.IdReserva);
                if (reservaExistente == null)
                {
                    throw new CustomException<ErrorCode>(ErrorCode.ReservaNoEncontrada, "La reserva no se encontró.");
                }

                // Actualizar propiedades según sea necesario
                reservaExistente.FechaEntrada = actualizarReservaDTO.NuevaFechaEntrada;
                reservaExistente.FechaSalida = actualizarReservaDTO.NuevaFechaSalida;
                reservaExistente.CantidadPersonas = actualizarReservaDTO.NuevaCantidadPersonas;

                // Puedes agregar más actualizaciones aquí según las propiedades del DTO

                // Lógica para actualizar la reserva en el repositorio
                await _reservaRepository.ActualizarReserva(reservaExistente);
            }
            catch (CustomException<ErrorCode> ex)
            {
                // Excepción personalizada ya manejada, puedes decidir si loguearla, notificar, etc.
                throw;
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones de manera adecuada (log, notificar, etc.)
                throw new CustomException<ErrorCode>(ErrorCode.ErrorActualizandoReserva, $"Error al actualizar la reserva: {ex.Message}");
            }
        }

    }

    public class ReservaDTO : IReservaDTO
    {
        public int IdReserva { get; set; }
        // Otras propiedades según sea necesario
    }
}
