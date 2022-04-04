namespace Passports.Exceptions;

public class NoImpresionException : Exception
{
	public NoImpresionException()
		: base("No existen impresiones para el pasaporte deseado.")
	{
	}
}

