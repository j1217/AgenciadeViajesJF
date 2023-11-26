namespace AgenciadeViajesJF.Domain.Hoteles.Interfaces
{
    public interface IReservaRepository
    {
        Task AgregarReserva(Reserva reserva);
        Task<Reserva?> ObtenerReservaPorId(int idReserva);
        Task ActualizarReserva(Reserva reserva);
        Task<List<Reserva>> ObtenerReservasDeHoteles();
        Task<Reserva?> ObtenerDetalleReserva(int idReserva);
    }
}
