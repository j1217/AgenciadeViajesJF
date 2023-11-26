
using System;

namespace AgenciadeViajesJF.Exceptions
{
    // Enumeración que representa los posibles códigos de error
    public enum ErrorCode
    {
        HotelNoEncontrado,
        HabitacionNoEncontrada,
        ReservaNoEncontrada,
        ErrorActualizandoReserva,
        // Agrega otros códigos de error según sea necesario
    }
    public class CustomException<T> : Exception
    {
        public T ErrorCode { get; }

        public CustomException(T errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
