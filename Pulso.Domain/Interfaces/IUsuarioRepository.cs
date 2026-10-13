namespace Pulso.Domain.Interfaces;

public interface IUsuarioRepository
{
    Usuario? ObtenerPorEmail(Email email);
}
