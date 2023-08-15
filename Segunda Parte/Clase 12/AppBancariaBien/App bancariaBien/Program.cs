// See https://aka.ms/new-console-template for more information
// Esta clase la vamos a usar como interfaz. Su responsabilidad va a ser la entrada y salida de datos en 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_bancariaBien
{
    internal class Program
    {
        public static void Main(String[] args)
        {
            ControladorCuentas listaCuentas = new ControladorCuentas();
            Interfaz interfaz = new Interfaz(ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            int opcion;
            ulong CBU;
            float monto;
            string nombreCliente;
            bool resultadoOperacion = false;
            Cuenta.InteresMensual = interfaz.leerFlotante("Ingrese el interes mensual de las cuentas");
            opcion = interfaz.mostrarMenu();
            while (opcion != 9)
            {
                switch (opcion)
                {
                    case 0:
                        if(listaCuentas.leerXML(interfaz.leerNombre("Ingrese el nombre del archivo: ")) == "ok")
                        {
                            interfaz.mostrarMensaje("Leido con exito");
                        }
                        else
                        {
                            interfaz.mostrarMensaje("Fallo la lectura");
                        }
                       break;
                    case 1:
                        CBU = interfaz.leerCBU("Ingrese el CBU de la cuenta a agregar");
                        nombreCliente = interfaz.leerNombre("Ingrese el nombre del nuevo cliente");
                        monto = interfaz.leerFlotante("Ingrese el monto inicial de la cuenta");
                        resultadoOperacion = listaCuentas.crearCuenta(CBU,nombreCliente,monto);
                        if (resultadoOperacion)
                        {
                            interfaz.mostrarMensaje("Cuenta creada correctamente");
                        }
                        else
                        {
                            interfaz.mostrarMensaje("Ya existe una cuenta con ese CBU");
                        }
                    break;
                    case 2:
                        CBU = interfaz.leerCBU("Ingrese el CBU de la cuenta");
                        monto = interfaz.leerFlotante("Ingrese el monto a depositar");
                        resultadoOperacion = listaCuentas.depositar(CBU,monto);
                        if (resultadoOperacion)
                        {
                            interfaz.mostrarMensaje("Deposito correcto");
                            listaCuentas.mostrarDatosCuenta(CBU);
                        }
                        else
                        {
                            interfaz.mostrarMensaje("No se pudo realizar el deposito.");
                        }
                        break;
                    case 3:
                        CBU = interfaz.leerCBU("Ingrese el CBU de la cuenta");
                        monto = interfaz.leerFlotante("Ingrese el monto a extraer");
                        resultadoOperacion = listaCuentas.extraer(CBU, monto);
                        if (resultadoOperacion)
                        {
                            interfaz.mostrarMensaje("Extraccion correcta");
                            listaCuentas.mostrarDatosCuenta(CBU);
                        }
                        else
                        {
                            interfaz.mostrarMensaje("No se pudo realizar la extraccion.");
                        }
                    break;
                    case 4:
                        CBU = interfaz.leerCBU("Ingrese el CBU de la cuenta a mostrar");
                        interfaz.mostrarMensaje(listaCuentas.mostrarDatosCuenta(CBU));
                    break;
                    case 5:
                        interfaz.mostrarMensaje(listaCuentas.mostrarListado());
                    break;
                    case 6:
                        CBU = interfaz.leerCBU("Ingrese el CBU de la cuenta a eliminar");
                        resultadoOperacion = listaCuentas.eliminarCuenta(CBU);
                        if (resultadoOperacion)
                        {
                            interfaz.mostrarMensaje("Cuenta eliminada con exito");
                        }
                        else
                        {
                            interfaz.mostrarMensaje("No se pudo eliminar la cuenta");
                        }
                    break;
                    case 7:
                        CBU = interfaz.leerCBU("ingrese el CBU de la cuenta");
                        int meses = interfaz.leerEntero("Ingrese la cantidad de meses");
                        float saldoResultante = listaCuentas.simularIntereses(meses, CBU);
                        interfaz.mostrarMensaje("El saldo resultante despues de " + meses.ToString() + " meses es de $" + saldoResultante.ToString());
                    break;
                    case 8:
                        string archivo = interfaz.leerNombre("Ingrese el nombre del arhivo para guardar: ");
                        string resultado = listaCuentas.guardarEnJson(archivo);
                        if(resultado == "ok")
                        {
                            interfaz.mostrarMensaje("Se guardo con exito");
                        }
                        else
                        {
                            interfaz.mostrarMensaje("No se pudo guardar. Error: " + resultado);
                        }
                        break;
                    default:
                        interfaz.mostrarMensaje("Ingrese una opcion valida");
                    break;

                }
                opcion = interfaz.mostrarMenu();
            }
            interfaz.mostrarMensaje("Hasta luego");
        }
     }
}


