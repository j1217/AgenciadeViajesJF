using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Application.Features.GestionReservas.DTOs
{
    public class CrearReservaDTO
    {
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int CantidadPersonas { get; set; }
        public int IdHabitacion { get; set; }
        // Otras propiedades necesarias para el huésped y contacto de emergencia
    }

}
