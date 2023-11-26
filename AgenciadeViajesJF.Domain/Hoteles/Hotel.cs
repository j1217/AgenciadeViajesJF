// AgenciadeViajesJF.Domain.Hoteles/Hotel.cs
using System;
using System.Collections.Generic;

namespace AgenciadeViajesJF.Domain.Hoteles
{
    public class Hotel
    {
        public int IdHotel { get; private set; }
        public string Nombre { get; private set; }
        public string? Direccion { get; private set; }
        public string? Descripcion { get; private set; }
        public int? Estrellas { get; private set; }
        public string? Telefono { get; private set; }
        public string? CorreoElectronico { get; private set; }
        public string? SitioWeb { get; private set; }
        public bool? Habilitado { get; private set; }

        public virtual ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();

        private Hotel() { } // Constructor privado para Entity Framework

        public Hotel(string nombre, string? direccion, string? descripcion, int? estrellas, string? telefono, string? correoElectronico, string? sitioWeb)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Direccion = direccion;
            Descripcion = descripcion;
            Estrellas = estrellas;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            SitioWeb = sitioWeb;
            Habilitado = true; // Por defecto, el hotel se crea habilitado
        }

        public void ModificarValores(string nombre, string? direccion, string? descripcion, int? estrellas, string? telefono, string? correoElectronico, string? sitioWeb)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Direccion = direccion;
            Descripcion = descripcion;
            Estrellas = estrellas;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            SitioWeb = sitioWeb;
        }

        public void HabilitarDeshabilitar(bool habilitado)
        {
            Habilitado = habilitado;
        }
    }
}
