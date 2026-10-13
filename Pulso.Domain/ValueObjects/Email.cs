using Pulso.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Pulso.Domain;

public sealed partial record Email
{
    public string Valor { get; }

    public Email(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor) || !valor.Contains('@'))
            throw new EmailNoValidoException();

        var Normalizado = valor.Trim().ToLowerInvariant();

        if (!EmailRegex().IsMatch(Normalizado))
            throw new EmailNoValidoException();

        Valor = Normalizado;
    }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex EmailRegex();
}
