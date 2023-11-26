using System;
using System.Collections.Generic;

namespace AgenciadeViajesJF.Infrastructure.Data.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int? IdHotel { get; set; }

    public int? IdHabitacion { get; set; }

    public DateTime FechaEntrada { get; set; }

    public DateTime FechaSalida { get; set; }

    public int CantidadPersonas { get; set; }

    public virtual ICollection<ContactosEmergencium> ContactosEmergencia { get; set; } = new List<ContactosEmergencium>();

    public virtual ICollection<Huespede> Huespedes { get; set; } = new List<Huespede>();

    public virtual Habitacione? IdHabitacionNavigation { get; set; }

    public virtual Hotele? IdHotelNavigation { get; set; }
}
