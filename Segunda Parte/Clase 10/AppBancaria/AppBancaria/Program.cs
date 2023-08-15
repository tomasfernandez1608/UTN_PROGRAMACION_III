using System;

namespace AppBancaria // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controlador controlador = new Controlador();
            //Set staticos 
            controlador.setInteresMensual(Interfaz.setInteresMensual());
            CajaAhorro.setinteresRetorno(Interfaz.LeerMensaje_getfloat("Ingrese el interes de Retorno: "));
            CuentaCorriente.setmontoDescubierto(Interfaz.LeerMensaje_getfloat("Ingrese El monto a Descubierto: "));

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
                        int tipo = Interfaz.darTipoCuenta();
                        if(tipo==1)
                        {
                            string planCuenta = Interfaz.LeerMensaje_getstring("Ingrese el plan de cuenta: ");
                            ulong tarjetaVinculada = Interfaz.LeerMensaje_getulong("Ingrese la tarjetaVinculada:");
                            if(controlador.agregarCuenta(CBU,cliente,saldo,planCuenta,tarjetaVinculada))
                            {
                                Interfaz.LeerString("Cuenta Agregada Exitosamente");
                            }

                        }
                        else if(tipo==2)
                        {
                            float interesDescubierto = Interfaz.LeerMensaje_getfloat("Ingrese El Interes a descubierto");
                            if(controlador.agregarCuenta(CBU, cliente, saldo,interesDescubierto))
                            {
                                Interfaz.LeerString("Cuenta Agregada Exitosamente");
                            }
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