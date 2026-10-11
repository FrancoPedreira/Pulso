using Pulso.Domain;

namespace Pulso.Application.Interfaces;

public interface IReservaRepository
{
    int ContarReservasActivas(int claseId);
    bool ExisteReservaActiva(int claseId, int usuarioId);
    void Agregar(Reserva reserva);
}
