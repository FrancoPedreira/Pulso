using Pulso.Application.DTOs;
using Pulso.Domain;
using Pulso.Domain.Exceptions;
using Pulso.Domain.ValueObjects;

namespace Pulso.Application;

public class ReservaService(IUnitOfWork unitOfWork)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ReservaDto> ReservarAsync(ReservarRequest request)
    {
        var clase = _unitOfWork.ClaseRepository.ObtenerPorId(request.ClaseId) ?? throw new ClaseNotFoundException();

        int cantidadReservasActivas = _unitOfWork.ReservaRepository.ContarReservasActivas(clase.ClaseId);
        if (cantidadReservasActivas >= clase.CupoMaximo)
            throw new CupoLimiteException();

        var usuario = _unitOfWork.UsuarioRepository.ObtenerPorEmail(request.Email) ?? throw new EmailNotFoundException();

        if (_unitOfWork.ReservaRepository.ExisteReservaActiva(clase.ClaseId, usuario.UsuarioId))
            throw new ReservaActivaExistenteException();

        var reserva = new Reserva(clase, usuario, DateTime.Now);

        _unitOfWork.ReservaRepository.Agregar(reserva);

        await _unitOfWork.GuardarCambiosAsync();

        return ReservaDto.TransformarADto(reserva);
    }
}
public record ReservarRequest(ClaseId ClaseId, Email Email);