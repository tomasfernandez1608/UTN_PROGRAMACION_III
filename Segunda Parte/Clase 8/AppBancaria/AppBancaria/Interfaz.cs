using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancaria
{
    internal class Interfaz
    {
        public static int Menu()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Sistema de Gestion De Cuentas -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.WriteLine("\n [1] Agregar una Cuenta");
            Console.WriteLine("\n [2] Efectuar un deposito");
            Console.WriteLine("\n [3] Efectuar una extracion");
            Console.WriteLine("\n [4] Mostrar datos de una cuenta");
            Console.WriteLine("\n [5] Listar datos de toda la cuenta");
            Console.WriteLine("\n [6] Remover una cuenta");
            Console.WriteLine("\n [7] Simular saldo final despues de X meses");
            Console.WriteLine("\n [8] Salir de la aplicacion");
            Console.WriteLine("\n\n");
            Console.Write("-----------------------------------");
            return pedirOpcion();
        }
        public static int pedirOpcion()
        {
            int opcion;
            do
            {
                Console.Write("\n Ingrese la opcion: ");
                opcion = int.Parse(Console.ReadLine());
            } while (opcion < 1 || opcion > 8);
            return opcion;
        }
        public static ulong LeerCBU()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Sistema de Gestion De Cuentas -");
            Console.Write("-----------------------------------\n");
            Console.Write("Ingrese CBU: ");
            return ulong.Parse(Console.ReadLine());
        }
        public static string LeerCliente()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Sistema de Gestion De Cuentas -");
            Console.Write("-----------------------------------\n");
            Console.Write("Ingrese Cliente: ");
            return Console.ReadLine();
        }
        public static float LeerSaldo()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Sistema de Gestion De Cuentas -");
            Console.Write("-----------------------------------\n");
            Console.Write("Ingrese Monto Inicial: ");
            return float.Parse(Console.ReadLine());
        }
        public static void LeerString(string s)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Sistema de Gestion De Cuentas -");
            Console.Write("-----------------------------------\n");
            Console.Write(s);
            Console.Write("\n-----------------------------------");
        }
        public static float setInteresMensual()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Sistema de Gestion De Cuentas -");
            Console.Write("-----------------------------------\n");
            Console.Write("Ingrese El interes mensual: ");
            return float.Parse(Console.ReadLine());
        }
        public static int LeerInt(string s)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Sistema de Gestion De Cuentas -");
            Console.Write("-----------------------------------\n");
            Console.Write(s);
            return int.Parse(Console.ReadLine());
        }
    }
}
