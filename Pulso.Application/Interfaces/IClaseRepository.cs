using Pulso.Domain;

namespace Pulso.Application.Interfaces;

public interface IClaseRepository
{
    Clase? ObtenerPorId(int claseId);
}
