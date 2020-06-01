using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ParcialDb
{
    class Program
    {

        static string connectionString = "Data Source=DESKTOP-NCA9IOOSQLEXPRESS;Database=Visual;integrated security = true";
        static void printLine(string text)
        {
            Console.WriteLine(text);
        }
        static void print(string text)
        {
            Console.Write(text);
        }
        static void Main(string[] args)
        {
            bool noSalir = true;

            while (noSalir)
            {
                Console.Clear();
                printLine("Qué desea realizar?\n1  Consultar.\n2  Registrar.");
                print("Digite la opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        {
                            printLine("");
                            consultarEmpleados();
                        }
                        break;
                    case "2":
                        {
                            printLine("");
                            print("Digite el nombre: ");
                            string nombre = Console.ReadLine();
                            print("Digite el Apellido: ");
                            string apellido = Console.ReadLine();
                            print("Digite el sexo (H, M): ");
                            string sexo = Console.ReadLine();
                            insertarEmpleado(nombre, apellido, sexo);
                        }
                        break;
                    default:
                        {
                            printLine("\nFavor digitar una de las opciones listadas.\n");
                            continue;
                        }
                }

                print("\nPara salir s: ");
                noSalir = (Console.ReadLine() == "s") ? false : true;
                printLine("");
            }




        }
        static public void insertarEmpleado(string nombre, string apellido, string sexo)
        {
            //INSERT INTO NombreTabla({Columna 1}, {Columna 2}) VALUES({Valor 1}, {Valor 2})
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                string query = "INSERT INTO Empleado(Nombre, Apellido, Sexo, FechaRegistro, Estatus)VALUES(@Nombre, @Apellido, @Sexo, GETDATE(), 'A')";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Sexo", sexo);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                printLine("\nEmpleado Registrado.");
            }
            catch (Exception e)
            {
                printLine(e.Message);
            }
        }
        static public void consultarEmpleados()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                string query = "SELECT * FROM Empleado";

                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    printLine(
                            "EmpleadoId: " + reader["EmpleadoId"].ToString() + "\n"
                            + "Nombre: " + reader["Nombre"].ToString() + "\n"
                            + "Apellido: " + reader["Apellido"].ToString() + "\n"
                            + "Sexo: " + ((reader["Sexo"].ToString().ToUpper() == "H") ? "Hombre" : "Mujer") + "\n"
                            + "Estado: " + ((reader["Estatus"].ToString().ToUpper() == "A") ? "Activo" : "Inactivo") + "\n"
                        );
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                printLine(e.Message);
            }

        }

    }  }
