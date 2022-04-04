namespace Passports.Exceptions;

public class PasaporteYaEntregadoException : Exception
{
	public PasaporteYaEntregadoException()
		: base("El pasaporte seleccionado ya fue entregado.")
	{
	}
}

