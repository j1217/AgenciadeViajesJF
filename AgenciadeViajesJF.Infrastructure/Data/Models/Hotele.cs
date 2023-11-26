using System;
using System.Collections.Generic;

namespace AgenciadeViajesJF.Infrastructure.Data.Models;

public partial class Hotele
{
    public int IdHotel { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Descripcion { get; set; }

    public int? Estrellas { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? SitioWeb { get; set; }

    public bool? Habilitado { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
