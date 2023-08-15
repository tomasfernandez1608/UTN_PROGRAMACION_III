using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componentes
{
    internal static class Interfaz
    {
        public static int Menu()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Componente -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.WriteLine("\n [1] Buscar Componente");
            Console.WriteLine("\n [2] Agregar Placa");
            Console.WriteLine("\n [3] Agregar CPU");
            Console.WriteLine("\n [4] Quitar Componente");
            Console.WriteLine("\n [5] Modificar CPU");
            Console.WriteLine("\n [6] Modificar Placa");
            Console.WriteLine("\n [7] Mostrar Lista de componentes");
            Console.WriteLine("\n [8] Cargar un Archivo");
            Console.WriteLine("\n [9] Guardar en un Archivo");
            Console.WriteLine("\n [10] Salir");
            Console.WriteLine("\n\n");
            Console.Write("-----------------------------------");
            return elegirOpcion();
        }
        public static string Leer_getString(string msg)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Componente -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write("\t" + msg);
            return Console.ReadLine();
        }

        public static ulong Leer_getulong(string msg)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Componente -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write("\t" + msg);
            return validarUlong(Console.ReadLine());
        }
        public static ulong validarUlong(string str)
        {
            ulong val;
            bool resultado=ulong.TryParse(str, out val);
            if(resultado)
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
            Console.WriteLine("- Componente -");
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
            Console.WriteLine("- Componente -");
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
        public static void LeerString(string str)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Componente -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write(str);

        }
        public static MarcaPlaca LeerMarcaPlaca()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Componente -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.WriteLine("\n [1] ATI");
            Console.WriteLine("\n [2] Nvidia");
            int opcion;
            MarcaPlaca marcaPlaca = new MarcaPlaca();
            do
            {
                opcion = elegirOpcion();
                switch (opcion)
                {
                    case 1:
                        marcaPlaca = MarcaPlaca.ATI;
                        return marcaPlaca;
                        break;
                    case 2:
                        marcaPlaca = MarcaPlaca.Nvidia ;
                        return marcaPlaca;
                        break;
                }
            } while (opcion != 1 && opcion != 2);
            return marcaPlaca;
        }
        public static MarcaProcesador LeerMarcaProcesador()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Componente -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.WriteLine("\n [1] Intel");
            Console.WriteLine("\n [2] AMD");
            int opcion;
            MarcaProcesador marcaP = new MarcaProcesador();
            do
            {
                opcion = elegirOpcion();
                switch (opcion)
                {
                    case 1:
                        marcaP= MarcaProcesador.Intel;
                        return marcaP;
                        break;
                    case 2:
                        marcaP= MarcaProcesador.AMD;
                        return marcaP;
                        break;
                }
            } while (opcion != 1 && opcion != 2);
            return marcaP;
        }
    }
}
