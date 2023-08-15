using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo
{
    internal static class Interfaz
    {
        public static void mostrarMenu()
        {
            Console.WriteLine("Sistema de gestion de torneo");
            Console.WriteLine("Opcion 1: Registrar un equipo");
            Console.WriteLine("Opcion 2: Registrar un jugador");
            Console.WriteLine("Opcion 3: Registrar un entrenador");
            Console.WriteLine("Opcion 4: Listar todo los equipos con el entrenador");
            Console.WriteLine("Opcion 5: Listar los jugadores de un equipo");
            Console.WriteLine("Opcion 6: Remover a un socio del torneo");
            Console.WriteLine("Opcion 7: Salir");

        }
        public static int leerInt(string mensaje)
        {
            Console.WriteLine(mensaje);
            return int.Parse(Console.ReadLine());
        }
        public static void mostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        public static string leerString(string mensaje)
        {
            mostrarMensaje(mensaje);
            return Console.ReadLine();
        }
        public static Posicion leerPosicion(string mensaje)
        {
            mostrarMensaje(mensaje);
            string lectura = Console.ReadLine().ToLower();
            if (lectura == "arquero") return Posicion.Arquero;
            if (lectura == "defensor") return Posicion.Defensor;
            if (lectura == "mediocampista") return Posicion.Mediocampista;
            if (lectura == "delantero") return Posicion.Delantero;
            return Posicion.Arquero;

        }
        public static void salir()
        {
            mostrarMensaje("Hasta luego");
            Console.ReadKey();
        }
    }
}
