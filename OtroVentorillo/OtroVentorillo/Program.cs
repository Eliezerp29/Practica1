using System;
using System.Collections.Generic;
using System.Linq;


namespace OtroVentorillo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Alimento> ListaAlimentos = new List<Alimento>();
            //Punto 1

            //Guardar la cantidad de productos
            Console.WriteLine("Que cantidad de productos desea guardar");
            int Cantidad = Convert.ToInt32 (Console.ReadLine());
            
            //Grabar producto por producto
            for (int i = 1; i <= Cantidad; i++)
            {
                Alimento alimento = new Alimento();

                alimento.ID = i;
                Console.WriteLine("Que Alimento Desea Agregar");
                alimento.Nombre = Console.ReadLine();
                
                Console.WriteLine("Que Precio Desea Agregar");
                alimento.Precio = Convert.ToInt32 (Console.ReadLine());
                
                ListaAlimentos.Add(alimento);

            }
            Console.Clear();
            //Punto 2

            //Insertar datos del cliente
            Cliente cliente = new Cliente();
            Console.WriteLine("Inserte su Nombre");
            cliente.Nombre = Console.ReadLine();

            Console.WriteLine("Cuanto Dinero Posee");
            cliente.Capital = Convert.ToInt32(Console.ReadLine());
            Console.Clear();


            //Punto 3


            List<Factura> ListaDatos = new List<Factura>();
            bool continuar = true;

            while (continuar == true)
            {
                Factura dato = new Factura();

                //Mostrar lista de prodcutos 
                foreach (var ali in ListaAlimentos)
                {
                    Console.WriteLine(ali.ID + "- " + ali.Nombre + " $" + ali.Precio);
                }

                //Capturar id del producto que el cliente elija
                Console.WriteLine("Que producto desea?");
                int IDproducto = Convert.ToInt32(Console.ReadLine());

                //Buscar el alimento segun su ID
                foreach (var ali in ListaAlimentos)
                {
                    if (ali.ID == IDproducto)
                    {
                        dato.alimento = ali;
                    }
                }

                //Capturar cantidad de productos que va a comprar
                Console.WriteLine("Cuantos desea? ");
                dato.cantidad = Convert.ToInt32(Console.ReadLine());

                //Ver si desea continuar
                Console.WriteLine("Desea continuar 'Si' o 'No'");
                string respuesta = Console.ReadLine();

                respuesta =  respuesta.ToUpper();

                if (respuesta == "SI") {
                    continuar = true;
                }
                else { 
                    continuar = false; 
                }
                ListaDatos.Add(dato);
                Console.Clear();
            }   

            int total = 0;
             //calcular total
            foreach (var factura in ListaDatos)
            {
                total = total + (factura.alimento.Precio * factura.cantidad);
            }

            //Mostrar todo los datos
            Console.WriteLine(cliente.Nombre + ", Su capital es " + cliente.Capital  );
            Console.WriteLine("Lista de productos comprados ");
            foreach (var todo in ListaDatos)
            {
                Console.WriteLine(todo.alimento.Nombre + " $ " + todo.alimento.Precio + " Cantidad " + todo.cantidad );

            }

            Console.WriteLine(" Su total es " + total);
                
            if (total <= cliente.Capital)
            {
                Console.WriteLine("Gracias Por Realizar su compra");
            }else
            {
                Console.WriteLine("Usted no posee los suficientes fondos");
            }

            



        }
    }

    public class Alimento
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
        public Alimento alimento { get; set; }
        public int cantidad { get; set; }

    }


}
