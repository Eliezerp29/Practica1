using System;
using System.Collections;
using System.Collections.Generic;
using Ventorillo.Clases;

namespace Ventorillo
{
    class Program
    {

        /*
         Los criterios de aceptación de la práctica son los siguientes:
1- Se debe crear un catálogo de productos con su nombre y precio
2- Se debe capturar el nombre y el capital que posee el cliente
3- Se debe capturar los producto que quiere el cliente y la cantidad.
4- Se debe preguntar si quiere comprar otro producto, mientras la respuesta sea afirmativa debe repetirse el punto 3 de esta práctica y en caso contrario debe imprimir el detalle de la compra; la misma debe contener el nombre del cliente, su capital y el detalle de productos adquiridos con el total del valor de la compra.
5- Debe imprimir un mensaje debajo del detalle del punto 4 mencionando si el cliente puede proceder la compra o no dependiendo de el capital del mismo.
             
             */
        static void Main(string[] args)
        {

            List<Productos> listaProductos = new List<Productos>();
            


            Console.Write("Cuantos productos desea introducir en el catalogo? ");
            int cantidadProductos = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= cantidadProductos; i++)
            {
                Productos product = new Productos();

                Console.WriteLine("Introduzca el nombre del producto #" + i + "  ");
                product.Nombre = Console.ReadLine();

                Console.WriteLine("Introduzca el precio del producto #" + i + "  ");
                product.Precio = Convert.ToInt32(Console.ReadLine());
                listaProductos.Add(product);
            }

            foreach (var producto in listaProductos)
            {
                Console.WriteLine(producto.Nombre + " cuesta " + producto.Precio);
            }
            Console.ReadKey();
        }
  
    }
   
}
