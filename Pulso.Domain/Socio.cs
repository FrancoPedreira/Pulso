using System;
using System.Collections.Generic;
using System.Text;

namespace Pulso.Domain
{
    public class Socio
    {
        public int SocioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}
