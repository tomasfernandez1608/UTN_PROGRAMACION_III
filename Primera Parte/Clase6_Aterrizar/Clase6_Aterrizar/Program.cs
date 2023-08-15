namespace Clase6_Aterrizar
{
    internal class Program
    {
        static int N = 3;
        static void Main(string[] args)
        {
            
            string Codigo, Origen, Destino;
            float Precio;
            Viaje[] viajes = new Viaje[N];

            for (int i = 0; i < N; i++)
            {
                Console.Write("\n\t Ingrese el codigo: ");
                Codigo = Console.ReadLine();
                Console.Write("\n\t Ingrese el Origen: ");
                Origen = Console.ReadLine();
                Console.Write("\n\t ingrese el destino: ");
                Destino = Console.ReadLine();
                Console.Write("\n\t Ingrese el precio: ");
                Precio = Validar_float(Console.ReadLine());

                viajes[i] = new Viaje(Codigo, Origen, Destino, Precio);
            }
            int opcion;
            do
            {
                opcion = menu(viajes);
            } while (opcion != 4);
        }
        public static int menu(Viaje[] viajes)
        {
            int opcion;
            string codigo;

            Console.Clear();
            Console.WriteLine("\n\t MENU: \n\t\t Seleccione una opcion:");
            Console.WriteLine("\n\t\t\t 1. Buscar por codigo:");
            Console.WriteLine("\n\t\t\t 2. Buscar por origen:");
            Console.WriteLine("\n\t\t\t 3. Buscar por destino:");
            Console.WriteLine("\n\t\t\t 4. Salir:");
            Console.Write("\n\n\t\t\t");
            opcion = validar_int(Console.ReadLine());
            switch(opcion)
            {
                case 1:
                    Console.Clear();
                    Console.Write("\n\n\t Ingrese el codigo: ");
                    codigo = Console.ReadLine();
                    buscar_codigo(viajes, codigo);
                    Console.ReadKey();
                    return 1;
              
                case 2:
                    Console.Clear();
                    Console.Write("\n\n\t Ingrese el origen: ");
                    buscar_origen(viajes, Console.ReadLine());
                    Console.ReadKey();
                    return 2;
                case 3:
                    Console.Clear();
                    Console.Write("\n\n\t Ingrese el destino: ");
                    buscar_destino(viajes, Console.ReadLine());
                    Console.ReadKey();
                    return 3;
                case 4:
                    return 4;
            }
            return 0;
        }

        public static void buscar_codigo(Viaje[] viajes, string buscar)
        {
            for(int i=0;i<N;i++)
            {
                if (buscar == viajes[i].GetCodigo())
                {
                    Console.WriteLine(viajes[i].darDatos());
                    Console.Write("\n\n\t\t Ingrese la cantidad de cuotas: ");
                    Console.WriteLine("\n\n\t\t" + viajes[i].darPrecio(validar_int(Console.ReadLine())));
                    return;
                }
            }
            Console.WriteLine("\n\n\t\t No se encontro el viaje.");
            return;
        }
        public static void buscar_origen(Viaje[] viajes, string buscar)
        {
            Console.Clear();
            for (int i = 0; i < N; i++)
            {
                if (buscar == viajes[i].GetOrigen())
                {
                    Console.WriteLine(viajes[i].darDatos());
                    return;
                }
            }
            Console.WriteLine("\n\n\t\t No se encontro el origen.");
            return;
        }
        public static void buscar_destino(Viaje[] viajes, string buscar)
        {
            Console.Clear();
            for (int i = 0; i < N; i++)
            {
                if (buscar == viajes[i].GetDestino())
                {
                    Console.WriteLine(viajes[i].darDatos());
                    return;
                }
            }
            Console.WriteLine("\n\n\t\t No se encontro el origen.");
            return;
        }
        public static float Validar_float(string str)
        {
            float dato;
            bool valido = float.TryParse(str, out dato); ;

            if (valido)
            {
                return dato;
            }
            else
            {
                Console.Write("\n\t Ingrese un float valido: ");
                return Validar_float(Console.ReadLine());
            }
        }
        public static int validar_int(string str)
        {
            int dato;
            bool valido = int.TryParse(str, out dato); ;

            if (valido)
            {
                return dato;
            }
            else
            {
                Console.Write("\n\t Ingrese un int valido: ");
                return validar_int(Console.ReadLine());
            }
        }
    }
}