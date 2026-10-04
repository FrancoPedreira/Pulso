using Pulso.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulso.Domain
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public EstadoReserva Estado { get; set; } // "Confirmada" o "Cancelada" por socio
        public int ClaseId { get; set; }
        public Clase Clase { get; set; }
        public int SocioId { get; set; }
        public Socio Socio { get; set; }
    }
}
