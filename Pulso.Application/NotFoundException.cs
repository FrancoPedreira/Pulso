namespace Pulso.Application;

public class NotFoundException(string message) : Exception(message)
{
}
