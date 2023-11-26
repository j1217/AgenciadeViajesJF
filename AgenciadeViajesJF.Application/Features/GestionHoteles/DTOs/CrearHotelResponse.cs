using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Application.Features.GestionHoteles.DTOs
{
    internal class CrearHotelResponse
    {
        public int IdHotel { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public int Estrellas { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string SitioWeb { get; set; }
    }
}
