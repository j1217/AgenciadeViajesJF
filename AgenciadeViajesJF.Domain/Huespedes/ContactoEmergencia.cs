using System;

namespace AgenciadeViajesJF.Domain.Huespedes
{
    public class ContactoEmergencia
    {
        public int IdContactoEmergencia { get; private set; }
        public string Nombres { get; private set; }
        public string Telefono { get; private set; }

        private ContactoEmergencia() { } // Constructor privado para Entity Framework

        public ContactoEmergencia(string nombres, string telefono)
        {
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
        }
    }
}
