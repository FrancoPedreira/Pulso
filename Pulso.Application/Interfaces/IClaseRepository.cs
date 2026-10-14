using Pulso.Domain;
using Pulso.Domain.ValueObjects;

namespace Pulso.Application.Interfaces;

public interface IClaseRepository
{
    Clase? ObtenerPorId(ClaseId claseId);
}
