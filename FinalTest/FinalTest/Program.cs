using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTest.Classes;

namespace FinalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conexiones a Base de datos
            var UsuarioConexion = new Conexion<Usuario>();
            var CorreosConexion = new Conexion<Correos>();

            bool Exit = false;
            do
            {
                //Menu Opciones 
                Escribir("ElielMail");
                Escribir("Menu");
                Escribir("1.Crear Usuario");
                Escribir("2.Modificar Usuario");
                Escribir("3.Iniciar Sesion");
                Escribir("4.Salir del programa");

                //Captura Respuesta
                int Res = Respuesta(Console.ReadLine());
                //Condicion Respuesta igual a Crear Usuario
                if (Res == (int)Menu.CrearUsuario)
                {
                    //Capturar datos del administrador
                    Escribir("Inserte El email Admin");
                    string adminEmail = Console.ReadLine();
                    Escribir("Inserte el Pass del admin");
                    String AdminPass = Console.ReadLine();

                    //Validar crendeciales del administrador, y si es tipo administrador
                    Usuario Admin = UsuarioConexion.GetByCondition(user => 
                    user.Correo.ToLower() == adminEmail.ToLower()
                    && user.Password == AdminPass 
                    && user.TipoUsuario == (int)TipoUsuario.Administrador).FirstOrDefault();

                    //Si el usuario admin existe
                    if (Admin != null)
                    {
                        bool EsCorreoExistente, repetir = false;

                        Usuario User = new Usuario();
                        Escribir("Inserte Su Nombre");
                        User.Nombre = Console.ReadLine();

                        do
                        {
                            Escribir("Inserte Su Nueva Direccion de Correo ");
                            User.Correo = Console.ReadLine();
                            //Valida si el correo existe en la base de datos
                            EsCorreoExistente = ExisteCorreo(User.Correo);

                            if (EsCorreoExistente == true)
                            {
                                Escribir("Correo ya existe, intente con otro");
                                repetir = true;
                            }
                            else
                            {
                                repetir = false;
                            }
                        } while (repetir == true);

                        Escribir("Inserte su Password");
                        User.Password = Console.ReadLine();
                        User.TipoUsuario = (int)TipoUsuario.Normal;

                        //Crear usuario en la base de datos
                        UsuarioConexion.Create(User);
                    }
                    //Si el usuario admin no existe
                    else
                    {
                        Escribir("Usuario Admin Invalido");
                    }
                }
                //Condicion Respuesta igual a Modificar Usuario
                else if (Res == (int)Menu.ModificarUsuario)
                {

                    //Capturar datos del administrador
                    Escribir("Inserte El email Admin");
                    string adminEmail = Console.ReadLine();
                    Escribir("Inserte el Pass del admin");
                    String AdminPass = Console.ReadLine();

                    //Validar crendeciales del administrador, y si es tipo administrador
                    Usuario Admin = UsuarioConexion.GetByCondition(user =>
                    user.Correo.ToLower() == adminEmail.ToLower()
                    && user.Password == AdminPass
                    && user.TipoUsuario == (int)TipoUsuario.Administrador).FirstOrDefault();

                    //Si en usuario del administrador existe
                    if (Admin != null)
                    {
                        Escribir("Escriba el correo del usuario a modificar");
                        string email = Console.ReadLine();

                        //Capturar datos de un usuario, segun su correo
                        Usuario User = UsuarioConexion.GetByCondition(u =>
                        u.Correo.ToLower() == email.ToLower()).FirstOrDefault();

                        //si los datos del usuario existen
                        if (User != null)
                        {
                            bool EsCorreoExistente, repetir = false;

                            Escribir("Inserte el nombre Nuevo");
                            User.Nombre = Console.ReadLine();

                            do
                            {
                                Escribir("Inserte el Nuevo correo  ");
                                User.Correo = Console.ReadLine();

                                //Validar si el correo existe en la base de datos
                                EsCorreoExistente = ExisteCorreo(User.Correo);

                                if (EsCorreoExistente == true)
                                {
                                    Escribir("Correo ya existe, intente con otro");
                                    repetir = true;
                                }
                                else
                                {
                                    repetir = false;
                                }
                            } while (repetir == true);

                            Escribir("Inserte el nuevo Password");
                            User.Password = Console.ReadLine();

                            //Actualizar usuario en la base de datos
                            UsuarioConexion.Update(User);
                        }
                        //Si el usuario no existe
                        else
                        {
                            Escribir("Usuario no existe");
                        }
                    }
                    else
                    //Si en usuario del administrador no existe
                    {
                        Escribir("Usuario Admin Invalido");

                    }
                }
                //Condicion Respuesta igual a Iniciar Sesion Usuario
                else if (Res == (int)Menu.IniciarSesion)
                {
                    //Capturar correo y clave
                    Escribir("Inserte correo");
                    string correo = Console.ReadLine();
                    Escribir("Inserte la clave");
                    string password = Console.ReadLine();

                    //Validar credenciales del usuario
                    Usuario User = UsuarioConexion.GetByCondition(user =>
                    user.Correo.ToLower() == correo.ToLower() &&
                    user.Password == password).FirstOrDefault();

                    //Si existe usuario con esas credenciales
                    if (User != null)
                    {
                        bool CerrarSesion = false;
                        do
                        {
                            //SubMenu despues de iniciar sesion
                            Console.Clear();
                            Escribir("Opciones");
                            Escribir("1.Enviar correo");
                            Escribir("2.Mostrar listado de correos");
                            Escribir("3.Cerrar sesion");

                            //Capturar respuesta
                            int res2 = Respuesta(Console.ReadLine());

                            //Si la respuesta due enviar correo
                            if (res2 == (int)SubMenu.EnviarCorreo)
                            {
                                //Crear un nuevo correo
                                Correos NewCorreo = new Correos();

                                //Isertar correo origen con usuario que inicio sesion
                                NewCorreo.FromCorreo = User.Correo;

                                //capturar el correo destino
                                Escribir("Inserte el correo destino");
                                string ToCorreo = Console.ReadLine();

                                //Validar si el correo destino existe en la base dedatos
                                 bool EsCorreoExistente = ExisteCorreo(ToCorreo);

                                //si el correo existe
                                if (EsCorreoExistente == true)
                                {
                                    //Capturar datos del correo
                                    NewCorreo.ToCorreo = ToCorreo;

                                    Escribir("Inserte en asunto del mensaje");
                                    NewCorreo.Asunto = Console.ReadLine();

                                    Escribir("Inserte el mensaje del correo");
                                    NewCorreo.Mensaje = Console.ReadLine();

                                    NewCorreo.Status = "Enviado";

                                    //Crear correo en base de datos
                                    CorreosConexion.Create(NewCorreo);
                                }
                                //si el correo no existe
                                else
                                {
                                    Escribir("El correo destino no existe, intente con otro correo");
                                    Console.ReadKey();
                                }
                            }
                            //Si la respuesta fue Mostrar correos
                            else if (res2 == (int)SubMenu.MostrarCorreos) 
                            {
                                bool salirDeCorreos = false;

                                do{
                                    //Menu para mostrar correos
                                    Console.Clear();
                                    Escribir("Opciones");
                                    Escribir("1.Leer Correos enviados");
                                    Escribir("2.Leer Correos recibidos");
                                    Escribir("3.Regresar");

                                    //Capturar respuesta
                                    int res3 = Respuesta(Console.ReadLine());

                                    //Si respuesta es igual a leer correos enviados
                                    if (res3 == (int)MenuMostrarCorreos.LeerCorreosEnviados) {

                                        //Obtener de la base de datos, la lista de correos enviados
                                        List<Correos> ListaCorreosEnviados = CorreosConexion.GetByCondition(c =>
                                        c.FromCorreo.ToLower() == User.Correo.ToLower());

                                        //utilizar metodo para mostrar la lista de correos
                                        MostrarListaDeCorreos(ListaCorreosEnviados);
                                    }
                                    //Si la respuesta es igual a leer correos recibidos
                                    else if (res3 == (int)MenuMostrarCorreos.LeerCorreosRecibidos) 
                                    {
                                        //Obtener de la base de datos, la lista de correos recibidos
                                        List<Correos> ListaCorreosRecibidos = CorreosConexion.GetByCondition(c =>
                                        c.ToCorreo.ToLower() == User.Correo.ToLower());

                                        //Marcar correos como recibidos, ya que se van a leer
                                        foreach (var Email in ListaCorreosRecibidos)
                                        {
                                            Email.Status = "Recibido";
                                        }

                                        //utilizar metodo para mostrar la lista de correos
                                        MostrarListaDeCorreos(ListaCorreosRecibidos);

                                    }
                                    //Regresar al menu de despues de iniciar sesion
                                    else if (res3 == (int)MenuMostrarCorreos.Regresar) 
                                    {
                                        salirDeCorreos = true;
                                    }
                                    //No se selecciono una opcon correcta en el menu
                                    else {
                                        Escribir("Eligio una opcion incorrecta, favor eligir una opcion del menu");
                                        Console.ReadKey();
                                    }
                                } while (salirDeCorreos == false);
                            }
                            //Si la opcion fue cerrar sesion
                            else if (res2 == (int)SubMenu.CerrarSesion)
                            {
                                CerrarSesion = true;
                            }
                            //Si no se eligio una opcion valida 
                            else {
                                Escribir("Eligio una opcion incorrecta, favor eligir una opcion del menu");
                                Console.ReadKey();
                            }
                        } while (CerrarSesion == false);
                    }
                    //Si no existe usuario con esas credenciales
                    else
                    {
                        Escribir("Correo o clave invalida, intentar nuevamente");
                    }
                }
                //Condicion Respuesta Cerrar programa
                else if (Res == (int)Menu.Salir)
                {
                    Exit = true;
                    Escribir("Cerrando ElielMail");
                }
                //De lo contrario, no selecciono una opcion valida
                else
                {
                    Escribir("Eligio una opcion incorrecta, favor eligir una opcion del menu");
                }
                Console.ReadKey();
                Console.Clear();
            } while (Exit == false);
        }

        //Metodo para escribir en consola
        private static void Escribir(string texto) => Console.WriteLine(texto);

        //Metodo para validar si un correo existe
        private static bool ExisteCorreo(string correo)
        {
            var UsuarioConeccion = new Conexion<Usuario>();

            return UsuarioConeccion.GetAll().Any(user => user.Correo.ToLower() == correo.ToLower());
        }

        //Metodo para el despliegue de los correos
        public static void MostrarListaDeCorreos(List<Correos> listaCorreos) 
        {
            if (listaCorreos.Count == 0)
                Escribir("No hay correos disponibles");
            foreach (var correo in listaCorreos)
            {
                Escribir("From: " + correo.FromCorreo);
                Escribir("To: " + correo.ToCorreo);
                Escribir("Asunto : " + correo.Asunto);
                Escribir("Mensaje : " + correo.Mensaje);
                Escribir("Status : " + correo.Status);

                Escribir("");
                Escribir("Precione una tecla para continuar");
            }
            Console.ReadKey();
        }

        //Deveolver respuesta en numero, devuelve 0 si da error
        private static int Respuesta(string res) {
            int numero;
            bool success = Int32.TryParse(res, out numero);
            if (success)
            {
                return numero;
            }
            return 0;
        }
    }

    //Enumeracion de Menu = (int)
    public enum Menu
    {
        CrearUsuario = 1,
        ModificarUsuario = 2,
        IniciarSesion = 3,
        Salir = 4
    }
    //Enumeracion de menu despues de iniciar sesion
    public enum SubMenu
    {
        EnviarCorreo = 1,
        MostrarCorreos = 2,
        CerrarSesion = 3
    }
    //Enumeracion de menu despues para ver correos
    public enum MenuMostrarCorreos
    {
        LeerCorreosEnviados = 1,
        LeerCorreosRecibidos = 2,
        Regresar = 3
    }


}
