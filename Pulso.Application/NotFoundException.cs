namespace Pulso.Application;

public class NotFoundException(string message) : Exception(message);
public class ClaseNotFoundException() : NotFoundException("La clase que intenta reservar no existe.");
public class EmailNotFoundException() : NotFoundException("El email que intenta reservar no existe.");