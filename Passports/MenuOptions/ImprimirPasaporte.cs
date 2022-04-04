using Passports.Models;

namespace Passports.MenuOptions;

public class ImprimirPasaporte : OpcionDelMenu
{
	public override string Titulo
    {
        get => "Imprimir pasaporte";
    }

	protected override void Accion(ref Estado estado)
    {
        if (estado.NoImpresos.Count <= 0)
        {
            Console.WriteLine("No hay pasaportes a imprimir.");
            return;
        }

        Console.WriteLine("Pasaportes aún no impresos:");

        foreach (var pasaporte in estado.NoImpresos)
        {
            MostrarPasaporte(pasaporte);
        }

        Console.WriteLine("");
        Console.WriteLine("Favor ingresar el número del pasaporte a imprimir:");

        if (!int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine("El número ingresado no es válido.");
        }

        var seleccionado = estado.NoImpresos.SingleOrDefault(p => p.Numero == numero);

        if (seleccionado == null)
        {
            Console.WriteLine("El pasaporte de número #{0} no existe o ya ha sido impreso.", numero);
            return;
        }

        Console.WriteLine("");
        Console.WriteLine("Imprimiendo pasaporte...");

        estado.Impresos.Enqueue(seleccionado);
        estado.NoImpresos.Remove(seleccionado);
        
        Thread.Sleep(1000);
        Console.WriteLine("Pasaporte impreso satisfactoriamente.");
    }
}

