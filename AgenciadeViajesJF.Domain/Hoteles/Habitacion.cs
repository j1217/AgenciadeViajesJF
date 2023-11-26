// AgenciadeViajesJF.Domain.Hoteles/Habitacion.cs
using System;

namespace AgenciadeViajesJF.Domain.Hoteles
{
    public class Habitacion
    {
        public int IdHabitacion { get; private set; }
        public string TipoHabitacion { get; private set; }
        public decimal CostoBase { get; private set; }
        public decimal Impuestos { get; private set; }
        public string? Ubicacion { get; private set; }
        public bool? Habilitada { get; private set; }

        private Habitacion() { } // Constructor privado para Entity Framework

        public Habitacion(string tipoHabitacion, decimal costoBase, decimal impuestos, string? ubicacion)
        {
            TipoHabitacion = tipoHabitacion ?? throw new ArgumentNullException(nameof(tipoHabitacion));
            CostoBase = costoBase;
            Impuestos = impuestos;
            Ubicacion = ubicacion;
            Habilitada = true; // Por defecto, la habitación se crea habilitada
        }

        public void ModificarValores(string tipoHabitacion, decimal costoBase, decimal impuestos, string? ubicacion)
        {
            TipoHabitacion = tipoHabitacion ?? throw new ArgumentNullException(nameof(tipoHabitacion));
            CostoBase = costoBase;
            Impuestos = impuestos;
            Ubicacion = ubicacion;
        }

        public void HabilitarDeshabilitar(bool habilitada)
        {
            Habilitada = habilitada;
        }
    }
}
