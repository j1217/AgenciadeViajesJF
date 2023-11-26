using AgenciadeViajesJF.Domain.Huespedes;
using AgenciadeViajesJF.Domain.Huespedes.Interfaces;
using AgenciadeViajesJF.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;
using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Infrastructure.Data.Models;

namespace AgenciadeViajesJF.Infrastructure.Data.Repositories
{
    public class HuespedRepository : IHuespedRepository
    {
        private readonly AgenciaViajesContext _context;
        private readonly IMapper _mapper;

        public HuespedRepository(AgenciaViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AgregarHuesped(Huesped huesped)
        {
            var huespede = _mapper.Map<Huespede>(huesped);
            _context.Huespedes.Add(huespede);
            await _context.SaveChangesAsync();
        }

        public async Task<Huesped?> ObtenerHuespedPorId(int idHuesped)
        {
            var habitacion = await _context.Huespedes.FindAsync(idHuesped);
            return _mapper.Map<Huesped>(habitacion);
        }

        public async Task ActualizarHuesped(Huesped huesped)
        {
            _context.Entry(huesped).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
