using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotacionesV1
{
    class Log
    {
        string usuario;
        string password;
        bool exit;
        bool salida;
        public void iniciar()
        {
            exit = true;
            salida = true;
            do
            {
                Console.WriteLine("***Seleccione un usuario para continuar***");
                Console.WriteLine("**         1.  Administrador            **");
                Console.WriteLine("**         2.  Votante                  **");
                Console.WriteLine("**         3.  Salir                    **");
                Console.WriteLine("******************************************");
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    this.salida = exit = true;

                    Console.WriteLine("");
                    administrador();
                }
                else if (choose.Equals("2"))
                {
                    this.salida = exit = true;
                    votante();
                }
                else if (choose.Equals("3"))
                {
                    this.salida = false;
                }
            }
            while (this.salida);



        }
        public void administrador()
        {

            while (this.exit)
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
                    if (password.Equals(Variables.password))
                    {

                        do
                        {
                            Console.WriteLine("***BIENVENDIDO ADMINISTRADOR***");
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


                        } while (this.exit);

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

            }




        }

        public void votante()
        {
            bool ext = true;
            while (ext)
            {
                if (Variables.votantes.Count > 0 )
                {
                    bool inn = true;
                    Console.WriteLine("Se ha cargado un archivo de votantes validos!");
                    Console.Write("Escriba su CUI: ");
                    string cui = Console.ReadLine();
                    foreach (string d in Variables.votantes)
                    {
                        string dm = d.Trim();
                        if (dm.Equals(cui))
                        {
                            if (Variables.conteoVotosTotales < Variables.maximovotos)
                            {
                                iniciarvotacionVotante();
                                ext = false;
                                inn = false;
                            }
                            else
                            {
                                Console.WriteLine("Se llego al maximo de votos configurado por el administrador");
                            }

                        }
                    }
                    if (inn)
                    {
                        Console.WriteLine("No se ha encontrado su DPI en el documento, vuelva a intentar!");
                    }
                }//end if
                else {
                    Console.Write("Escriba su CUI: ");
                    string cui = Console.ReadLine();
                    if (cui.Length > 13 || cui.Length < 13)
                    {
                        Console.WriteLine("Su numero de CUI no es valido! intente de nuevo");
                    }
                    else
                    {

                        if (Variables.conteoVotosTotales < Variables.maximovotos)
                        {
                            iniciarvotacionVotante();
                            ext = false;
                        
                        }
                        else
                        {
                            Console.WriteLine("Se llego al maximo de votos configurado por el administrador");
                        }
                    }

                }

            }



        }

        public void iniciarvotacionVotante()
        {
            Votante vo = new Votante();
            bool outev = true;
            if (Variables.modalidadesActivas[0] == 1)
            {
                bool v = true;               
                while (v && outev)
                {
                    Console.WriteLine("Elecciones a Presidente y Viceprecidente");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("       1.  Amarillo            ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("       2.  Verde                  ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("       3.  Violeta                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("       4.  Rojo                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("       5.  Azul                    ");
                    Console.ResetColor();
                    Console.WriteLine("       6.  Nulo                    ");
                    Console.WriteLine("       7.  Salir");
                    string choose = Console.ReadLine();
                    if (choose.Equals("1"))
                    {
                        vo.addVoto("amarillo");
                        Variables.cantidadvotosAmarillo[0] += 1;
                        v = false;
                    }
                    else if (choose.Equals("2"))
                    {
                        vo.addVoto("verde");
                        Variables.cantidadvotosVerde[0] += 1;
                        v = false;
                    }
                    else if (choose.Equals("3"))
                    {
                        vo.addVoto("violeta");
                        Variables.cantidadvotosVioleta[0] += 1;
                        v = false;
                    }
                    else if (choose.Equals("4"))
                    {
                        vo.addVoto("rojo");
                        Variables.cantidadvotosRojo[0] += 1;
                        v = false;
                    }
                    else if (choose.Equals("5"))
                    {
                        vo.addVoto("azul");
                        Variables.cantidadvotosAzul[0] += 1;
                        v = false;
                    }
                    else if (choose.Equals("6"))
                    {
                        vo.addVoto("nulo");
                        v = false;
                    }
                    else if (choose.Equals("7"))
                    {
                        outev = false;
                    }

                }//end while
                
                
            }
            if (Variables.modalidadesActivas[1] == 1)
            {
                bool v = true;
                while (v && outev)
                {
                    Console.WriteLine("Eleccion de Alcalde Municipal");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("       1.  Amarillo            ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("       2.  Verde                  ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("       3.  Violeta                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("       4.  Rojo                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("       5.  Azul                    ");
                    Console.ResetColor();
                    Console.WriteLine("       6.  Nulo                    ");
                    Console.WriteLine("       7.  Salir");
                    string choose = Console.ReadLine();
                    if (choose.Equals("1"))
                    {
                        vo.addVoto("amarillo");
                        Variables.cantidadvotosAmarillo[1] += 1;
                        v = false;
                    }
                    else if (choose.Equals("2"))
                    {
                        vo.addVoto("verde");
                        Variables.cantidadvotosVerde[1] += 1;
                        v = false;
                    }
                    else if (choose.Equals("3"))
                    {
                        vo.addVoto("violeta");
                        Variables.cantidadvotosVioleta[1] += 1;
                        v = false;
                    }
                    else if (choose.Equals("4"))
                    {
                        vo.addVoto("rojo");
                        Variables.cantidadvotosRojo[1] += 1;
                        v = false;
                    }
                    else if (choose.Equals("5"))
                    {
                        vo.addVoto("azul");
                        Variables.cantidadvotosAzul[1] += 1;
                        v = false;
                    }
                    else if (choose.Equals("6"))
                    {
                        vo.addVoto("nulo");
                        v = false;
                    }
                    else if (choose.Equals("7"))
                    {
                        outev = false;
                    }

                }

            }
            if (Variables.modalidadesActivas[2] == 1)
            {
                bool v = true;
                while (v && outev)
                {
                    Console.WriteLine("Elecciones  para diputados en lista nacional");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("       1.  Amarillo            ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("       2.  Verde                  ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("       3.  Violeta                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("       4.  Rojo                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("       5.  Azul                    ");
                    Console.ResetColor();
                    Console.WriteLine("       6.  Nulo                    ");
                    Console.WriteLine("       7.  Salir");
                    string choose = Console.ReadLine();
                    if (choose.Equals("1"))
                    {
                        vo.addVoto("amarillo");
                        Variables.cantidadvotosAmarillo[2] += 1;
                        v = false;
                    }
                    else if (choose.Equals("2"))
                    {
                        vo.addVoto("verde");
                        Variables.cantidadvotosVerde[2] += 1;
                        v = false;
                    }
                    else if (choose.Equals("3"))
                    {
                        vo.addVoto("violeta");
                        Variables.cantidadvotosVioleta[2] += 1;
                        v = false;
                    }
                    else if (choose.Equals("4"))
                    {
                        vo.addVoto("rojo");
                        Variables.cantidadvotosRojo[2] += 1;
                        v = false;
                    }
                    else if (choose.Equals("5"))
                    {
                        vo.addVoto("azul");
                        Variables.cantidadvotosAzul[2] += 1;
                        v = false;
                    }
                    else if (choose.Equals("6"))
                    {
                        vo.addVoto("nulo");
                        v = false;
                    }

                    else if (choose.Equals("7"))
                    {
                        outev = false;
                    }

                }
            }
            if (Variables.modalidadesActivas[3] == 1)
            {
                bool v = true;
                while (v && outev)
                {
                    Console.WriteLine("Eleccion a diputados en listado distrital");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("       1.  Amarillo            ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("       2.  Verde                  ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("       3.  Violeta                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("       4.  Rojo                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("       5.  Azul                    ");
                    Console.ResetColor();
                    Console.WriteLine("       6.  Nulo                    ");
                    Console.WriteLine("       7.  Salir");
                    string choose = Console.ReadLine();
                    if (choose.Equals("1"))
                    {
                        vo.addVoto("amarillo");
                        Variables.cantidadvotosAmarillo[3] += 1;
                        v = false;
                    }
                    else if (choose.Equals("2"))
                    {
                        vo.addVoto("verde");
                        Variables.cantidadvotosVerde[3] += 1;
                        v = false;
                    }
                    else if (choose.Equals("3"))
                    {
                        vo.addVoto("violeta");
                        Variables.cantidadvotosVioleta[3] += 1;
                        v = false;
                    }
                    else if (choose.Equals("4"))
                    {
                        vo.addVoto("rojo");
                        Variables.cantidadvotosRojo[3] += 1;
                        v = false;
                    }
                    else if (choose.Equals("5"))
                    {
                        vo.addVoto("azul");
                        Variables.cantidadvotosAzul[3] += 1;
                        v = false;
                    }
                    else if (choose.Equals("6"))
                    {
                        vo.addVoto("nulo");
                        v = false;
                    }

                    else if (choose.Equals("7"))
                    {
                        outev = false;
                    }

                }

            }
            if (Variables.modalidadesActivas[4] == 1)
            {
                bool v = true;
                while (v && outev)
                {
                    Console.WriteLine("Elecciones para dipuatados del parlacen");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("       1.  Amarillo            ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("       2.  Verde                  ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("       3.  Violeta                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("       4.  Rojo                    ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("       5.  Azul                    ");
                    Console.ResetColor();
                    Console.WriteLine("       6.  Nulo                    ");
                    Console.WriteLine("       7.  Salir");
                    string choose = Console.ReadLine();
                    if (choose.Equals("1"))
                    {
                        vo.addVoto("amarillo");
                        Variables.cantidadvotosAmarillo[4] += 1;
                        v = false;
                    }
                    else if (choose.Equals("2"))
                    {
                        vo.addVoto("verde");
                        Variables.cantidadvotosVerde[4] += 1;
                        v = false;
                    }
                    else if (choose.Equals("3"))
                    {
                        vo.addVoto("violeta");
                        Variables.cantidadvotosVioleta[4] += 1;
                        v = false;
                    }
                    else if (choose.Equals("4"))
                    {
                        vo.addVoto("rojo");
                        Variables.cantidadvotosRojo[4] += 1;
                        v = false;
                    }
                    else if (choose.Equals("5"))
                    {
                        vo.addVoto("azul");
                        Variables.cantidadvotosAzul[4] += 1;
                        v = false;
                    }
                    else if (choose.Equals("6"))
                    {
                        vo.addVoto("nulo");
                        v = false;
                    }
                    else if (choose.Equals("7"))
                    {
                        outev = false;
                    }

                }
            }
            Console.WriteLine("HA FINALIZADO SU VOTACION!!!");
            if (outev) {
                Variables.votantes_v.Add(vo);
                Variables.conteoVotosTotales += 1;
            }
           
        }
        public void funcionalidadesAdministrador()
        {

            while (exit)
            {
                Console.WriteLine("***     FUNCIONES DEL ADMINISTRADOR DISPONIBLES        ***");
                Console.WriteLine("**         1.  Inicar Nueva Votacion                    **");
                Console.WriteLine("**         2.  Cargar archivo votos                     **");
                Console.WriteLine("**         3.  Cargar archivo votantes                  **");
                Console.WriteLine("**         4.  Mostrar Ganador Parcial                  **");
                Console.WriteLine("**         5.  Mostrar distribucion grafica de congreso **");
                Console.WriteLine("**         6.  Mostrar Reporte Grafico                  **");
                Console.WriteLine("**         7.  Auditar                                  **");
                Console.WriteLine("**         8.  Anular Elecciones                        **");
                Console.WriteLine("**         9.  Reporte de elecciones                    **");
                Console.WriteLine("**         10. Salir                                    **");
                Console.WriteLine("**********************************************************");
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    iniciarVotacion();
                }
                else if (choose.Equals("2"))
                {
                    cargarArchivoVotos();
                }
                else if (choose.Equals("3"))
                {
                    cargarArchivoVotantes();
                }
                else if (choose.Equals("4"))
                {
                    mostrarGanadorParcial();
                }
                else if (choose.Equals("5"))
                {

                }
                else if (choose.Equals("6"))
                {

                }
                else if (choose.Equals("7"))
                {
                    auditar();
                }
                else if (choose.Equals("8"))
                {
                    anularElecciones();
                }
                else if (choose.Equals("9"))
                {
                    reporteEleccion();
                }
                else if (choose.Equals("10"))
                {
                    this.exit = false;
                }

            }

     


        }

        public void reporteEleccion()
        {
            bool e = true;
            while (e)
            {
                Console.WriteLine("***        ESCOJA LA MODALIDAD A REPORTAR              ***");
                Console.WriteLine("**         1.  Presidente y Vicepresidente              **");
                Console.WriteLine("**         2.  Alcalde Municipal                        **");
                Console.WriteLine("**         3.  Diputados en Lista Nacional              **");
                Console.WriteLine("**         4.  Diputados en lista Distrital             **");
                Console.WriteLine("**         5.  Diputados al Parlacen                    **");
                Console.WriteLine("**         6. Salir                                     **");
                Console.WriteLine("**********************************************************");
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    graficarPartido(0);

                }
                else if (choose.Equals("2"))
                {
                    graficarPartido(1);
                }
                else if (choose.Equals("3"))
                {
                    graficarPartido(2);
                }
                else if (choose.Equals("4"))
                {
                    graficarPartido(3);
                }
                else if (choose.Equals("5"))
                {
                    graficarPartido(4);
                }
                else if (choose.Equals("6"))
                {
                    e = false;
                }
            }

            }

        public void graficarPartido(int m)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PARTIDO AMARILLO");
            Console.ResetColor();
            Console.Write("Cantidad de Votos:  ");
            Console.WriteLine(Variables.cantidadvotosAmarillo[m]);
            double porcentaje = (double)Variables.cantidadvotosAmarillo[m] / (double)Variables.conteoVotosTotales;
            Console.WriteLine("Porcentaje de votos: ");

            for (int i = 0; i < Variables.cantidadvotosAmarillo[m]; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("#");
            }
            Console.WriteLine(" " + porcentaje.ToString("P", CultureInfo.InvariantCulture));
            Console.ResetColor();
            // partido verde
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PARTIDO VERDE");
            Console.ResetColor();
            Console.Write("Cantidad de Votos:  ");
            Console.WriteLine(Variables.cantidadvotosVerde[m]);
            porcentaje = (double)Variables.cantidadvotosVerde[m] / (double)Variables.conteoVotosTotales;
            Console.WriteLine("Porcentaje de votos: ");

            for (int i = 0; i < Variables.cantidadvotosVerde[m]; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("#");
            }
            Console.WriteLine(" " + porcentaje.ToString("P", CultureInfo.InvariantCulture));
            Console.ResetColor();

            //partido VIOLETA
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("PARTIDO VIOLETA");
            Console.ResetColor();
            Console.Write("Cantidad de Votos:  ");
            Console.WriteLine(Variables.cantidadvotosVioleta[m]);
            porcentaje = (double)Variables.cantidadvotosVioleta[m] / (double)Variables.conteoVotosTotales;
            Console.WriteLine("Porcentaje de votos: ");

            for (int i = 0; i < Variables.cantidadvotosVioleta[m]; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("#");
            }
            Console.WriteLine(" " + porcentaje.ToString("P", CultureInfo.InvariantCulture));
            Console.ResetColor();

            //partido Rojo
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PARTIDO ROJO");
            Console.ResetColor();
            Console.Write("Cantidad de Votos:  ");
            Console.WriteLine(Variables.cantidadvotosRojo[m]);
            porcentaje = (double)Variables.cantidadvotosRojo[m] / (double)Variables.conteoVotosTotales;
            Console.WriteLine("Porcentaje de votos: ");

            for (int i = 0; i < Variables.cantidadvotosRojo[m]; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
            }
            Console.WriteLine(" " + porcentaje.ToString("P", CultureInfo.InvariantCulture));
            Console.ResetColor();

            //partido Azul
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("PARTIDO AZUL");
            Console.ResetColor();
            Console.Write("Cantidad de Votos:  ");
            Console.WriteLine(Variables.cantidadvotosAzul[m]);
            porcentaje = (double)Variables.cantidadvotosAzul[m] / (double)Variables.conteoVotosTotales;
            Console.WriteLine("Porcentaje de votos: ");

            for (int i = 0; i < Variables.cantidadvotosAzul[m]; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("#");
            }
            Console.WriteLine(" " + porcentaje.ToString("P", CultureInfo.InvariantCulture));
            Console.ResetColor();
            Console.WriteLine("Total de votos: " + Variables.conteoVotosTotales);


        }
        public void iniciarVotacion()
        {
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

            } while (true);


        }

        public void cargarArchivoVotos()
        {
            Console.Write("Escriba la ruta del archivo de votos: ");
            string path = Console.ReadLine();
            LeerVotos v = new LeerVotos(path);
            if (Variables.conteoVotosTotales <= Variables.maximovotos)
            {
                Console.WriteLine("!El Archivo fue cargado con exito! ");
            }
            else
            {
                Console.WriteLine("SE ALCANZO EL MAXIMO DE LOS VOTOS POSIBLES! ");
            }

        }

        public void cargarArchivoVotantes()
        {
            Console.Write("Escriba la ruta del archivo de votantes: ");
            string path = Console.ReadLine();
            LeerVotantes v = new LeerVotantes(path);
            Console.WriteLine("!El Archivo fue cargado con exito! ");
        }

        public void mostrarGanadorParcial()
        {
            bool t = true;
            while (t)
            {
                Console.WriteLine("*** SELECCIONE LAS MODALIDAD A CONSULTAR   ***");
                Console.WriteLine("**    a. Presidente y Vicepresidente.       **");
                Console.WriteLine("**    b. Alcalde Municipal.                 **");
                Console.WriteLine("**    c. Diputados en listado nacional.     **");
                Console.WriteLine("**    d. Diputados en listado distrital.    **");
                Console.WriteLine("**    e. Diputados al PARLACEN.             **");
                Console.WriteLine("**    f. Regresar a menú principal          **");
                Console.WriteLine("**********************************************");
                string choose = Console.ReadLine();
                if (choose.Equals("a"))
                {
                    int[] votos = { Variables.cantidadvotosAmarillo[0], Variables.cantidadvotosAzul[0], Variables.cantidadvotosVioleta[0], Variables.cantidadvotosRojo[0], Variables.cantidadvotosVerde[0] };
                    int ganador = votos.Max();
                    int index = votos.ToList().IndexOf(ganador);
                    if (index == 0)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PRESIDENTE Y VICEPRESIDENTE ES EL PARTIDO AMARILLO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 1)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PRESIDENTE Y VICEPRESIDENTE ES EL PARTIDO AZUL CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 2)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PRESIDENTE Y VICEPRESIDENTE ES EL PARTIDO VIOLETA CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 3)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PRESIDENTE Y VICEPRESIDENTE ES EL PARTIDO ROJO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 4)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PRESIDENTE Y VICEPRESIDENTE ES EL PARTIDO VERDE CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
                else if (choose.Equals("b"))
                {
                    int[] votos = { Variables.cantidadvotosAmarillo[1], Variables.cantidadvotosAzul[1], Variables.cantidadvotosVioleta[1], Variables.cantidadvotosRojo[1], Variables.cantidadvotosVerde[1] };
                    int ganador = votos.Max();
                    int index = votos.ToList().IndexOf(ganador);
                    if (index == 0)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA ALCALDE ES EL PARTIDO AMARILLO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 1)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA ALCALDE ES EL PARTIDO AZUL CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 2)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA ALCALDE  ES EL PARTIDO VIOLETA CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 3)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA ALCALDE ES EL PARTIDO ROJO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 4)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA ALCALDE ES EL PARTIDO VERDE CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
                else if (choose.Equals("c"))
                {
                    int[] votos = { Variables.cantidadvotosAmarillo[2], Variables.cantidadvotosAzul[2], Variables.cantidadvotosVioleta[2], Variables.cantidadvotosRojo[2], Variables.cantidadvotosVerde[2] };
                    int ganador = votos.Max();
                    int index = votos.ToList().IndexOf(ganador);
                    if (index == 0)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTA NACIONAL ES EL PARTIDO AMARILLO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 1)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTA NACIONAL ES EL PARTIDO AZUL CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 2)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTA NACIONAL ES EL PARTIDO VIOLETA CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 3)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTA NACIONAL ES EL PARTIDO ROJO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 4)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTA NACIONAL ES EL PARTIDO VERDE CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
                else if (choose.Equals("d"))
                {
                    int[] votos = { Variables.cantidadvotosAmarillo[3], Variables.cantidadvotosAzul[3], Variables.cantidadvotosVioleta[3], Variables.cantidadvotosRojo[3], Variables.cantidadvotosVerde[3] };
                    int ganador = votos.Max();
                    int index = votos.ToList().IndexOf(ganador);
                    if (index == 0)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTADO DISTRITAL ES EL PARTIDO AMARILLO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 1)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTADO DISTRITAL ES EL PARTIDO AZUL CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 2)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTADO DISTRITAL ES EL PARTIDO VIOLETA CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 3)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA DIPUTADO LISTADO DISTRITAL ES EL PARTIDO ROJO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 4)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PRESIDENTE Y VICEPRESIDENTE ES EL PARTIDO VERDE CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
                else if (choose.Equals("e"))
                {
                    int[] votos = { Variables.cantidadvotosAmarillo[4], Variables.cantidadvotosAzul[4], Variables.cantidadvotosVioleta[4], Variables.cantidadvotosRojo[4], Variables.cantidadvotosVerde[4] };
                    int ganador = votos.Max();
                    int index = votos.ToList().IndexOf(ganador);
                    if (index == 0)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PARLACEN ES EL PARTIDO AMARILLO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 1)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PARLACEN ES EL PARTIDO AZUL CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 2)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PARLACEN ES EL PARTIDO VIOLETA CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 3)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PARLACEN ES EL PARTIDO ROJO CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    else if (index == 4)
                    {
                        Console.WriteLine("EL GANADOR PARCIAL PARA PARLACEN ES EL PARTIDO VERDE CON: " + ganador + " VOTOS");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
                else if (choose.Equals("f"))
                {
                    t = false;
                }

            }//end while


        }

        public void auditar()
        {
            Console.Write("Escriba la ruta del archivo para auditar: ");
            string path = Console.ReadLine();
            try
            {
                EscribirAuditoria ea = new EscribirAuditoria(path + ".csv");
                Console.WriteLine("!El Archivo fue escrito con exito! ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hubo un error al escribir el archivo!!!");
            }

        }

        public void anularElecciones()
        {
            Console.Write("Esta seguro que quiere cancelar las votaciones y/n: ");
            string anular = Console.ReadLine();
            if (anular.Equals("y"))
            {
                Console.Write("Password: ");
                string pass = Console.ReadLine();
                if (pass.Equals(Variables.password))
                {
                    int totalAmarillo = Variables.cantidadvotosAmarillo[0] + Variables.cantidadvotosAmarillo[1] + Variables.cantidadvotosAmarillo[2] + Variables.cantidadvotosAmarillo[3] + Variables.cantidadvotosAmarillo[4];
                    int totalVerde = Variables.cantidadvotosVerde[0] + Variables.cantidadvotosVerde[1] + Variables.cantidadvotosVerde[2] + Variables.cantidadvotosVerde[3] + Variables.cantidadvotosVerde[4];
                    int totalVioleta = Variables.cantidadvotosVioleta[0] + Variables.cantidadvotosVioleta[1] + Variables.cantidadvotosVioleta[2] + Variables.cantidadvotosVioleta[3] + Variables.cantidadvotosVioleta[4];
                    int totalRojo = Variables.cantidadvotosRojo[0] + Variables.cantidadvotosRojo[1] + Variables.cantidadvotosRojo[2] + Variables.cantidadvotosRojo[3] + Variables.cantidadvotosRojo[4];
                    int totalAzul = Variables.cantidadvotosAzul[0] + Variables.cantidadvotosAzul[1] + Variables.cantidadvotosAzul[2] + Variables.cantidadvotosAzul[3] + Variables.cantidadvotosAzul[4];

                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,25}|{5,18}|{6,15}|", "PARTIDO","PRESIDENTE", "ALCALDE", "DIPUTADO LISTA NACIONAL","DIPUTADO LISTA DISTRITAL", "DIPUTADOS PARLACEN", "TOTAL VOTOS"));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,25}|{5,18}|{6,15}|", "AMARILLO", Variables.cantidadvotosAmarillo[0] , Variables.cantidadvotosAmarillo[1], Variables.cantidadvotosAmarillo[2], Variables.cantidadvotosAmarillo[3], Variables.cantidadvotosAmarillo[4], totalAmarillo));
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,25}|{5,18}|{6,15}|", "VERDE", Variables.cantidadvotosVerde[0], Variables.cantidadvotosVerde[1], Variables.cantidadvotosVerde[2], Variables.cantidadvotosVerde[3], Variables.cantidadvotosVerde[4], totalVerde));
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,25}|{5,18}|{6,15}|", "VIOLETA", Variables.cantidadvotosVioleta[0], Variables.cantidadvotosVioleta[1], Variables.cantidadvotosVioleta[2], Variables.cantidadvotosVioleta[3], Variables.cantidadvotosVioleta[4], totalVioleta));
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,25}|{5,18}|{6,15}|", "ROJO", Variables.cantidadvotosRojo[0], Variables.cantidadvotosRojo[1], Variables.cantidadvotosRojo[2], Variables.cantidadvotosRojo[3], Variables.cantidadvotosRojo[4], totalRojo));
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,25}|{5,18}|{6,15}|", "AZUL", Variables.cantidadvotosAzul[0], Variables.cantidadvotosAzul[1], Variables.cantidadvotosAzul[2], Variables.cantidadvotosAzul[3], Variables.cantidadvotosAzul[4], totalAzul));
                    Console.ResetColor();
                    Console.Write("Presione Enter para continuar: ");
                    Console.ReadLine();
                    reiniciarVariables();
                    funcionalidadesAdministrador();

                }
                else
                {
                    anularElecciones();
                }

            }
            else if (anular.Equals("n"))
            {
                Console.WriteLine("Se canceló la anulacion de la votaciones! ");
            }
        }

        public void reiniciarVariables()
        {
            Array.Clear(Variables.modalidadesActivas, 0, Variables.modalidadesActivas.Length);
            Array.Clear(Variables.cantidadvotosAmarillo, 0, Variables.cantidadvotosAmarillo.Length);
            Array.Clear(Variables.cantidadvotosVioleta, 0, Variables.cantidadvotosAmarillo.Length);
            Array.Clear(Variables.cantidadvotosVerde, 0, Variables.cantidadvotosAmarillo.Length);
            Array.Clear(Variables.cantidadvotosRojo, 0, Variables.cantidadvotosAmarillo.Length);
            Array.Clear(Variables.cantidadvotosAzul, 0, Variables.cantidadvotosAmarillo.Length);
            Variables.votantes_v = new ArrayList();
            Variables.votantes = new ArrayList();
            
        }
    }
}
