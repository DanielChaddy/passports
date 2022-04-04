using Passports.Models;

namespace Passports.MenuOptions;

public class CerrarSesion : OpcionDelMenu
{
    public CerrarSesion()
    {
        requiereConfirmacion = false;
    }

    public override string Titulo
    {
        get => "Cerrar Sesión";
    }

    protected override void Accion(ref Estado estado)
    {
        Console.WriteLine("¿Está seguro que desea cerrar sesión? (s/n):");
        var seleccion = Console.ReadLine();

        if (seleccion == null || seleccion.ToLower() != "s")
        {
            return;
        }

        estado.Autenticado = false;
        Console.WriteLine("Sesión cerrada satisfactoriamente.");
    }
}

