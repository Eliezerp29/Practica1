using System;

namespace PreExamen
{
    class Program
    {
        static void Main(string[] args)


        {
            for (int z = 1; z <= 2; z++)
            {
                Menu m = new Menu();
                Console.WriteLine("Digite el Tipo");
                m.SetTipos(Console.ReadLine());

                Console.WriteLine("El nombre capturado es : " + m.GetTipos());

                for (int h = 1; h <= 2; h++)
                {
                    Menu c = new Menu();
                    Console.WriteLine("Digite el codigo");
                    c.SetID(Console.ReadLine());

                    Console.WriteLine("El ID capturado es :" + c.GetID());

                    Console.WriteLine("El Tipo caputurado es" + m.GetTipos() , "El ID capturado es" + c.GetID());

                }
            }

        }
    }


    class Menu
    {
        private String Tipos;

        public void SetTipos(string t)

        {
            Tipos = t;

        }

        public string GetTipos()
        {
            return Tipos;
        }

        private String ID;

        public void SetID(string c)

        {
            ID = c;
        }

        public string GetID ()

            {
            return ID;
            }
    }






}
