using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Domain.Hoteles.Interfaces
{
    public interface IHotelRepository
    {
        Task AgregarHotel(Hotel hotel);
        Task ActualizarHotel(Hotel hotel);
        Task<Hotel?> ObtenerHotelPorId(int idHotel);

    }
}
