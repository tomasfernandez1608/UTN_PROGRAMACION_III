using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atletas
{
    class Program
    {
        static void Main(string[] args)
        {
            Atleta atleta1 = new Atleta(1,"Jose","Sri Lanka",13f);
            Atleta atleta2 = new Atleta(2, "Tito", "Peru", 10f);

            if (atleta1.CompareTo(atleta2) > 0)
            {
                Console.WriteLine("El mas rapido es");
                Console.WriteLine(atleta1.DarDatos());
            }
            if (atleta1.CompareTo(atleta2) < 0)
            {
                Console.WriteLine("El mas rapido es");
                Console.WriteLine(atleta2.DarDatos());
            }

            Console.WriteLine("Comparando contra cualquier mierda ");
            Console.WriteLine("Resultado de comaprar contra cualqueir mierda " + atleta1.CompareTo(23));
            Console.ReadKey();


        }
    }
}
