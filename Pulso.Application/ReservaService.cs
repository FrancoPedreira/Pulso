using Pulso.Application.DTOs;
using Pulso.Application.Interfaces;
using Pulso.Domain;
using Pulso.Domain.Exceptions;

namespace Pulso.Application;

public class ReservaService(IReservaRepository reservaRepository, IClaseRepository claseRepository, IUsuarioRepository usuarioRepository)
{
    private readonly IReservaRepository _reservaRepository = reservaRepository;
    private readonly IClaseRepository _claseRepository = claseRepository;
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

    public ReservaDto Reservar(int claseId, string email)
    {
        email = Usuario.NormalizarEmail(email);

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("El email esta vacio o no es valido.", nameof(email));

        var clase = _claseRepository.ObtenerPorId(claseId) ?? throw new NotFoundException("La clase que quiere reservar no existe.");

        int cantidadReservasActivas = _reservaRepository.ContarReservasActivas(claseId);
        if (cantidadReservasActivas >= clase.CupoMaximo)
            throw new ReglaNegocioException("No se puede reservar la clase, ya se alcanzó el límite de reservas activas.");

        var usuario = _usuarioRepository.ObtenerPorEmail(email) ?? throw new NotFoundException("El usuario que intenta reservar no existe.");

        if (_reservaRepository.ExisteReservaActiva(claseId, usuario.UsuarioId))
            throw new ReglaNegocioException("El usuario ya tiene una reserva activa para esta clase.");

        var reserva = new Reserva(clase, usuario, DateTime.Now);

        _reservaRepository.Agregar(reserva);

        return ReservaDto.TransformarADto(reserva);
    }
}
