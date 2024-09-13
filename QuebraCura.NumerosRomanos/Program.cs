namespace QuebraCura.NumerosRomanos;

internal class Program
{
	static void Main(string[] args)
	{
		while (true)
		{
			Console.WriteLine("Informe o numero romano que deseja converter:");
			string digitado = Console.ReadLine().ToUpper();

			int numero = CalcularNumero(digitado);

			if (numero == 0)
			{
				Console.WriteLine("\nSintaxe inválida!");
			}
			else
			{
				Console.WriteLine($"\n{digitado} = {numero}");
			}

			Console.ReadLine();
			Console.Clear();
		}
	}

	private static int CalcularNumero(string digitado)
	{
		if (!Validar(digitado))
			return 0;

		int valor = 0;
		string maiores = "VXLCDM";

		for (int i = 0; i < digitado.Length; i++)
		{
			if (digitado[i].Equals('M'))
				valor += 1000;
			else if (digitado[i].Equals('D'))
				valor += 500;
			else if (digitado[i].Equals('C'))
			{
				if ((i + 1) < digitado.Length && maiores.Split("C")[1].Contains(digitado[i + 1]))
				{
					valor -= 100;
					continue;
				}
				valor += 100;
			}
			else if (digitado[i].Equals('L'))
				valor += 50;
			else if (digitado[i].Equals('X'))
			{
				if ((i + 1) < digitado.Length && maiores.Split("X")[1].Contains(digitado[i + 1]))
				{
					valor -= 10;
					continue;
				}
				valor += 10;
			}
			else if (digitado[i].Equals('V'))
				valor += 5;
			else if (digitado[i].Equals('I'))
			{
				if ((i + 1) < digitado.Length && maiores.Contains(digitado[i + 1]))
				{
					valor -= 1;
					continue;
				}
				valor += 1;
			}
		}

		return valor;
	}

	private static bool Validar(string digitado)
	{
		string regra = "IXM";
		int ocorrencia;
		for (int i = 0; i < 3; i++)
		{
			ocorrencia = 0;
			for (int j = 0; j < digitado.Length; j++)
			{
				if (j + 1 < digitado.Length && (digitado[j] == regra[i] && digitado[j + 1] == regra[i]))
					ocorrencia++;
			}

			if (ocorrencia > 2)
				return false;
		}

		return true;
	}

}
