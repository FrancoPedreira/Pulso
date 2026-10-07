using Pulso.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulso.Domain
{
    public class Clase
    {
        public int ClaseId { get; private set; }
        public string Nombre { get; private set; }
        public DateTime Fecha { get; private set; }
        public List<Reserva> Reservas { get; private set; }
        public int CupoMaximo { get; private set; }
        public EstadoClase Estado { get; private set; }
        public bool YaComenzo(DateTime ahora) => ahora >= Fecha;

        public Clase(string nombre, DateTime fecha, int cupoMaximo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la clase no puede estar vacío.", nameof(nombre));
            Nombre = nombre.Trim();
            Fecha = fecha;
            if (cupoMaximo <= 0)
                throw new ArgumentException("El cupo máximo debe ser mayor a cero.", nameof(cupoMaximo));
            CupoMaximo = cupoMaximo;
            Reservas = new List<Reserva>();
            Estado = EstadoClase.Activa;
        }

        public void Cancelar()
        {
            if (Estado == EstadoClase.Cancelada)
                throw new InvalidOperationException("La clase ya está cancelada.");

            Estado = EstadoClase.Cancelada;
        }


    }
}
