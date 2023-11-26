using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Application.Features.GestionHoteles.Interfaces
{
    public interface IGestionHotelUseCase
    {
        Task CrearNuevoHotel(string nombre, string direccion, string descripcion, int estrellas, string telefono, string correoElectronico, string sitioWeb);
        Task AsignarHabitacionesAlHotel(int idHotel, List<HabitacionDTO> habitaciones);
        Task ModificarValoresHabitacion(int idHabitacion, HabitacionDTO habitacion);
        Task ModificarValoresHotel(int idHotel, HotelDTO hotel);
        Task HabilitarDeshabilitarHotel(int idHotel, bool habilitado);
        Task HabilitarDeshabilitarHabitacion(int idHabitacion, bool habilitada);
    }

    public interface IHabitacionDTO
    {
        string TipoHabitacion { get; set; }
        decimal CostoBase { get; set; }
        decimal Impuestos { get; set; }
        string Ubicacion { get; set; }
    }

    public interface IHotelDTO
    {
        string Nombre { get; set; }
        string Direccion { get; set; }
        string Descripcion { get; set; }
        int Estrellas { get; set; }
        string Telefono { get; set; }
        string CorreoElectronico { get; set; }
        string SitioWeb { get; set; }
    }

    public class HabitacionDTO : IHabitacionDTO
    {
        public string TipoHabitacion { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Impuestos { get; set; }
        public string Ubicacion { get; set; }
    }

    public class HotelDTO : IHotelDTO
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public int Estrellas { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string SitioWeb { get; set; }
    }

}
