namespace Clase5_Ejercicio3_Productos
{
    internal class Program
    {
        static int Busquedas_fallidas = 0;
        static void Main(string[] args)
        {
            int cont=0, N = 50, pos=0;
            Producto[] productos=new Producto[N];
            string ID=" ", descripcion="";
            float Precio=0;
            do
            {
                Console.Write("\t Ingrese un ID: ");
                ID = Console.ReadLine();
                if(ID!="-1")
                {
                    Console.Write("\n\t Ingrese su descripcion: ");
                    descripcion= Console.ReadLine();
                    Console.Write("\n\t Ingrese el Precio Unitario: ");
                    Precio = float.Parse(Console.ReadLine());
                    productos[cont] = new Producto(ID,descripcion,Precio);
                    cont++;
                }

            } while (cont < N && ID!="-1");


            do
            {
                Console.Write("\n\n\t Ingrse el ID a buscar: ");
                ID = Console.ReadLine();
                if (ID!="-1")
                {
                    pos = buscar(productos, ID, cont);
                    //MENU
                }
            } while (pos != -1);
            
            Console.ReadLine();
        }
        public static void menu(Producto[] productos, int pos, int cont)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n\n\n\t MENU(seleccione la opcion)");
                Console.WriteLine("\n\n\t\t 1.Activar/Desabilitar Promocion"); 
                Console.WriteLine("\n\n\t\t 2.Sumar Al Carrito");
                Console.WriteLine("\n\n\t\t 3.Salir");
                Console.Write("\n\n\t\t Opcion: ");
                opcion = validar_int(Console.ReadLine());
                switch(opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("\n\n\t\t Ingrese el Descuento:");
                        productos[pos].ConfigurarPromocion(float.Parse(Console.ReadLine()));
                        break;
                    case 2:

                        break;
                }

            } while (opcion !=3);
        }
        public static int validar_int(string str)
        {
            int entero;
            bool valido;
            valido = int.TryParse(str, out entero);
            if(valido)
            {
                return entero;
            }
            else
            {
                Console.Write("\n\n\t\t (INGRESE UN NUMERO ENTERO): ");
                entero=validar_int(Console.ReadLine());
                return entero;
            }
            
        }
        public static int buscar(Producto[] productos, string ID_buscar, int cont)
        {
            string ID;
            int pos;
            for(int i = 0; i < cont; i++)
            {
                if (productos[i].getID()==ID_buscar)
                {
                    return i;
                }
            }
            do
            {
                Console.Clear();
                Console.Write("\n\n\t ID invalido, Ingrese otro o finalize con -1 "); Console.Write("\n\n\t Ingrse el ID: ");
                ID = Console.ReadLine();
                if(ID!="-1")
                {
                    Busquedas_fallidas++;
                    pos=buscar(productos, ID, cont);
                    return pos;
                }
            } while(ID!="-1");
            return -1;
        }

    }
}