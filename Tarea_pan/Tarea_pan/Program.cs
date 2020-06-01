using System;

namespace Tarea_pan
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = true;
            while (salir) { 
            Console.Write("Cantidad de dinero: ");
            int dinero = int.Parse( Console.ReadLine());
            Console.Write("Cual es su producto p = pan, r = Refresco, b = botellon: ");
            char tipoproducto = Console.ReadLine().ToUpper()[0];
            string producto = "";
            switch(tipoproducto){
                case 'P': {
                        producto = "pan";
                    }break;
                case 'R':
                    {
                        producto = "Rrefresco";
                    }break;
                case 'B':
                    {
                        producto = "botellon";

                    }break;
            };
            Console.Write("Cantidad de productos: ");
            int cantidadProducto = int.Parse( Console.ReadLine());
            Console.Write("Precio del producto: ");
            Double precio = double.Parse( Console.ReadLine());


            double total = calculo(precio, cantidadProducto);
                if(dinero < total)
                {
                    Console.WriteLine("No tiene suficiente dinero");
                    Console.WriteLine("Quieres salir S/N: ");
                    salir = (Console.ReadLine().ToUpper()[0] == 'S') ? false : true;
                }
                else { 

            CUERPO(cantidadProducto ,producto,precio,total);


                Console.WriteLine("Quieres salir S/N: ");
                salir = (Console.ReadLine().ToUpper()[0] == 'S') ? false : true;
                }
            }
            
        }
        static void CUERPO(int CP, string producto, double PR, double total)
        {
            Console.WriteLine("A comprado la cantidad de " + CP + " de " + producto + " por el precio de " + PR + " y hace un total de " +
                total);

           
            

        }
        static double calculo(double precio, int cantidadProducto)
        {
            return precio * cantidadProducto;
        }
        }

    



}
