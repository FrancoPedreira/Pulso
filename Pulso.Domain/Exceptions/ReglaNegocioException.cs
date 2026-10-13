namespace Pulso.Domain.Exceptions;

public class ReglaNegocioException(string message) : Exception(message);
public class NombreVacioException() : ReglaNegocioException("El nombre no puede estar vacío.");
public class ApellidoVacioException() : ReglaNegocioException("El apellido no puede estar vacio");
public class EmailVacioException() : ReglaNegocioException("El email no puede estar vacio");
public class EmailNoValidoException() : ReglaNegocioException("El email no es válido.");
public class CupoLimiteException() : ReglaNegocioException("No se puede reservar la clase, ya se alcanzó el límite de reservas activas.");
public class ReservaActivaExistenteException() : ReglaNegocioException("El usuario ya tiene una reserva activa para esta clase.");