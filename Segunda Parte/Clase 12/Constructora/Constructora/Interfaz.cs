using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    internal class Interfaz
    {
        public static int Menu()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Constructora -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.WriteLine("\n [1] Registrar Empleado");
            Console.WriteLine("\n [2] Registrar Obra");
            Console.WriteLine("\n [3] Remover Empleado");
            Console.WriteLine("\n [4] Remover Obrero de una obra");
            Console.WriteLine("\n [5] Listar Obras");
            Console.WriteLine("\n [6] Listar Obreros de una obra");
            Console.WriteLine("\n [7] Listar Empleados de la constructora");
            Console.WriteLine("\n [8] Asignar un Obrero a una obra");
            Console.WriteLine("\n [9] Asignar un Capataz a una obra");
            Console.WriteLine("\n [10] Cargar un Archivo");
            Console.WriteLine("\n [11] Guardar en un Archivo");
            Console.WriteLine("\n [12] Salir");
            Console.WriteLine("\n\n");
            Console.Write("-----------------------------------");
            return elegirOpcion();
        }
        public static int elegirOpcion()
        {
            Console.Write("\n\n OPCION:");
            int opcion;
            bool Resultado=int.TryParse(Console.ReadLine(),out opcion);
            if(Resultado)
            {
                return opcion;
            }
            elegirOpcion();
            return -1;
        }

        public static string LeerString_getString(string str)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Constructora -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write(str);
            return Console.ReadLine();
        }
        public static uint LeerString_getuint(string str)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Constructora -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write(str);
            return validaruint(Console.ReadLine());
        }
        public static uint validaruint(string str)
        {
            uint valor;
            bool resultado=uint.TryParse(str,out valor);
            if(resultado)
            {
                return valor;
            }
            validaruint(Console.ReadLine());
            return valor;
        }
        public static int LeerEspecialidad()
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Constructora -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.WriteLine("\n [1] Albañil");
            Console.WriteLine("\n [2] Pintor");
            Console.WriteLine("\n [3] Plomero");
            Console.WriteLine("\n [4] Herrero");
            Console.WriteLine("\n [5] Electricista");
            return elegirOpcion();
        }
        public static void LeerString(string str)
        {
            Console.Clear();
            Console.Write("-----------------------------------\n");
            Console.WriteLine("- Constructora -");
            Console.Write("-----------------------------------\n");
            Console.WriteLine("\n\n");
            Console.Write(str);
            
        }
    }
}
