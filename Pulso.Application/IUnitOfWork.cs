namespace Pulso.Application;

public interface IUnitOfWork
{
    Task GuardarCambiosAsync();
}
