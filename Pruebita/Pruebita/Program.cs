using System;
using System.Collections.Generic;

namespace Pruebita

/*
    Los criterios de aceptación de la práctica son los siguientes:
1- Se debe crear un catálogo de productos con su nombre y precio
2- Se debe capturar el nombre y el capital que posee el cliente
3- Se debe capturar los producto que quiere el cliente y la cantidad.
4- Se debe preguntar si quiere comprar otro producto, mientras la respuesta sea afirmativa
debe repetirse el punto 3 de esta práctica y en caso contrario debe imprimir el detalle de la compra; 
la misma debe contener el nombre del cliente, su capital y el detalle de productos adquiridos con el total del 
valor de la compra.
5- Debe imprimir un mensaje debajo del detalle del punto 4 mencionando si el cliente puede proceder la 
compra o no dependiendo de el capital del mismo.

        */
{
    class Program
    {
        static void Main(string[] args)
        {

            List<alimento> ListaAlimento = new List<alimento>();
            Console.WriteLine("Bienvenido a la bodega eliezer");
            Console.WriteLine("Inserte la cantidad de elementos que desea comprar");
            int cantidad = Convert.ToInt32(Console.ReadLine());



            for (int i = 1; i <= cantidad; i++)
            {
                alimento Forlimento = new alimento();
                Forlimento.ID = i;
                Console.WriteLine("Inserte el nombre del producto");
                Forlimento.Nombre = Console.ReadLine();
                Console.WriteLine("Inserte el Precio del producto");
                Forlimento.Precio = Convert.ToInt32 (Console.ReadLine());

                ListaAlimento.Add(Forlimento);
                

            }
            cliente Client = new cliente();
            Console.WriteLine("Inserte el Nombre del Cliente");
            Client.Nombre = Console.ReadLine();
            Console.WriteLine("Inserte Su Capital ");
            Client.Capital = Convert.ToInt32 (Console.ReadLine());

            List<Factura> ListaFactura = new List<Factura>();
            bool continuar = true;

            while (continuar == true)
            {
                Factura WhileFactura = new Factura();

                foreach (var EachAlimento in ListaAlimento)
                {
                    Console.WriteLine(EachAlimento.ID + "" + EachAlimento.Nombre + "" + "$" + EachAlimento.Precio);
                }

                Console.WriteLine("Que Alimento Desea Elegir");
                int IDProducto = Convert.ToInt32(Console.ReadLine());

                foreach (var Eachilimento in ListaAlimento)
                {
                    if (Eachilimento.ID == IDProducto)
                    {
                        WhileFactura.Alimento = Eachilimento;

                    }

                    
                }

                Console.WriteLine("Cuantos Alimentos de estos Deseas?");
                WhileFactura.Cantidad = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("Desea Seguir Comprando");
                string respuesta = Console.ReadLine();
                respuesta = respuesta.ToUpper();
                if (respuesta=="SI")
                {
                    continuar = true;
                }else
                {
                    continuar = false;
                }

                ListaFactura.Add(WhileFactura);


            }

            int total = 0;

            foreach (var EachTotal in ListaFactura)
            {
                total = total + (EachTotal.Alimento.Precio * EachTotal.Cantidad);
            }

            Console.WriteLine("Su total es" + total);
            Console.ReadKey();

            int devuelta = total - Client.Capital;
            if (total <= Client.Capital)
            {
                Console.WriteLine("Gracias por su compra su cambio es de " + devuelta);
            }
            else
            {
                Console.WriteLine("Usted no posee los suficientes fondos para realizar esta compra");
            }

            Console.ReadKey();
        }

        

    }   

      
   public class alimento
    {

        public string Nombre { get; set; }
        public int Precio  { get; set; }
        public int ID { get; set; }
    }

    public class cliente
    {
        public string Nombre { get; set; }
        public int Capital { get; set; }
    }

    public class Factura
    {
        public alimento Alimento { get; set; }
        public int Cantidad { get; set; }
    }
}
