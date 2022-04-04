namespace Passports.Models
{
	public abstract class OpcionDelMenu
	{
		protected bool requiereConfirmacion = true;

		public abstract string Titulo { get; }
		protected abstract void Accion(ref Estado estado);

		public void Ejecutar(ref Estado estado)
        {
			Console.Clear();
			Console.WriteLine("====================================================================================");
			Console.WriteLine(Titulo);
			Console.WriteLine("====================================================================================");
			Console.WriteLine("");

			Accion(ref estado);

            if (requiereConfirmacion)
            {
				Console.WriteLine("");
				Console.WriteLine("Presione cualquiera tecla para volver al menú principal.");
				Console.ReadKey();
			}
		}

		protected static void MostrarPasaporte(Pasaporte pasaporte)
		{
			Console.WriteLine("");
			Console.WriteLine("Pasaporte # {0}", pasaporte.Numero);
			Console.WriteLine("Nombre Propietario: {0}", pasaporte.NombreCompleto);
			Console.WriteLine("Fecha de Entrega: {0}",
				pasaporte.FechaDeEntrega != null
				? pasaporte.FechaDeEntrega.Value
				: "NO DISPONIBLE");
			Console.WriteLine("Fecha de Expiración: {0}", pasaporte.FechaDeExpiracion);
		}
	}
}

