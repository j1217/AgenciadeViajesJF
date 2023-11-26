using AutoMapper;
using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Infrastructure.Data.Models;
using AgenciadeViajesJF.Domain.Huespedes;
using AgenciadeViajesJF.Application.Features.GestionReservas;

namespace AgenciadeViajesJF.Application.Features.Shared.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Habitacion, Habitacione>();
            CreateMap<Hotel, Hotele>();
            CreateMap<ContactoEmergencia, ContactosEmergencium>();
            CreateMap<Domain.Hoteles.Reserva, Infrastructure.Data.Models.Reserva>();
            CreateMap<ReservaDTO, Domain.Hoteles.Reserva>();
            // Agrega más configuraciones de mapeo según sea necesario
        }
    }
}
