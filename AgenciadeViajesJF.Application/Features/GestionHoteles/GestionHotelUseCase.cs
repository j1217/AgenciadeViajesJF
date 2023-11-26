using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenciadeViajesJF.Application.Features.GestionHoteles.Interfaces;
using AgenciadeViajesJF.Domain.Hoteles;
using AgenciadeViajesJF.Domain.Hoteles.Interfaces;
using AgenciadeViajesJF.Exceptions;

namespace AgenciadeViajesJF.Application.Features.GestionHoteles
{
    public class GestionHotelUseCase : IGestionHotelUseCase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IHabitacionRepository _habitacionRepository;

        public GestionHotelUseCase(IHotelRepository hotelRepository, IHabitacionRepository habitacionRepository)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _habitacionRepository = habitacionRepository ?? throw new ArgumentNullException(nameof(habitacionRepository));
        }

        public async Task CrearNuevoHotel(string nombre, string direccion, string descripcion, int estrellas, string telefono, string correoElectronico, string sitioWeb)
        {
            var nuevoHotel = new Hotel(nombre, direccion, descripcion, estrellas, telefono, correoElectronico, sitioWeb);
            await _hotelRepository.AgregarHotel(nuevoHotel);
        }

        public async Task AsignarHabitacionesAlHotel(int idHotel, List<HabitacionDTO> habitaciones)
        {
            var hotel = await _hotelRepository.ObtenerHotelPorId(idHotel);
            if (hotel == null)
            {
                // Manejo el caso en el que el hotel no existe
                throw new CustomException<ErrorCode>(ErrorCode.HotelNoEncontrado, "El hotel no se encontró.");
            }

            var habitacionesHotel = habitaciones.Select(dto => new Habitacion(dto.TipoHabitacion, dto.CostoBase, dto.Impuestos, dto.Ubicacion)).ToList();

            // Asignar habitaciones al hotel
            hotel.Habitaciones = habitacionesHotel;

            await _hotelRepository.ActualizarHotel(hotel);
        }

        public async Task ModificarValoresHabitacion(int idHabitacion, HabitacionDTO habitacion)
        {
            var habitacionExistente = await _habitacionRepository.ObtenerHabitacionPorId(idHabitacion);
            if (habitacionExistente == null)
            {
                // Manejar el caso en el que la habitación no existe
                throw new CustomException<ErrorCode>(ErrorCode.HabitacionNoEncontrada, "La habitación no se encontró.");
            }

            habitacionExistente.ModificarValores(habitacion.TipoHabitacion, habitacion.CostoBase, habitacion.Impuestos, habitacion.Ubicacion);

            await _habitacionRepository.ActualizarHabitacion(habitacionExistente);
        }

        public async Task ModificarValoresHotel(int idHotel, HotelDTO hotel)
        {
            var hotelExistente = await _hotelRepository.ObtenerHotelPorId(idHotel);
            if (hotelExistente == null)
            {
                // Manejar el caso en el que el hotel no existe
                throw new CustomException<ErrorCode>(ErrorCode.HotelNoEncontrado, "El hotel no se encontró.");
            }

            hotelExistente.ModificarValores(hotel.Nombre, hotel.Direccion, hotel.Descripcion, hotel.Estrellas, hotel.Telefono, hotel.CorreoElectronico, hotel.SitioWeb);

            await _hotelRepository.ActualizarHotel(hotelExistente);
        }

        public async Task HabilitarDeshabilitarHotel(int idHotel, bool habilitado)
        {
            var hotelExistente = await _hotelRepository.ObtenerHotelPorId(idHotel);
            if (hotelExistente == null)
            {
                // Manejar el caso en el que el hotel no existe
                throw new CustomException<ErrorCode>(ErrorCode.HotelNoEncontrado, "El hotel no se encontró.");
            }

            hotelExistente.HabilitarDeshabilitar(habilitado);

            await _hotelRepository.ActualizarHotel(hotelExistente);
        }

        public async Task HabilitarDeshabilitarHabitacion(int idHabitacion, bool habilitada)
        {
            var habitacionExistente = await _habitacionRepository.ObtenerHabitacionPorId(idHabitacion);
            if (habitacionExistente == null)
            {
                // Manejar el caso en el que la habitación no existe
                throw new CustomException<ErrorCode>(ErrorCode.HabitacionNoEncontrada, "La habitación no se encontró.");
            }

            habitacionExistente.HabilitarDeshabilitar(habilitada);

            await _habitacionRepository.ActualizarHabitacion(habitacionExistente);
        }

    }
}
