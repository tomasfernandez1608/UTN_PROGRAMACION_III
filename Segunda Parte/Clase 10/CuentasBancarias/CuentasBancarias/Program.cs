using CuentasBancarias;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cuenta> ListaCuentas = new List<Cuenta>();
            Console.WriteLine("\n\t Ingrese el monto a descubierto: ");
            CuentaCorriente.setmontoDescubierto(float.Parse(Console.ReadLine()));
            Console.WriteLine("\n\t Ingrese el interesRetorno");
            CajaAhorro.setinteresRetorno(float.Parse(Console.ReadLine()));
            ulong CBU;
            string cliente;
            float saldo;
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------");
                Console.Write("\n\t Ingrese un CBU: ");
                CBU = ulong.Parse(Console.ReadLine());
                if (CBU != 0)
                {
                    Console.Write("\n\t Ingrese el nombre y apellido: ");
                    cliente = Console.ReadLine();
                    Console.Write("\n\t Ingrese el saldo: ");
                    saldo = float.Parse(Console.ReadLine());
                    Console.WriteLine("\n\t INGRESE 1 PARA CREAR UNA CUENTA CORRIENTE");
                    Console.WriteLine("\n\t INGRESE 2 PARA CREAR UNA CUENTA AHORRO");
                    Console.Write("\n\t OPCION: ");
                    opcion = int.Parse(Console.ReadLine());
                    if (opcion == 1)
                    {
                        Console.Write("\n\t INGRESE los intereses descubiertos: ");
                        float interesDescubierto = float.Parse(Console.ReadLine());
                        ListaCuentas.Add(new CuentaCorriente(CBU, cliente, saldo, interesDescubierto));
                    }
                    if (opcion == 2)
                    {
                        Console.Write("\n\t INGRESE El plan de cuenta: ");
                        string planCuenta = Console.ReadLine();
                        Console.Write("\n\t INGRESE La tarjeta Vincualada ");
                        ulong tarjetaVinculada = ulong.Parse(Console.ReadLine());
                        ListaCuentas.Add(new CajaAhorro(CBU, cliente, saldo, planCuenta, tarjetaVinculada));
                    }
                }
            } while (CBU != 0) ;

            foreach(Cuenta cuenta in ListaCuentas)
            {
                Console.WriteLine(cuenta.darDatos());
            }
            // FALTA COMPLETAR
            Console.ReadKey();
        }
    }
}