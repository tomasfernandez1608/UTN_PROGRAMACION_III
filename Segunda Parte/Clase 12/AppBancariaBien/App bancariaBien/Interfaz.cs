using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_bancariaBien
{
    internal class Interfaz
    {
        public Interfaz(ConsoleColor backgroud, ConsoleColor foreGround)
        {
            Console.BackgroundColor = backgroud;
            Console.ForegroundColor = foreGround;   
        }
        public int mostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*        Sistema de Gestión de Cuentas        *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[0] Cargar desde archivo.");
            Console.WriteLine("\n[1] Agregar una cuenta.");
            Console.WriteLine("\n[2] Efectuar un depósito.");
            Console.WriteLine("\n[3] Efectuar una extracción.");
            Console.WriteLine("\n[4] Mostrar datos de una cuenta.");
            Console.WriteLine("\n[5] Listar los datos de todas las cuentas.");
            Console.WriteLine("\n[6] Remover una cuenta.");
            Console.WriteLine("\n[7] Simular intereses de una cuenta.");
            Console.WriteLine("\n[8] Guardar todo en archivo.");
            Console.WriteLine("\n[9] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            return this.pedirDatoMenu();
        }

        public int pedirDatoMenu()
        {
            int devolucion;
            do
            {
                Console.WriteLine("Ingrese una opcion entre 1 y 9");
                devolucion = int.Parse(Console.ReadLine());
            } while (devolucion < 0 || devolucion > 9);
            return devolucion;
        }
        public void mostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("Presione una tecla para seguir");
            Console.ReadKey();
            Console.Clear();
        }
        public ulong leerCBU(string mensaje)
        {
            string lectura;
            ulong CBU;
            Console.WriteLine(mensaje);
            lectura = Console.ReadLine();
            CBU = System.Convert.ToUInt64(lectura);
            return CBU;
        }
        public float leerFlotante(string mensaje)
        {
            string lectura;
            float monto;
            Console.WriteLine(mensaje);
            lectura = Console.ReadLine();
            monto = System.Convert.ToUInt64(lectura);
            return monto;
        }
        public string leerNombre(string mensaje)
        {
            Console.WriteLine(mensaje);
            string lectura = Console.ReadLine();
            return lectura;
        }
        public int leerEntero(string mensaje)
        {
            Console.WriteLine(mensaje);
            return int.Parse(Console.ReadLine());
        }

    }
}
