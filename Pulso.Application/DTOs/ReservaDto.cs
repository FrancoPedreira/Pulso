using Pulso.Domain;

namespace Pulso.Application.DTOs;

public record ReservaDto(int ReservaId, string NombreClase, DateTime FechaClase, string EstadoReserva)
{
    public static ReservaDto TransformarADto(Reserva reserva)
    {
        return new ReservaDto(reserva.ReservaId, reserva.Clase.Nombre, reserva.Clase.Fecha, reserva.Estado.ToString());
    }
}