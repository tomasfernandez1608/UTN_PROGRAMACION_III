using System.ComponentModel.DataAnnotations;

namespace Clase5_Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 50, cont=0, pos;
            Cuenta[] cuentas = new Cuenta[N];
            bool flag = true;
            ulong CBU;
            string cliente, str;
            float Saldo;
            for (int i = 0; i < cuentas.Length && flag; i++)
            {
                Console.Write("\n CBU: ");
                str = Console.ReadLine();
                if(str!="-1")
                { 
                    if (validar_ulong(str))
                    {
                        CBU = ulong.Parse(str);
                        Console.Write("\n Cliente: ");
                        cliente = Console.ReadLine();
                        Console.Write("\n Saldo: ");
                        str = Console.ReadLine();
                        if (validar_float(str))
                        {
                            Saldo = float.Parse(str);
                            cuentas[i] = new Cuenta(CBU, cliente, Saldo);
                            cont++;
                        }
                    }
                }
                else 
                {
                    flag = false;
                }
            }
            do
            {
                Console.Write("\n\n\n\t Ingrese un CBU: ");
                str = Console.ReadLine();
                if (str != "-1")
                {
                    if (validar_ulong(str))
                    {
                        CBU = ulong.Parse(str);
                        pos = buscar(cuentas, CBU);
                        if (pos >= 0)
                        {
                            Console.WriteLine("\n\t Se encontro la cuenta" + cuentas[pos].darDatos());
                            menu(cuentas, pos);
                        }
                        else
                        {
                            Console.WriteLine("NO SE ENCONTRO LA CUENTA");
                        }
                    }

                }
            } while (str != "-1");

            Console.WriteLine("\t Impresion de datos:");

            for (int i = 0; i < cont; i++)
            {
                Console.WriteLine("\t\t" + cuentas[i].darDatos());
            }

        }

        public static int buscar(Cuenta[] cuentas, ulong buscar)
        {
            for(int i=0;i<cuentas.Length;i++)
            {
                if (cuentas[i].getCBU()==buscar)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void menu(Cuenta[] cuentas, int pos)
        {
            int Opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t Selecione una opcion:");
                Console.WriteLine("\n\t\t 1.Extraer");
                Console.WriteLine("\n\t\t 2.Depositar");
                Console.WriteLine("\n\t\t 3.Salir");
                Console.Write("\n\n\t\t Ingrese La opcion: ");
                Opcion = int.Parse(Console.ReadLine());
                switch(Opcion)
                {
                    case 1:
                        Console.Write("\n\n\t\t Ingrese el monto: ");
                        cuentas[pos].extraer(validar_float2(Console.ReadLine()));
                        break;
                    case 2:
                        Console.Write("\n\n\t\t Ingrese el monto: ");
                        cuentas[pos].depositar(validar_float2(Console.ReadLine()));
                        break;
                }
            } while (Opcion != 3);
        }
        public static float validar_float2(string str)
        {
            bool validacion;
            float dato;
            validacion = float.TryParse(str, out dato);
            if (validacion)
            {
                return dato;
            }
            else
            {
                Console.WriteLine("Monto NO valido");
                Console.Clear();
                Console.Write("\n\n\t\t Ingrese otro valor: ");
                return validar_float2(Console.ReadLine());
            }
        }
        public static bool validar_ulong(string CBU)
        {
            bool validacion;
            ulong Dato;
            validacion = ulong.TryParse(CBU, out Dato);
            if (validacion && Dato >= 100 && Dato <= 100000)
            {
                return true;
            }
            else
            {
                Console.WriteLine("CBU INVALIDO");
                return false;
            }

        }
        public static bool validar_float(string saldo)
        {
            bool validacion;
            float Dato;
            validacion = float.TryParse(saldo, out Dato);
            if (validacion)
            {
                return true;
            }
            else
            {
                Console.WriteLine("SALDO INVALIDO");
                return false;
            }
        }
    }
}