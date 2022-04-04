using Passports.Models;

namespace Passports.MenuOptions;

public class EntregarPasaporte : OpcionDelMenu
{
    public override string Titulo
    {
        get => "Entregar próximo pasaporte";
    }

    protected override void Accion(ref Estado estado)
    {
        try
        {
            if(estado.Impresos.Count <= 0)
            {
                Console.WriteLine("No hay pasaportes a entregar.");
                return;
            }

            var pasaporte = estado.Impresos.Peek();
            Console.WriteLine("Pasaporte a entregar: ");
            Console.WriteLine("");
            MostrarPasaporte(pasaporte);
            Console.WriteLine("");
            Console.WriteLine("Entregando pasaporte...");

            pasaporte.Entregar();
            estado.Impresos.Dequeue();
            estado.Entregados.Add(pasaporte);

            Thread.Sleep(1000);
            Console.WriteLine("Pasaporte entregado satisfactoriamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
