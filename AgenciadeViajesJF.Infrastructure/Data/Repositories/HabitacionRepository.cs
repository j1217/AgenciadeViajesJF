using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Domain.Hoteles.Interfaces;
using AgenciadeViajesJF.Infrastructure.Data.Context;
using AgenciadeViajesJF.Infrastructure.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Infrastructure.Data.Repositories
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly AgenciaViajesContext _context;
        private readonly IMapper _mapper;

        public HabitacionRepository(AgenciaViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AgregarHabitacion(Habitacion habitacion)
        {
            var habitacione = _mapper.Map<Habitacione>(habitacion);
            _context.Habitaciones.Add(habitacione);
            await _context.SaveChangesAsync();
        }

        public async Task<Habitacion?> ObtenerHabitacionPorId(int idHabitacion)
        {
            var habitacion = await _context.Habitaciones.FindAsync(idHabitacion);
            return _mapper.Map<Habitacion>(habitacion);
        }

        public async Task ActualizarHabitacion(Habitacion habitacion)
        {
            _context.Entry(habitacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
