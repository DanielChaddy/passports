using Passports.Exceptions;

namespace Passports.Models;

public class Pasaporte
{
	public int Numero { get; set; }
	public DateTime? FechaDeEntrega { get; set; }
	public DateTime FechaDeExpiracion { get; set; }

	public string Nombre { get; set; }
	public string Apellido { get; set; }

	public string NombreCompleto
    {
		get => string.Format("{0} {1}", Nombre, Apellido);
	}

	public void Entregar()
    {
        if (FechaDeEntrega != null)
        {
			throw new PasaporteYaEntregadoException();
        }

		FechaDeEntrega = DateTime.Now;
	}
}