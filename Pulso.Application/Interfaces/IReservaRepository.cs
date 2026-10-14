using Pulso.Domain;
using Pulso.Domain.ValueObjects;

namespace Pulso.Application.Interfaces;

public interface IReservaRepository
{
    int ContarReservasActivas(ClaseId claseId);
    bool ExisteReservaActiva(ClaseId claseId, UsuarioId usuarioId);
    void Agregar(Reserva reserva);
}
