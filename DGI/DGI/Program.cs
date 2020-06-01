using System;
using System.Collections.Generic;

namespace DGI
/*
 
1- se debe crear un catalogo de salarios insertanfo sueldos hasta que el clienta no desee continuar
2-se debe capturar el nombre y la empresa del cliente y el salario
3-se debe calcular si el salario pasa de     se le descuenta un 5%
, si pasa de 30 se le descuenta un 10% y si pasa de 40 se le descuenta un 15%
4- debe imprimirse el sueldo del cliente y el dinero que le sera descontado en un mes
5- debe imprimirse el sueldo del cliente anual y sus descuentos anuales.

*/
{
    class Program
    {
        static void Main(string[] args)
        {
            List<catalago> ListaCatalogo = new List<catalago>();
          
            
            bool continuar = true;
            string respuesta;
            int contador = 0;
            for (bool i = true; i == continuar;)
            {
                contador = contador + 1;


                catalago WhileCatalogo = new catalago();
                Console.WriteLine("Inserte su Nombre");
                WhileCatalogo.NombreCliente = Console.ReadLine();
                Console.WriteLine("Inserte su empresa");
                WhileCatalogo.Empresa = Console.ReadLine();
                Console.WriteLine("Inserte su salario ");
                WhileCatalogo.Salarios =Convert.ToInt32( Console.ReadLine());
                Console.WriteLine("Desea Agregar otro salario?");
                respuesta = Console.ReadLine();
                respuesta = respuesta.ToUpper();
               

                

                if (respuesta == "SI")
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;
                }

                for (int suma = 1; suma <= contador ; suma++)
                {
                    WhileCatalogo.IDSalario = contador;
                }

                ListaCatalogo.Add(WhileCatalogo);

            }
            bool seguir = true;
            while (seguir == true)
            {


                foreach (var Imprimir in ListaCatalogo)
                {
                    Console.WriteLine("(" + Imprimir.IDSalario + ")" + "|" + Imprimir.NombreCliente + "|" + Imprimir.Empresa + "|" + Imprimir.Salarios);

                }

                
                Console.WriteLine("Inserte el Salario que Desea Calcular?");
                int IDCliente = Convert.ToInt32(Console.ReadLine());

                campo CatiWhile = new campo();
                foreach (var Each1 in ListaCatalogo)
                {
                    if (Each1.IDSalario == IDCliente)
                    {
                        CatiWhile.Nombre = Each1;
                        Console.WriteLine(Each1.NombreCliente + " | " + " Salario a calcular " + "|" + Each1.Salarios);
                        int division;

                        Console.Clear();
                        division = Each1.Salarios * 5 / 100;
                        if (Each1.Salarios > 0 && Each1.Salarios <= 4999)
                        {
                            Console.WriteLine("a Usted se le descontara el 5% decimal su salario");

                            Console.WriteLine("El Monto que se le descontara de su alario sera: " + division + "Pesos");
                            Console.WriteLine("Salario Real " + (Each1.Salarios - division));
                        }
                        else if (Each1.Salarios >= 5000 && Each1.Salarios <= 10000)
                        {
                            division = Each1.Salarios * 10 / 100;

                            Console.WriteLine("a Usted se le descontara el 10% decimal su salario");

                            Console.WriteLine("El Monto que se le descontara de su alario sera: " + division + "Pesos");
                            Console.WriteLine("Salario Real " + (Each1.Salarios - division));
                        }
                        else if (Each1.Salarios >= 10001 && Each1.Salarios <= 15000)
                        {
                            division = Each1.Salarios * 15 / 100;
                            Console.WriteLine("a Usted se le descontara el 15% decimal su salario");

                            Console.WriteLine("El Monto que se le descontara de su alario sera: " + division + "Pesos");
                            Console.WriteLine("Salario Real " + (Each1.Salarios - division));
                        }
                        else if (Each1.Salarios >= 15001 && Each1.Salarios <= 20000)
                        {
                            division = Each1.Salarios * 20 / 100;
                            Console.WriteLine("a Usted se le descontara el 20% decimal su salario");

                            Console.WriteLine("El Monto que se le descontara de su alario sera: " + division + "Pesos");
                            Console.WriteLine("Salario Real " + (Each1.Salarios - division));
                        }
                        else
                        {
                            Console.WriteLine("Usted gana demasiado cuarto socio");
                        }

                        

                        Console.WriteLine("Desea Calcular otro sueldo ? ");
                        string resp = Console.ReadLine();
                        resp = resp.ToUpper();

                        if (resp=="SI")
                        {
                            seguir = true;
                        }
                        else
                        {
                            seguir = false;
                        }
                    }


                }
                Console.ReadKey();

            }


        }

       public class catalago 
        {
            public int Salarios { get; set; }
            public int IDSalario { get; set; }
            public string NombreCliente { get; set; }
            public string Empresa { get; set; }
        }

        public class campo
        {
            public catalago Nombre { get; set; }
            public string Empresa { get; set; }
        }
    }
}
