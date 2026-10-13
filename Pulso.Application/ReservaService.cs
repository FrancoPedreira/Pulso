using Pulso.Application.DTOs;
using Pulso.Domain;
using Pulso.Domain.Exceptions;
using Pulso.Domain.Interfaces;
using Pulso.Domain.ValueObjects;

namespace Pulso.Application;

public class ReservaService(IReservaRepository reservaRepository, IClaseRepository claseRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
{
    private readonly IReservaRepository _reservaRepository = reservaRepository;
    private readonly IClaseRepository _claseRepository = claseRepository;
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ReservaDto> ReservarAsync(ReservarRequest request)
    {
        var clase = _claseRepository.ObtenerPorId(request.ClaseId) ?? throw new ClaseNotFoundException();

        int cantidadReservasActivas = _reservaRepository.ContarReservasActivas(clase.ClaseId);
        if (cantidadReservasActivas >= clase.CupoMaximo)
            throw new CupoLimiteException();

        var usuario = _usuarioRepository.ObtenerPorEmail(request.Email) ?? throw new EmailNotFoundException();

        if (_reservaRepository.ExisteReservaActiva(clase.ClaseId, usuario.UsuarioId))
            throw new ReservaActivaExistenteException();

        var reserva = new Reserva(clase, usuario, DateTime.Now);

        _reservaRepository.Agregar(reserva);

        await _unitOfWork.GuardarCambiosAsync();

        return ReservaDto.TransformarADto(reserva);
    }
}
public record ReservarRequest(ClaseId ClaseId, Email Email);