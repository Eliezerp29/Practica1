using System;




namespace Elivator1
{
    class Elivator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al Elivator inserte el Peso : ");
            double pesolimite = int.Parse(Console.ReadLine());


            persona persona = new persona();

            double pesoacumulado = 0;
            int cantidaddepersonas = 0;
            while (pesolimite >= pesoacumulado)
            {
                Console.WriteLine("Inserte su nombre : ");
                persona.nombre = Console.ReadLine();
                Console.WriteLine("Inserte su Sexo: ");
                persona.sexo = Console.ReadLine();
                Console.WriteLine("Inserte su peso: ");
                persona.peso = double.Parse(Console.ReadLine());
                pesoacumulado = pesoacumulado + persona.peso;

                



                if (pesolimite >= pesoacumulado )
                {
                    Console.WriteLine("Saludos {0} de sexo {2} su peso que es {1} es aceptado", persona.nombre, persona.peso, persona.sexo);
                    cantidaddepersonas = cantidaddepersonas + 1;
                }
                else
                {
                    Console.WriteLine("Lo sentimos un peso de {0} alncanza el limite pero puede usar las escaleras o esperar el proximo",  persona.peso);
                   
                    Console.WriteLine("Cantidad de personas " + cantidaddepersonas);
                    break;

                }


            }


        }

    }
    public class persona
    {
        public string nombre;
        public string sexo;
        public double peso;

    }
}
    

