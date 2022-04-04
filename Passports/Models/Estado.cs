namespace Passports.Models;

public class Estado
{
    public bool Autenticado = false;
    public readonly IList<Usuario> Usuarios = new List<Usuario>
    {
        new Usuario
        {
            Cuenta = "admin",
            Contrasena = "password"
        }
    };

    public readonly IList<Pasaporte> NoImpresos = new List<Pasaporte>
    {
        new Pasaporte
        {
            Numero = 1,
            Nombre = "Juan",
            Apellido = "Perez",
            FechaDeExpiracion = DateTime.Now.AddYears(4),
        },
        new Pasaporte
        {
            Numero = 2,
            Nombre = "Mario",
            Apellido = "Lopez",
            FechaDeExpiracion = DateTime.Now.AddYears(4),
        },
        new Pasaporte
        {
            Numero = 3,
            Nombre = "Bryan",
            Apellido = "Gonzalez",
            FechaDeExpiracion = DateTime.Now.AddYears(4),
        },
        new Pasaporte
        {
            Numero = 4,
            Nombre = "María Fernanda",
            Apellido = "Jimenez",
            FechaDeExpiracion = DateTime.Now.AddYears(4),
        },
        new Pasaporte
        {
            Numero = 5,
            Nombre = "Carla",
            Apellido = "Mejía",
            FechaDeExpiracion = DateTime.Now.AddYears(4),
        },
        new Pasaporte
        {
            Numero = 6,
            Nombre = "Guillermo",
            Apellido = "Santos",
            FechaDeExpiracion = DateTime.Now.AddYears(4),
        },
        new Pasaporte
        {
            Numero = 7,
            Nombre = "Jason",
            Apellido = "Reyes",
            FechaDeExpiracion = DateTime.Now.AddYears(4),
        }
    };

    public readonly Queue<Pasaporte> Impresos = new Queue<Pasaporte>();
    public readonly IList<Pasaporte> Entregados = new List<Pasaporte>();
}
