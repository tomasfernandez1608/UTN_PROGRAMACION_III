using HashTables;
using System;
using System.Collections;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controlador controlador=new Controlador();
            string Palabra, definicion;
            int opcion;
            do
            {
                opcion = Interfaz.Menu();
                switch(opcion )
                {
                    case 1:
                        Palabra=Interfaz.leerPalabra();
                        Interfaz.leerString(controlador.buscarDefinicion(Palabra));
                        Console.ReadKey();
                        break;
                    case 2:
                        Palabra = Interfaz.leerPalabra();
                        definicion = Interfaz.leerDefinicion();
                        if(controlador.agregarDefinicion(Palabra,definicion))
                        {
                            Interfaz.leerString("Operacion exitosa");
                        }
                        else
                        {
                            Interfaz.leerString("Error al añadir la definicion");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Palabra = Interfaz.leerPalabra();
                        definicion = Interfaz.leerDefinicion();
                        if(controlador.modificarDefinicion(Palabra, definicion))
                        {
                            Interfaz.leerString("Operacion exitosa");
                        }
                        else
                        {
                            Interfaz.leerString("Error al modificar la definicion");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Palabra = Interfaz.leerPalabra();
                        if(controlador.eliminar(Palabra))
                        {
                            Interfaz.leerString("Operacion exitosa");
                        }
                        else
                        {
                            Interfaz.leerString("Error al modificar la definicion");
                        }
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);

        }
    }
}