using System.Text.RegularExpressions;

namespace Pulso.Domain
{
    public class Usuario
    {
        public int UsuarioId { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public List<Reserva> Reservas { get; private set; }

        public Usuario(string nombre, string apellido, string email)
        {
            var emailLimpio = email?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede estar vacío.", nameof(apellido));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacío.", nameof(email));
            Nombre = nombre.Trim();
            Apellido = apellido.Trim();
            if (!EmailValido(emailLimpio))
                throw new ArgumentException("El email no es válido.", nameof(email));
            Email = emailLimpio;
            Reservas = new List<Reserva>();
        }

        private static bool EmailValido(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, regex);
        }
    }
}
