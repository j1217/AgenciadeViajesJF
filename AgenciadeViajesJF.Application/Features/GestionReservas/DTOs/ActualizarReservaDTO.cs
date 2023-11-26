using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Application.Features.GestionReservas.DTOs
{
    public class ActualizarReservaDTO
    {
        public int IdReserva { get; set; }
        public DateTime NuevaFechaEntrada { get; internal set; }
        public DateTime NuevaFechaSalida { get; internal set; }
        public int NuevaCantidadPersonas { get; internal set; }
    }
}
