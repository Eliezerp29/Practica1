using System;

namespace PracticaJueves
{
    class Frutas
    {
        static void Main(string[] args)
        {
            string NombreArticulo;
            int Costo;
            string NombreProveedor;
            int cantidad;
            int precio;
            int pago;


            Console.WriteLine("Ingrese el nombre de su proveedor");
            NombreProveedor = Console.ReadLine();
            Console.WriteLine("Eliga La fruta que desea");
            NombreArticulo = Console.ReadLine();
            Console.WriteLine("Cuantos productos quiere?");
            cantidad = int.Parse(Console.ReadLine());
            Console.WriteLine("Precio de los productos");
            precio = int.Parse(Console.ReadLine());
            Console.WriteLine("Con cuanto va a pagar?");
            pago = int.Parse(Console.ReadLine());


            Costo = cantidad * precio;

            Console.WriteLine(value: "Usted tiene{} su dinero no le da solo tiene {pago}");


        }

        public static float Frutis(float precio, float pago)
        {
            if (precio > pago)
                return precio;
           
            else
                return pago;
            



        }

    }
}
