using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aterizar
{
    internal class Interfaz
    {
        public static int Menu()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\t- Paquete -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n [1] Agregar Paquete Auto");
            Console.WriteLine("\n [2] Agregar Paquete Estadia");
            Console.WriteLine("\n [3] Listar Paquetes");
            Console.WriteLine("\n [0] Salir");
            Console.WriteLine("\n");
            Console.Write("-----------------------------------");
            return elegirOpcion();
        }
        public static int elegirOpcion()
        {
            Console.Write("\n\n OPCION:");
            int opcion;
            bool Resultado = int.TryParse(Console.ReadLine(), out opcion);
            if (Resultado)
            {
                return opcion;
            }
            elegirOpcion();
            return -1;
        }
        public static string Leer_getString(string msg)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\t- Paquete -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write("\t" + msg);
            return Console.ReadLine();
        }
        public static bool Leer_getBool(string msg)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\t- Paquete -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write("\t" + msg);
            Console.WriteLine("[1] Si");
            Console.WriteLine("[2] No");
            int opcion;
            do
            {
                opcion = elegirOpcion();
            }while(opcion!=1 && opcion!=2);
            if(opcion==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static ulong Leer_getulong(string msg)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\t- Paquete -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write("\t" + msg);
            return validarUlong(Console.ReadLine());
        }
        public static ulong validarUlong(string str)
        {
            ulong val;
            bool resultado = ulong.TryParse(str, out val);
            if (resultado)
            {
                return val;
            }
            validarUlong(Console.ReadLine());
            return val;
        }

        public static float Leer_getfloat(string msg)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\t- Paquete -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write("\t" + msg);
            return validarfloat(Console.ReadLine());
        }
        public static float validarfloat(string str)
        {
            float val;
            bool resultado = float.TryParse(str, out val);
            if (resultado)
            {
                return val;
            }
            validarUlong(Console.ReadLine());
            return val;
        }
        public static uint Leer_getuint(string msg)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\t- Paquete -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write("\t" + msg);
            return validaruint(Console.ReadLine());
        }
        public static uint validaruint(string str)
        {
            uint val;
            bool resultado = uint.TryParse(str, out val);
            if (resultado)
            {
                return val;
            }
            validarUlong(Console.ReadLine());
            return val;
        }

        public static void LeerString(string str)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\t- Paquete -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write(str);

        }
    }
}
