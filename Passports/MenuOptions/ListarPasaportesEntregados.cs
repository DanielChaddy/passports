using Passports.Models;

namespace Passports.MenuOptions;

public class ListarPasaportesEntregados : OpcionDelMenu
{
	public override string Titulo
    {
		get => "Pasaportes entregados";
    }

	protected override void Accion(ref Estado estado)
    {
        foreach (var pasaporte in estado.Entregados)
        {
            MostrarPasaporte(pasaporte);
        }
    }
}