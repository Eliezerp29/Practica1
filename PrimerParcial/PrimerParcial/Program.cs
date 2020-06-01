using System;
using System.Collections.Generic;
using PrimerParcial.Context;
namespace PrimerParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora Impuesto Sobre la Renta");
            var conexionNomina = new Conexion<Nomina>();
            var conexionExcluyentes = new Conexion<Excluyentes>();
            var conexionRango1 = new Conexion<Rango1>();
            var conexionRango2 = new Conexion<Rango2>();
            var conexionRango3 = new Conexion<Rango3>();

            bool continuar = true;
            string respuesta;

            for (bool i = true; i == continuar;)
            {
                Nomina ListaN = new Nomina();
                Console.WriteLine("Inserte el nombre del empleado");
                ListaN.Nombre = Console.ReadLine();
                Console.WriteLine("Inserte los Apellidos del empleado");
                ListaN.Apellido = Console.ReadLine();
                Console.WriteLine("Inserte el Sueldo Neto del empleado");
                ListaN.SueldoBruto = Convert.ToDecimal(Console.ReadLine());

                conexionNomina.Create(ListaN);

                Console.WriteLine("Desea Agregar otro empleado (S/N)");
                respuesta = Console.ReadLine();
                respuesta = respuesta.ToUpper();

                if (respuesta == "S")
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;
                }



                if ((ListaN.SueldoBruto *12) <= 416220)
                {

                    Excluyentes ForExclu = new Excluyentes();

                    ForExclu.Nombre = ListaN.Nombre;
                    ForExclu.Apellido = ListaN.Apellido;
                    ForExclu.SueldoBruto = ListaN.SueldoBruto;

                    ForExclu.Afp = ForExclu.SueldoBruto * (decimal)2.87 / 100;

                    ForExclu.Ars = ForExclu.SueldoBruto * (decimal)3.04 / 100;
                    ForExclu.Sip = ForExclu.SueldoBruto - (ForExclu.Afp + ForExclu.Ars);
                    ForExclu.Irs = 0;
                    ForExclu.TotalRetencion = ForExclu.Irs + ForExclu.Ars + ForExclu.Afp;
                    ForExclu.SueldoNeto = ForExclu.SueldoBruto - ForExclu.TotalRetencion;

                    conexionExcluyentes.Create(ForExclu);
                } 
                else if ((ListaN.SueldoBruto*12) >= 416221 && (ListaN.SueldoBruto*12) <= 624329)
                {
                    Rango1 Forrango1 = new Rango1();

                    Forrango1.Nombre = ListaN.Nombre;
                    Forrango1.Apellido = ListaN.Apellido;
                    Forrango1.SueldoBruto = ListaN.SueldoBruto;

                    Forrango1.Afp = Forrango1.SueldoBruto * (decimal)2.87 / 100;
                    Forrango1.Ars = Forrango1.SueldoBruto * (decimal)3.04 / 100;
                    Forrango1.Sip = Forrango1.SueldoBruto - (Forrango1.Afp + Forrango1.Ars);
                    Forrango1.Irs = (Forrango1.SueldoBruto * 12 - 416220);
                    Forrango1.Irs = Forrango1.Irs / 12 * (decimal)0.15;
                    Forrango1.TotalRetencion = Forrango1.Irs + Forrango1.Ars + Forrango1.Afp;
                    Forrango1.SueldoNeto = Forrango1.SueldoBruto - Forrango1.TotalRetencion;

                    conexionRango1.Create(Forrango1);
                }       
                else if (ListaN.SueldoBruto*12 >= 624330 && ListaN.SueldoBruto*12 <= 867123)
                {
                    Rango2 Forrango2 = new Rango2();

                    Forrango2.Nombre = ListaN.Nombre;
                    Forrango2.Apellido = ListaN.Apellido;
                    Forrango2.SueldoBruto = ListaN.SueldoBruto;

                    Forrango2.Afp = Forrango2.SueldoBruto * (decimal) 2.87 / 100;
                    Forrango2.Ars = Forrango2.SueldoBruto * (decimal)3.04 / 100;
                    Forrango2.Sip = Forrango2.SueldoBruto - (Forrango2.Afp + Forrango2.Ars);
                    Forrango2.Irs = (Forrango2.SueldoBruto * 12 - 624329);
                    Forrango2.Irs = Forrango2.Irs / 12 * (decimal) 0.20;
                    Forrango2.TotalRetencion = Forrango2.Irs + Forrango2.Ars + Forrango2.Afp;
                    Forrango2.SueldoNeto = Forrango2.SueldoBruto - Forrango2.TotalRetencion;

                    conexionRango2.Create(Forrango2);
                }
                else if (ListaN.SueldoBruto * 12 >= 867124 )
                {
                    Rango3 Forrango3 = new Rango3();

                    Forrango3.Nombre = ListaN.Nombre;
                    Forrango3.Apellido = ListaN.Apellido;
                    Forrango3.SueldoBruto = ListaN.SueldoBruto;

                    Forrango3.Afp = Forrango3.SueldoBruto * (decimal)2.87 / 100;
                    Forrango3.Ars = Forrango3.SueldoBruto * (decimal)3.04 / 100;
                    Forrango3.Sip = Forrango3.SueldoBruto - (Forrango3.Afp + Forrango3.Ars);
                    Forrango3.Irs = (Forrango3.SueldoBruto * 12 - 867123);
                    Forrango3.Irs = Forrango3.Irs / 12 * (decimal)0.25;
                    Forrango3.TotalRetencion = Forrango3.Irs + Forrango3.Ars + Forrango3.Afp;
                    Forrango3.SueldoNeto = Forrango3.SueldoBruto - Forrango3.TotalRetencion;

                    conexionRango3.Create(Forrango3);
                }

            }Console.Clear();

                    {
                        foreach (var Impri in conexionExcluyentes.GetAll())

                        {
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("--------------------------------------------Lista Excluyentes-------------------------------------------------------------------------");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                                                                                                                      ");
                    Console.WriteLine("                                                                                                                                      ");
                    Console.WriteLine("     Nombre     " + "     Apellido     " + "     Sueldo Bruto     " +   "     AFP     "    +   "     ARS     "   +   "     SIP     "   +   "     ISR     " + "     TOTALR     " + "     NETO     ");

                    Console.WriteLine("     "+Impri.Nombre + "         " + Impri.Apellido + "                " + Impri.SueldoBruto + "            " + Impri.Afp +"          " + Impri.Ars + "        " + Impri.Sip + "            " + Impri.Irs +"           " + Impri.TotalRetencion+"          " + Impri.SueldoNeto+"                   "
                                );
                        }

                        foreach (var Impri in conexionRango1.GetAll())
                        {
                    Console.WriteLine("****--------------------------------------------------------------------------------------------------------------------------------------****");
                    Console.WriteLine("****--------------------------------------------Lista Rango 15%---------------------------------------------------------------------------****");
                    Console.WriteLine("****--------------------------------------------------------------------------------------------------------------------------------------****");
                    Console.WriteLine("                                                                                                                                      ");
                    Console.WriteLine("                                                                                                                                      ");
                    Console.WriteLine("     Nombre     " + "     Apellido     " + "     Sueldo Bruto     " + "     AFP     " + "     ARS     " + "     SIP     " + "     ISR     " + "     TOTALR     " + "     NETO     ");

                    Console.WriteLine("     " + Impri.Nombre + "         " + Impri.Apellido + "                " + Impri.SueldoBruto + "            " + Impri.Afp + "          " + Impri.Ars + "        " + Impri.Sip + "            " + Impri.Irs + "           " + Impri.TotalRetencion + "          " + Impri.SueldoNeto + "                   "
                                );
                }

                        foreach (var Impri in conexionRango2.GetAll())
                        {
                    Console.WriteLine("****--------------------------------------------------------------------------------------------------------------------------------------****");
                    Console.WriteLine("****--------------------------------------------Lista Rango 20%---------------------------------------------------------------------------****");
                    Console.WriteLine("****--------------------------------------------------------------------------------------------------------------------------------------****");
                    Console.WriteLine("                                                                                                                                      ");
                    Console.WriteLine("                                                                                                                                      ");
                    Console.WriteLine("     Nombre     " + "     Apellido     " + "     Sueldo Bruto     " + "     AFP     " + "     ARS     " + "     SIP     " + "     ISR     " + "     TOTALR     " + "     NETO     ");

                    Console.WriteLine("     " + Impri.Nombre + "         " + Impri.Apellido + "                " + Impri.SueldoBruto + "            " + Impri.Afp + "          " + Impri.Ars + "        " + Impri.Sip + "            " + Impri.Irs + "           " + Impri.TotalRetencion + "          " + Impri.SueldoNeto + "                   "
                                );
                }

                        foreach (var Impri in conexionRango3.GetAll())
                        {
                    Console.WriteLine("****--------------------------------------------------------------------------------------------------------------------------------------****");
                    Console.WriteLine("****--------------------------------------------Lista Rango 30%---------------------------------------------------------------------------****");
                    Console.WriteLine("****--------------------------------------------------------------------------------------------------------------------------------------*****");
                    Console.WriteLine("                                                                                                                                      ");
                    Console.WriteLine("                                                                                                                                      ");
                    Console.WriteLine("     Nombre     " + "     Apellido     " + "     Sueldo Bruto     " + "     AFP     " + "     ARS     " + "     SIP     " + "     ISR     " + "     TOTALR     " + "     NETO     ");

                    Console.WriteLine("     " + Impri.Nombre + "         " + Impri.Apellido + "                " + Impri.SueldoBruto + "            " + Impri.Afp + "          " + Impri.Ars + "        " + Impri.Sip + "            " + Impri.Irs + "           " + Impri.TotalRetencion + "          " + Impri.SueldoNeto + "                   "
                                );
                }
                    }

  

            }
            

        }

}
