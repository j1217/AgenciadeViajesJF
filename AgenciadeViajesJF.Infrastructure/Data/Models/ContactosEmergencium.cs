using System;
using System.Collections.Generic;

namespace AgenciadeViajesJF.Infrastructure.Data.Models;

public partial class ContactosEmergencium
{
    public int IdContactoEmergencia { get; set; }

    public int? IdReserva { get; set; }

    public string Nombres { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual Reserva? IdReservaNavigation { get; set; }
}
