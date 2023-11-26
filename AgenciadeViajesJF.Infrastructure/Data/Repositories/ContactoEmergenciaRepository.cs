using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Domain.Huespedes;
using AgenciadeViajesJF.Domain.Huespedes.Interfaces;
using AgenciadeViajesJF.Infrastructure.Data.Context;
using AgenciadeViajesJF.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Infrastructure.Data.Repositories
{
    public class ContactoEmergenciaRepository : IContactoEmergenciaRepository
    {
        private readonly AgenciaViajesContext _context;
        private readonly IMapper _mapper;

        public ContactoEmergenciaRepository(AgenciaViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AgregarContactoEmergencia(ContactoEmergencia contactoEmergencia)
        {
            var contactosEmergencium = _mapper.Map<ContactosEmergencium>(contactoEmergencia);
            _context.ContactosEmergencia.Add(contactosEmergencium);
            await _context.SaveChangesAsync();
        }

        public async Task<ContactoEmergencia?> ObtenerContactoEmergenciaPorId(int idContactoEmergencia)
        {
            var contactoEmergencia = await _context.ContactosEmergencia.FindAsync(idContactoEmergencia);
            return _mapper.Map<ContactoEmergencia>(contactoEmergencia);
        }

        public async Task ActualizarContactoEmergencia(ContactoEmergencia contactoEmergencia)
        {
            _context.Entry(contactoEmergencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
