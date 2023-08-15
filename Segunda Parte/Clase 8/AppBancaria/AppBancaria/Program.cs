using System;

namespace AppBancaria // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controlador controlador = new Controlador();
            //Set intereses mensuales
            controlador.setInteresMensual(Interfaz.setInteresMensual());
            int opcion;
            ulong CBU;
            string cliente;
            float saldo;
            do
            {
                opcion=Interfaz.Menu();
                switch(opcion)
                {
                    case 1:
                        CBU=Interfaz.LeerCBU();
                        cliente=Interfaz.LeerCliente();
                        saldo=Interfaz.LeerSaldo();
                        if(controlador.agregarCuenta(CBU, cliente, saldo))
                        {
                            Interfaz.LeerString("Cuenta Agregada Exitosamente");
                        }
                        else
                        {
                            Interfaz.LeerString("La cuenta con CBU:" + CBU + " ya existe");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        CBU = Interfaz.LeerCBU();
                        saldo = Interfaz.LeerSaldo();
                        if(controlador.deposito(CBU,saldo))
                        {
                            Interfaz.LeerString("DEPOSITO EXITOSO");
                        }
                        else
                        {
                            Interfaz.LeerString("DEPOSITO NO REALIZADO");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        CBU = Interfaz.LeerCBU();
                        saldo = Interfaz.LeerSaldo();
                        if(controlador.extraccion(CBU, saldo))
                        {
                            Interfaz.LeerString("Extraccion EXITOSA");
                        }
                        else
                        {
                            Interfaz.LeerString("Extraccion NO REALIZADA");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        CBU = Interfaz.LeerCBU();
                        Interfaz.LeerString(controlador.darDatosCBU(CBU));
                        Console.ReadKey();
                        break;
                    case 5:
                        Interfaz.LeerString(controlador.darDatosTodos());
                        Console.ReadKey();
                        break;
                    case 6:
                        CBU = Interfaz.LeerCBU();
                        if(controlador.eliminarCuenta(CBU))
                        {
                            Interfaz.LeerString("Elimanada Exitosa");
                        }
                        else
                        {
                            Interfaz.LeerString("No se a encontrado la cuenta");
                        }
                        Console.ReadKey();
                        break;
                    case 7:
                        CBU = Interfaz.LeerCBU();
                        Interfaz.LeerString(controlador.getSaldoFinal(CBU, Interfaz.LeerInt("Ingrese la cantidad de meses: ")));
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 8);
        }
    }
}