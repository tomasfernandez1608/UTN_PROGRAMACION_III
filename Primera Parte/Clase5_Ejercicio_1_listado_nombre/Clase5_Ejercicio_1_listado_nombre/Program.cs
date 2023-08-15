using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase5_Ejercicio_1_listado_nombre
{
    class Program
    {
        static int N = 50;
        static void Main(string[] args)
        {
            string[] Nombres= new string[N];
            string nombre;
            int pos, cont=0;
            bool flag = true;
            for(int i=0;i<Nombres.Length && flag;i++)
            {
                Console.Write("\n INGRESE UN NOMBRE: ");
                nombre = Console.ReadLine();
                if (nombre != "FIN")
                {
                    Nombres[i] = nombre;
                    cont++;
                }
                else
                {
                    flag = false;
                }
            }

            Console.Write("\n BUSCAR UN NOMBRE: ");
            nombre = Console.ReadLine();

            pos=Array.IndexOf(Nombres,nombre);
            
            if(pos>=0)
            {
                Console.WriteLine("Posicion de orden de ingreso: {0} Ingreso", pos+1);
            }
            else if(cont==0)
            {
                Console.WriteLine("No se ingresaron Nombres");
                return;
            }
            else
            {
                Console.WriteLine("NO SE ENCONTRO EL NOMBRE");
                return;
            }
            
            
            Array.Sort(Nombres, 0, cont);//A a Z (menor a mayor)
            
            pos=Array.BinarySearch(Nombres, 0, cont, nombre );

            if (pos>=0)
            {
                Console.WriteLine("Posicion en orden alfabetico: {0} posicon alfabetica",pos+1);
            }

            Array.Reverse(Nombres,0,cont);

            for(int i=0; i<cont; i++)
            {
                Console.WriteLine("\n {0}", Nombres[i]);
            }
        }
    }
}