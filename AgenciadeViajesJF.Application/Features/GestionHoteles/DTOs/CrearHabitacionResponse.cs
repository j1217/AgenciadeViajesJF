using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciadeViajesJF.Application.Features.GestionHoteles.DTOs
{
    internal class CrearHabitacionResponse
    {
        public int IdHabitacion { get; set; }
        public string TipoHabitacion { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Impuestos { get; set; }
        public string Ubicacion { get; set; }
        public bool Habilitada { get; set; }
        public int IdHotel { get; set; }
        public string NombreHotel { get; set; }
    }
}

