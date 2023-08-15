namespace Clase6_Componente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cont = 0, N = 20;
            CComponente[] componentes = new CComponente[N];
            ulong numSerie = 0;
            string detalle = "";
            float costoC = 0;
            float costoMO = 0;
            bool flag = true;

            while (flag && cont < N) 
            {
                Console.Write("\n\t\t Ingrese el numero de serie: ");
                numSerie = validar_ulong(Console.ReadLine());
                if(numSerie!=0)
                {
                    Console.Write("\n\t\t Ingrese el detalle: ");
                    detalle = Console.ReadLine();
                    Console.Write("\n\t\t Ingrese el costo del componente: ");
                    costoC = validar_float(Console.ReadLine());
                    Console.Write("\n\t\t Ingrese el costo de mano de obra: ");
                    costoMO = validar_float(Console.ReadLine());

                    componentes[cont] = new CComponente();
                    componentes[cont].setcostoC(costoC);
                    componentes[cont].setcostoMO(costoMO);
                    componentes[cont].setDetalle(detalle);
                    componentes[cont].setnumSerie(numSerie);
                    
                    if(costoMO>=costoC)
                    {
                        Console.Write("\n\t\t ¡Mano De Obra Costosa!");
                    }
                    else
                    {
                        Console.Write("\n\n\t DATOS:" + componentes[cont].darDatos());
                    }
                    cont++;
                }
                else
                {
                    flag = false;
                }
            }
            Console.Clear();
            ulong buscar;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t Ingresar el numero de serie a buscar: ");
                buscar = validar_ulong(Console.ReadLine());

                if(buscar!=0)
                {
                    for (int i = 0; i < cont; i++)
                    {
                        if (buscar == componentes[i].getnumSerie())
                        {
                            Console.WriteLine("\t\t" + componentes[i].darDatos());
                            Console.WriteLine("\n\t Ingresar el nuevo precio de componente: ");
                            costoC = validar_float(Console.ReadLine());
                            if (costoC != 0)
                            {
                                componentes[i].setcostoC(costoC);
                            }
                            Console.WriteLine("\n\t Ingresar el nuevo precio de mano de obra: ");
                            costoMO = validar_float(Console.ReadLine());
                            if (costoMO != 0)
                            {
                                componentes[i].setcostoMO(costoMO);
                            }
                            Console.WriteLine("\t\t" + componentes[i].darDatos());
                            Console.ReadKey();
                        }
                    }
                }
            } while (buscar != 0);

            Console.ReadKey();
        }

        
        public static float validar_float(string str)
        {
            bool valido;
            string validar;
            float dato;
            valido = float.TryParse(str, out dato);
            if(valido)
            {
                return dato;
            }
            else
            {
                Console.Write("\n\t Formato invalido ingrese un float: ");
                validar = Console.ReadLine();
                return validar_float(validar);
            }
        }
        public static ulong validar_ulong(string str)
        {
            bool valido;
            string  validar="";
            ulong dato;
            valido = ulong.TryParse(str, out dato);
            if (valido)
            {
                return dato;
            }
            else
            {
                Console.WriteLine("\n\t Formato invalido ingrese un ulong: ");
                validar = Console.ReadLine();
                return validar_ulong(validar);
            }
        }
        

    }
}