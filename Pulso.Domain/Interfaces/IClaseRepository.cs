using Pulso.Domain.ValueObjects;

namespace Pulso.Domain.Interfaces;

public interface IClaseRepository
{
    Clase? ObtenerPorId(ClaseId claseId);
}
