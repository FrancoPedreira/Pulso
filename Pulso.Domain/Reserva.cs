using Pulso.Domain.Enums;

namespace Pulso.Domain
{
    public class Reserva
    {
        public int ReservaId { get; private set; }
        public DateTime FechaReserva { get; private set; }
        public EstadoReserva Estado { get; private set; }
        public int ClaseId { get; private set; }
        public Clase Clase { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        public Reserva(Clase clase, Usuario usuario, DateTime ahora)
        {
            if (clase == null)
                throw new ArgumentNullException(nameof(clase), "La clase no puede ser nula.");
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
            if (clase.YaComenzo(ahora))
                throw new InvalidOperationException("La clase ya ha comenzado.");
            if (clase.Estado == EstadoClase.Cancelada)
                throw new InvalidOperationException("No se puede reservar una clase cancelada.");
            Clase = clase;
            Usuario = usuario;
            FechaReserva = ahora;
            Estado = EstadoReserva.Confirmada;
        }

        public void Cancelar(DateTime ahora)
        {
            if (Estado == EstadoReserva.Cancelada)
                throw new InvalidOperationException("La reserva ya está cancelada.");
            if (Clase.YaComenzo(ahora))
                throw new InvalidOperationException("No se puede cancelar la reserva, la clase ya ha comenzado.");
            if (Clase.Fecha.AddHours(-2) <= ahora)
                throw new InvalidOperationException("No se puede cancelar la reserva, faltan menos de 2 horas para que comience la clase.");

            Estado = EstadoReserva.Cancelada;
        }
    }
}
