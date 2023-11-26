using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Domain.Hoteles.Interfaces;
using AgenciadeViajesJF.Infrastructure.Data.Context;
using AgenciadeViajesJF.Infrastructure.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Infrastructure.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AgenciaViajesContext _context;
        private readonly IMapper _mapper;

        public HotelRepository(AgenciaViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AgregarHotel(Hotel hotel)
        {
            var hotele = _mapper.Map<Hotele>(hotel);
            _context.Hoteles.Add(hotele);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel?> ObtenerHotelPorId(int idHotel)
        {
            var hotel = await _context.Hoteles.FindAsync(idHotel);
            return _mapper.Map<Hotel>(hotel);
        }

        public async Task ActualizarHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
