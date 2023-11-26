using System;
using System.Collections.Generic;

namespace AgenciadeViajesJF.Domain.Huespedes
{
    public class Huesped
    {
        public int IdHuesped { get; private set; }
        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }
        public DateTime? FechaNacimiento { get; private set; }
        public string? Genero { get; private set; }
        public string? TipoDocumento { get; private set; }
        public string? NumeroDocumento { get; private set; }
        public string? Email { get; private set; }
        public string? Telefono { get; private set; }

        private Huesped() { } // Constructor privado para Entity Framework

        public Huesped(
            string nombres,
            string apellidos,
            DateTime? fechaNacimiento,
            string? genero,
            string? tipoDocumento,
            string? numeroDocumento,
            string? email,
            string? telefono)
        {
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            FechaNacimiento = fechaNacimiento;
            Genero = genero;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Email = email;
            Telefono = telefono;
        }
    }
}