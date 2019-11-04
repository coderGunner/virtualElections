using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotacionesV1
{
    class Log
    {
        string usuario;
        string password;
        public void iniciar()
        {
            Console.WriteLine("***Seleccione un usuario para continuar***");
            Console.WriteLine("**         1.  Administrador            **");
            Console.WriteLine("**         2.  Votante                  **");
            Console.WriteLine("******************************************");
            Console.WriteLine("Presione Escape (ESC) para salir");
            string choose = Console.ReadLine();
            do
            {
                if (choose.Equals("1"))
                {
                    Console.WriteLine("");
                    administrador();
                }
                else if (choose.Equals("2"))
                {
                    votante();
                }
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);



        }
        public void administrador()
        {
            Console.WriteLine("Presione Escape (ESC) para salir");
            do
            {
                Console.Write("Usuario: ");
                usuario = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Password: ");
                password = Console.ReadLine();
                //validacion usuario
                if (usuario.Equals("admin"))
                {
                    //validacion de contrasenia
                    if (password.Equals("admin123"))
                    {
                        Console.WriteLine("***BIENVENDIDO ADMINISTRADOR***");
                        do
                        {
                            Console.Write("Desea Indicar el máximo de votos? y/n ");
                            string maxvotos = Console.ReadLine();
                            if (maxvotos.Equals("y"))
                            {
                                Console.Write("Escriba el valor: ");
                                Variables.maximovotos = Int32.Parse(Console.ReadLine());
                                funcionalidadesAdministrador();

                            }
                            else if (maxvotos.Equals("n"))
                            {
                                funcionalidadesAdministrador();
                            }
                        } while (Console.ReadKey().Key != ConsoleKey.Escape);






                    }
                    else
                    {
                        Console.WriteLine("El password no es correcto!, intentelo nuevamente");
                    }
                }
                else
                {
                    Console.WriteLine("El usuario no es correcto!, intentelo nuevemente");
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);




        }

        public void votante()
        {
            Console.WriteLine("***Seleccione un usuario para continuar***");

        }

        public void funcionalidadesAdministrador()
        {
            do
            {
                Console.WriteLine("*** FUNCIONES DEL ADMINISTRADOR DISPONIBLES***");
                Console.WriteLine("**         1.  Inicar Nueva Votacion        **");
                Console.WriteLine("**         2.  Cargar archivo votos         **");
                Console.WriteLine("**         3.  Cargar archivo votantes      **");
                Console.WriteLine("**********************************************");
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    iniciarVotacion();
                }
                else if (choose.Equals("2"))
                {

                }
                else if (choose.Equals("3"))
                {

                }
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);


        }

        public void iniciarVotacion() {
            string choose;
            Console.WriteLine("*** SELECCIONE LAS MODALIDADES A INICIAR   ***");
            Console.WriteLine("**    a. Presidente y Vicepresidente.       **");
            Console.WriteLine("**    b. Alcalde Municipal.                 **");
            Console.WriteLine("**    c. Diputados en listado nacional.     **");
            Console.WriteLine("**    d. Diputados en listado distrital.    **");
            Console.WriteLine("**    e. Diputados al PARLACEN.             **");
            Console.WriteLine("**    f. Regresar a menú principal          **");
            Console.WriteLine("**********************************************");
            do
            {
                choose = Console.ReadLine();
                if (choose.Equals("a"))
                {
                    Variables.modalidadesActivas[0] = 1;
                    Console.WriteLine("** Puede seleccionar otra modalidad regresar al menú...");
                }
                else if (choose.Equals("b"))
                {
                    Variables.modalidadesActivas[1] = 1;
                    Console.WriteLine("** Puede seleccionar otra modalidad regresar al menú...");
                }
                else if (choose.Equals("c"))
                {
                    Variables.modalidadesActivas[2] = 1;
                    Console.WriteLine("** Puede seleccionar otra modalidad regresar al menú...");
                }
                else if (choose.Equals("d"))
                {
                    Variables.modalidadesActivas[3] = 1;
                    Console.WriteLine("** Puede seleccionar otra modalidad regresar al menú...");
                }
                else if (choose.Equals("e"))
                {
                    Variables.modalidadesActivas[4] = 1;
                    Console.WriteLine("** Puede seleccionar otra modalidad regresar al menú...");
                }
                else if (choose.Equals("f"))
                {
                    return;
                }

            } while(1);


        }





    }
}
