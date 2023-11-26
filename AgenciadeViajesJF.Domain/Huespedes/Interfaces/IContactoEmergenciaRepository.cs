using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Domain.Huespedes.Interfaces
{
    public interface IContactoEmergenciaRepository
    {
        Task AgregarContactoEmergencia(ContactoEmergencia contactoEmergencia);
        Task<ContactoEmergencia?> ObtenerContactoEmergenciaPorId(int idContactoEmergencia);
        Task ActualizarContactoEmergencia(ContactoEmergencia contactoEmergencia);
    }
}
