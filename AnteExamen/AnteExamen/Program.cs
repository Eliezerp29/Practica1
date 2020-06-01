using System;
using System.Collections.Generic;
using System.Linq;
namespace AnteExamen
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
            List<catalogo> ListaCatalogo = new List<catalogo> ();

            Console.WriteLine("------------------------");
            Console.WriteLine("----- Bodega Eliezer----");
            Console.WriteLine("------------------------");

            Console.WriteLine(" Cuantos productos desea ? ");
            int cantidad = Convert.ToInt32 (Console.ReadLine());

            for (int i = 1; i <= cantidad; i++)
            {
                catalogo Catalogo = new catalogo();
                Catalogo.ID = i;

                Console.WriteLine("Digite el producto que desea");
                Catalogo.Nombre = (Console.ReadLine());
                  Console.WriteLine("Digite el precio del producto");
                Catalogo.Precio = Convert.ToInt32(Console.ReadLine());
               ListaCatalogo.Add(Catalogo);

               
            }



            cliente Cliente = new cliente(); 
            Console.WriteLine("inserte su nombre");
            Cliente.Nombre = Console.ReadLine();
            Console.WriteLine("inserte su capital");
            Cliente.Capital = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            

            List<detalle> NewList = new List<detalle>();
            bool continuar = true;
            while (continuar == true)
            {

                Console.WriteLine("------------------------");
                Console.WriteLine("------ Productos--------");
                Console.WriteLine("------------------------");
                detalle detail = new detalle();
                foreach (var listi in ListaCatalogo)
                {

                    Console.WriteLine(listi.ID + " Producto : " + listi.Nombre + " $ " + listi.Precio);
                }

                Console.WriteLine(" Que producto desea ");
                int Idproducto = Convert.ToInt32(Console.ReadLine());

                foreach (var catalogo in ListaCatalogo)
                {
                    if (catalogo.ID == Idproducto)
                    {

                        detail.Alimento = catalogo;

                    }
                }

                Console.WriteLine("Cuantos Desea?");
                detail.cantidad = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(" Desea continuar comprando ? ");
                string respuesta = Console.ReadLine();

                respuesta = respuesta.ToUpper();

                if (respuesta == "SI")
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;
                }

                NewList.Add(detail);
                Console.Clear();
            }
                int total = 0;

                foreach (var detalle in NewList)
                {
                    total = total + (detalle.Alimento.Precio * detalle.cantidad);

                }

                Console.WriteLine(Cliente.Nombre + " Su capital es de $ " + Cliente.Capital);

 

                foreach (var todo in NewList)
                {
                    Console.WriteLine( " A Pagar " + todo.cantidad + " " + todo.Alimento.Nombre + ":  Monto a Pagar  $" + todo.Alimento.Precio);
                }

                Console.WriteLine("Total a Pagar $" + total);

                if (total >= Cliente.Capital)
                {
                    Console.WriteLine(" Lo sentimos pero su capital es de " + Cliente.Capital + " Y el total acumulado entre sus comrpas es de  " + total);
                }
                else
                {
                    
                    Console.WriteLine("Gracias por su compra");

                }

                Console.ReadKey();







            
            
            

           
            
        }

        

    }

    public class catalogo
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int ID { get; set; }

    }

    public class cliente
    {
        public string Nombre{ get; set; }
        public int Capital { get; set; }
    }

    public class detalle

    {
        public catalogo Alimento { get; set; }
        public int cantidad { get; set; }


    }
}
