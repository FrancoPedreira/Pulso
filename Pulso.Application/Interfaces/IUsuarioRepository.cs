using Pulso.Domain;

namespace Pulso.Application.Interfaces;

public interface IUsuarioRepository
{
    Usuario? ObtenerPorEmail(string email);
}
