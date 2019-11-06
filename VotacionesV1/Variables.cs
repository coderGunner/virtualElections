using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotacionesV1
{
   public class Variables
    {
        //variable para determinar el maximo de votos por elecciones 
        public static int maximovotos = 100000;
        //variable para determinar que modalidades ha activado el administrador
        //en orden segun enunciado.
        // 0 inactivo, 1 activo, por defecto todas estan inactivas
        // a. en posicion 0
        // b. en posicion 1
        // c. en posicion 2
        // d. en posicion 3
        // e. en posicion 4
        public static int[] modalidadesActivas = { 0, 0, 0, 0, 0 };
        public static int[] cantidadvotosAmarillo = { 0, 0, 0, 0, 0 };
        public static int[] cantidadvotosVioleta = { 0, 0, 0, 0, 0 };
        public static int[] cantidadvotosVerde = { 0, 0, 0, 0, 0 };
        public static int[] cantidadvotosRojo = { 0, 0, 0, 0, 0 };
        public static int[] cantidadvotosAzul = { 0, 0, 0, 0, 0 };
        public static string password = "admin123";
        public static ArrayList votantes = new ArrayList();
        public static int conteoVotosTotales = 0;
        public static ArrayList votantes_v = new ArrayList();
    }
}
