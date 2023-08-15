using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase4_ejercicio_Viaje // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ushort Distancia_Recorrida; 
            string Dominio;
            viaje viaje_costoso = new viaje();
            viaje viajes;
            bool Flag = true;
            Console.Write("\n Ingrese el Kilometraje Minimo: ");
            viaje.setMin(validar_ushort(str: Console.ReadLine()));
            Console.Write("\n Ingrese el costo por kilometro: ");
            viaje.setCosto(validar_float(str: Console.ReadLine()));
            Console.WriteLine("DATOS: \n\nKM_MIN:{0} \nCosto_KM: {1}", viaje.getMin(), viaje.getCosto());
            do
            {
                Console.WriteLine("Ingrese el Dominio: ");
                Dominio = Console.ReadLine();
                if (Dominio != "FIN")
                {
                    Console.Write("\n Ingrese la Distancia Recorrida: ");
                    Distancia_Recorrida = validar_ushort(str: Console.ReadLine());
                    if(Distancia_Recorrida > 0 )
                    {
                        viajes = new viaje(Dominio,Distancia_Recorrida);
                        if( Flag || viajes.DarCostoViaje() > viaje_costoso.DarCostoViaje())
                        {
                            viaje_costoso = viajes;
                            Flag = false;
                        }
                    }
                }
            } while (Dominio != "FIN");

            Console.WriteLine(viaje_costoso.DarDatos());

            Console.ReadKey();
        }

        public static ushort validar_ushort(string str)
        {
            bool valido;
            ushort dato;
            valido = ushort.TryParse(str,out dato);
            if (valido)
            {
                return dato;
            }
            return 0;
        }
        public static float validar_float(string str)
        {
            bool valido;
            float dato;
            valido = float.TryParse(str, out dato);
            if (valido)
            {
                return dato;
            }
            return -1;
        }

    }
}