using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Insete la cantidad de dinero quej tiene");
			string T = Console.ReadLine().ToUpper();
			Console.WriteLine("Inserte su edad");
			int E = int.Parse(Console.ReadLine().ToUpper());
			Console.WriteLine("Inserte su genero");
			Char P = Console.ReadLine().ToUpper()[0];




		}

		static void equipo(string T, int E, Char G)
		{

			if (E >= 18 && E <25)
			{
				Console.WriteLine("Es clase A");
			}
			else
			{
				Console.WriteLine("Usted no pertenece al complejo");
			}
			switch (G)
			{
				case 'm':
					{
						Console.WriteLine("Masculino");
					}break;
				case 'f':
					{
						Console.Write("Usted es una mujer" + "no puede jugar");
					}break;
				case 'i':
					{
						Console.WriteLine("Usted tiene que definirse");

					}



			}
			
				
			
		}
	}
}
