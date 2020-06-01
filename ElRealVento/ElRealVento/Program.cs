using System;
using System.Collections.Generic;

namespace ElRealVento
{
    class Program

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
        static void Main(string[] args)
        {
            List<Producto> ListaProducto = new List<Producto>();
            

            

            Console.WriteLine("---------------------------");
            Console.WriteLine("Bodega Eliezer La Sensacion");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Inserte la cantidad de productos que desea");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= cantidad; i++)
            {
                Producto WhileProducto = new Producto();
                WhileProducto.ID = i;
                Console.WriteLine("----------------------------");
                Console.WriteLine("----------Bodega Eliel------");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Inserte el Nombre del producto");
                WhileProducto.Nombre = Console.ReadLine();
                Console.WriteLine("Inserte el Precio del Prducto");
                WhileProducto.Precio = Convert.ToInt32(Console.ReadLine());

                ListaProducto.Add(WhileProducto);

            }

            Console.Clear();

            Console.WriteLine("----------------------------");
            Console.WriteLine("---------Bodega Eliel-------");
            Console.WriteLine("---------------------------");
            Cliente Client = new Cliente();
            Console.WriteLine("Inserte el nombre del cliente");
            Client.Nombre = Console.ReadLine();
            Console.WriteLine("Inserte Su Capital");
            Client.Capital = Convert.ToInt32 (Console.ReadLine());


            List<Factura> ListaFactura = new List<Factura>();
            bool continuar = true;
            while (continuar==true)
            {

                Console.WriteLine("----------------------------");
                Console.WriteLine("---------Caja---------------");
                Console.WriteLine("---------------------------");
                Factura WhileFactura = new Factura();


                foreach (var EachAlimento in ListaProducto)
                {
                    Console.WriteLine(EachAlimento.ID + " " + EachAlimento.Nombre + "$" + EachAlimento.Precio);
                }


                Console.WriteLine("Seleccionar su producto Segun El ID ");
                int IDProducto = Convert.ToInt32( Console.ReadLine());

                foreach (var EachID in ListaProducto)
                {
                    if (EachID.ID == IDProducto)
                    {
                        WhileFactura.Alimento = EachID;

                    }
                }

                Console.WriteLine("Cuantos Productos Desea");
                WhileFactura.Cantidad = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Desea Seguir Comprando (Escriba Si o No)");
                string respuesta = Console.ReadLine();

                respuesta = respuesta.ToUpper();

                if (respuesta=="SI")
 
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;
                         
                }

                ListaFactura.Add(WhileFactura);







            }

            int total = 0;
            Console.WriteLine("----------------------------");
            Console.WriteLine("---------Bodega Eliel-------");
            Console.WriteLine("---------------------------");
            foreach (var EachFactura in ListaFactura)
            {
                total = total + (EachFactura.Cantidad * EachFactura.Alimento.Precio);
            }

            Console.WriteLine(Client.Nombre + " Su capital es de " + Client.Capital );
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Usted Tiene estos productos en precompra");
            Console.WriteLine("----------------------------------------");

            foreach (var Each3 in ListaFactura)
            {
                Console.WriteLine(Each3.Cantidad  + " Productos " + Each3.Alimento.Nombre + " $ " + Each3.Alimento.Precio  );
            }


            Console.WriteLine("El de total de su compra es "+ total);
            int devuelta = Client.Capital - total;
            if (total <= Client.Capital)
            {
                Console.WriteLine("Compra Realizada con exito Su cambio es de " + devuelta);
            }
            else
            {
                Console.WriteLine("Usted no contiene los suficientes fondos");
            }

            Console.ReadKey();
        }

    }

    public class Producto
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int ID { get; set; }

    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public int Capital { get; set; }
    }

    public class Factura
    {
        public Producto Alimento { get; set; }
        public int Cantidad { get; set; }
    }
}
