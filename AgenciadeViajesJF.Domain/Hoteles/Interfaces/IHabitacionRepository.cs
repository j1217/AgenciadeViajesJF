using System.Threading.Tasks;

namespace AgenciadeViajesJF.Domain.Hoteles.Interfaces
{
    public interface IHabitacionRepository
    {
        Task AgregarHabitacion(Habitacion habitacion);
        Task<Habitacion?> ObtenerHabitacionPorId(int idHabitacion);
        Task ActualizarHabitacion(Habitacion habitacion);
    }
}
