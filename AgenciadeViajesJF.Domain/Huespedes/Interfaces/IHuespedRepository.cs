using System.Threading.Tasks;

namespace AgenciadeViajesJF.Domain.Huespedes.Interfaces
{
    public interface IHuespedRepository
    {
        Task AgregarHuesped(Huesped huesped);
        Task<Huesped?> ObtenerHuespedPorId(int idHuesped);
        Task ActualizarHuesped(Huesped huesped);
    }
}