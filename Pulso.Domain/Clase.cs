using Pulso.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulso.Domain
{
    public class Clase
    {
        public int ClaseId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public List<Reserva> Reservas { get; set; }
        public int CupoMaximo { get; set; }
        public EstadoClase Estado { get; set; } // "Activa", "Terminada" o "Cancelada" por admin
    }
}
