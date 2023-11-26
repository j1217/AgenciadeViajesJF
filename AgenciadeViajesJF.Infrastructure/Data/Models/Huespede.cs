using System;
using System.Collections.Generic;

namespace AgenciadeViajesJF.Infrastructure.Data.Models;

public partial class Huespede
{
    public int IdHuesped { get; set; }

    public int? IdReserva { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }
}
