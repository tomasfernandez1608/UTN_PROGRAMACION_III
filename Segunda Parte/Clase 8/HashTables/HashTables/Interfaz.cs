using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    internal class Interfaz
    {
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("\t [1] Buscar Palabra");
            Console.WriteLine("\t [2] Agregar Definicion");
            Console.WriteLine("\t [3] Modificar Definicion");
            Console.WriteLine("\t [4] Eliminar Definicion");
            Console.WriteLine("\t [5] Salir");
            Console.WriteLine("-----------------");
            Console.Write("\n\t Opcion: ");
            return int.Parse(Console.ReadLine());
        }
        public static void leerString(string str)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("\t" + str);
            Console.WriteLine("-----------------");
        }
        public static string leerPalabra()
        {
            Console.WriteLine("-----------------");
            Console.Write("\n\n\t Ingrese la palabra :");
            return Console.ReadLine();
        }
        public static string leerDefinicion()
        {
            Console.WriteLine("-----------------");
            Console.Write("\n\n\t Ingrese la Definicion :");
            return Console.ReadLine();
        }
    }
}
