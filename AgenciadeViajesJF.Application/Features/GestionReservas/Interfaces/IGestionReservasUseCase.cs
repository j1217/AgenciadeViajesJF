using AgenciadeViajesJF.Application.Features.GestionReservas.DTOs;

namespace AgenciadeViajesJF.Application.Features.GestionReservas.Interfaces
{
    public interface IGestionReservasUseCase
    {
        Task<List<ReservaDTO>> ObtenerReservasDeHoteles();
        Task<ReservaDTO> ObtenerDetalleReserva(int idReserva);
        Task CrearReserva(CrearReservaDTO crearReservaDTO);
        Task ActualizarReserva(ActualizarReservaDTO actualizarReservaDTO);
    }

    public interface IReservaDTO
    {
        // Propiedades de la reserva necesarias para mostrar en la lista
        int IdReserva { get; set; }
        // Otras propiedades según sea necesario
    }
}
