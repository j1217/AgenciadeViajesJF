using System.Net.WebSockets;
using System.Threading.Tasks;
using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Domain.Hoteles.Interfaces;
using AgenciadeViajesJF.Infrastructure.Data.Context;
using AgenciadeViajesJF.Infrastructure.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AgenciadeViajesJF.Infrastructure.Data.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AgenciaViajesContext _context;
        private readonly IMapper _mapper;

        public ReservaRepository(AgenciaViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AgregarReserva(Domain.Hoteles.Reserva reserva)
        {
            var reserv = _mapper.Map<Models.Reserva>(reserva);
            _context.Reservas.Add(reserv);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Hoteles.Reserva?> ObtenerReservaPorId(int idReserva)
        {
            var reserv = await _context.Reservas.FindAsync(idReserva);
            return _mapper.Map<Domain.Hoteles.Reserva>(reserv);
        }

        public async Task ActualizarReserva(Domain.Hoteles.Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Domain.Hoteles.Reserva>> ObtenerReservasDeHoteles()
        {
            var listaReservas = await _context.Reservas
                .Include(r => r.IdHotelNavigation)
                .Include(r => r.Huespedes)
                .ToListAsync();
            return _mapper.Map<List<Domain.Hoteles.Reserva>>(listaReservas);
        }

        public async Task<Domain.Hoteles.Reserva?> ObtenerDetalleReserva(int idReserva)
        {
            var detalleReserva = await _context.Reservas
                .Include(r => r.IdHotelNavigation)
                .Include(r => r.IdHabitacionNavigation)
                .Include(r => r.Huespedes)
                .FirstOrDefaultAsync(r => r.IdReserva == idReserva);
            return _mapper.Map<Domain.Hoteles.Reserva>(detalleReserva);
        }


        // Otros métodos de IReservaRepository, si los hay, pueden ser implementados aquí.
    }
}
