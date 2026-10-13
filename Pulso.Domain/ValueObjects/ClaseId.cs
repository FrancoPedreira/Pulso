namespace Pulso.Domain.ValueObjects;

public readonly record struct ClaseId(int Valor); //Cree un record struct inmutable para representar el identificador de una clase y que en el metodo reservar y no confundan ClaseId con UsuarioId.
