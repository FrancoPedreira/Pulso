using Pulso.Domain.Enums;
using Pulso.Domain.Exceptions;

namespace Pulso.Domain;
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
        if (clase is null)
            throw new ArgumentNullException(nameof(clase), "La clase no puede ser nula.");
        if (usuario is null)
            throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
        if (clase.YaComenzo(ahora))
            throw new ReglaNegocioException("La clase ya ha comenzado.");
        if (clase.Estado is EstadoClase.Cancelada)
            throw new ReglaNegocioException("No se puede reservar una clase cancelada.");
        Clase = clase;
        Usuario = usuario;
        FechaReserva = ahora;
        Estado = EstadoReserva.Confirmada;
    }

    public void Cancelar(DateTime ahora)
    {
        if (Estado is EstadoReserva.Cancelada)
            throw new ReglaNegocioException("La reserva ya está cancelada.");
        if (Clase.YaComenzo(ahora))
            throw new ReglaNegocioException("No se puede cancelar la reserva, la clase ya ha comenzado.");
        if (Clase.Fecha.AddHours(-2) <= ahora)
            throw new ReglaNegocioException("No se puede cancelar la reserva, faltan menos de 2 horas para que comience la clase.");

        Estado = EstadoReserva.Cancelada;
    }
}
