using System;
using System.Collections.Generic;

namespace AgenciadeViajesJF.Infrastructure.Data.Models;

public partial class Habitacione
{
    public int IdHabitacion { get; set; }

    public int? IdHotel { get; set; }

    public string TipoHabitacion { get; set; } = null!;

    public decimal CostoBase { get; set; }

    public decimal Impuestos { get; set; }

    public string? Ubicacion { get; set; }

    public bool? Habilitada { get; set; }

    public virtual Hotele? IdHotelNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
