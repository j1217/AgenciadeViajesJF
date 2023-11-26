using AgenciadeViajesJF.Domain.Huespedes;
using System;
using System.Collections.Generic;

namespace AgenciadeViajesJF.Domain.Hoteles
{
    public class Reserva
    {
        public int IdReserva { get; private set; }
        public int? IdHotel { get; private set; }
        public int? IdHabitacion { get; private set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int CantidadPersonas { get; set; }

        public virtual ICollection<ContactoEmergencia> ContactosEmergencia { get; private set; } = new List<ContactoEmergencia>();
        public virtual ICollection<Huesped> Huespedes { get; private set; } = new List<Huesped>();

        public virtual Habitacion Habitacion { get; private set; }
        public virtual Hotel Hotel { get; private set; }

        private Reserva() { } // Constructor privado para Entity Framework

        public Reserva(int? idHotel, int? idHabitacion, DateTime fechaEntrada, DateTime fechaSalida, int cantidadPersonas)
        {
            IdHotel = idHotel;
            IdHabitacion = idHabitacion;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
            CantidadPersonas = cantidadPersonas;
        }
    }
}
