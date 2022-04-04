using Passports.Models;
using Passports.MenuOptions;
using System.Text;

namespace Passports;

public class Program
{
    private static Estado estado = new Estado();

    private static readonly IList<OpcionDelMenu> menuOptions = new List<OpcionDelMenu>
    {
        new ImprimirPasaporte(),
        new EntregarPasaporte(),
        new ListarPasaportesEntregados(),
        new CerrarSesion()
    };

    static void Main(string[] args)
    {
        ValidarCredenciales();
        Menu();
    }

    public static void ValidarCredenciales()
    {
        while (!estado.Autenticado)
        {
            Console.Clear();
            Console.WriteLine("====================================================================================");
            Console.WriteLine("Credenciales del Usuario");
            Console.WriteLine("Para acceder al sistema se necesitan sus credenciales. Favor suministrar las mismas.");
            Console.WriteLine("====================================================================================");

            Console.WriteLine("");
            Console.WriteLine("Cuenta:");
            var cuentaInput = Console.ReadLine();

            Console.WriteLine("Contraseña:");
            StringBuilder passwordBuilder = new StringBuilder();
            bool continueReading = true;
            char newLineChar = '\r';
            while (continueReading)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                char passwordChar = consoleKeyInfo.KeyChar;

                if (passwordChar == newLineChar)
                {
                    continueReading = false;
                }
                else
                {
                    passwordBuilder.Append(passwordChar.ToString());
                }
            }

            foreach (var usuario in estado.Usuarios)
            {
                if (usuario.Cuenta == cuentaInput && usuario.Contrasena == passwordBuilder.ToString())
                {
                    estado.Autenticado = true;
                    return;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("No se ha podido validar su usuario correctamente. Presione cualquiera tecla para intentar nuevamente.");
            Console.ReadKey();
        }
    }

    public static void Menu()
    {
        while (estado.Autenticado)
        {
            Console.Clear();
            Console.WriteLine("====================================================================================");
            Console.WriteLine("Menú");
            Console.WriteLine("Seleccione una opción utilizando su número.");
            Console.WriteLine("====================================================================================");

            foreach (var menuOption in menuOptions.Select((value, i) => new { i, value }))
            {
                Console.WriteLine(String.Format("{0}. {1}", menuOption.i + 1, menuOption.value.Titulo));
            }

            Console.WriteLine("");
            Console.WriteLine("Opción:");

            // Eliminar strings y números negativos
            if (!int.TryParse(Console.ReadLine(), out int option) || option < 1)
            {
                ManejarOpcionNoValida();
                continue;
            }

            var selectedOption = menuOptions.ElementAtOrDefault(option - 1);

            // Asegurar que haya una opción con ese número en el menú
            if(selectedOption == null)
            {
                ManejarOpcionNoValida();
                continue;
            }

            selectedOption.Ejecutar(ref estado);
        }
    }

    public static void ManejarOpcionNoValida()
    {
        Console.WriteLine("");
        Console.WriteLine("La opción seleccionada no es válida, presione cualquiera tecla para intentar nuevamente.");
        Console.ReadKey();
    }
}