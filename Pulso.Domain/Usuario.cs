using Pulso.Domain.Exceptions;
using Pulso.Domain.ValueObjects;

namespace Pulso.Domain;

public partial class Usuario
{
    public UsuarioId UsuarioId { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public Email Email { get; private set; }
    public List<Reserva> Reservas { get; private set; }

    public Usuario(string nombre, string apellido, Email email)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new NombreVacioException();
        if (string.IsNullOrWhiteSpace(apellido))
            throw new ApellidoVacioException();
        Nombre = nombre.Trim();
        Apellido = apellido.Trim();
        Email = email;
        Reservas = [];
    }

}