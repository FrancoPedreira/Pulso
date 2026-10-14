using Pulso.Application.Interfaces;

namespace Pulso.Application;

public interface IUnitOfWork : IDisposable
{
    IReservaRepository ReservaRepository { get; }
    IClaseRepository ClaseRepository { get; }
    IUsuarioRepository UsuarioRepository { get; }

    Task GuardarCambiosAsync();

}
