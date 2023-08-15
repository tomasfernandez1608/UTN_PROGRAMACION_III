using Componentes;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controlador controlador= new Controlador();
            Componente componente= new Componente();
            ulong numSerie;
            string detalle;
            float costoC;
            float costoMO;
            int opcion;
            float FrecuenciaReloj;
            uint CantidadDeNucleos;
            MarcaProcesador marcaProcesador=new MarcaProcesador();
            uint RAM;
            float Frecuencia;
            MarcaPlaca MarcaPlaca= new MarcaPlaca();
            do
            {
                opcion = Interfaz.Menu();
                switch (opcion)
                {
                    case 1:
                        numSerie = Interfaz.Leer_getulong("Ingrese el numero de serie:");
                        componente = controlador.buscar(numSerie);
                        if (componente != null)
                        {
                            if (componente is PlacaDeVideo)
                            {
                                PlacaDeVideo placa = (PlacaDeVideo)componente;
                                Interfaz.LeerString("Componente Encontrado:\n" + placa.darDatos());
                            }
                            if (componente is MicroProcesador)
                            {
                                MicroProcesador micro = (MicroProcesador)componente;
                                Interfaz.LeerString("Componente Encontrado:\n" + micro.darDatos());
                            }
                        }
                        else { Interfaz.LeerString("NO SE ENCONTRO EL COMPONENTE"); }
                        Console.ReadLine();
                        break;
                    case 2:

                        numSerie = Interfaz.Leer_getulong("Ingrese el numero de serie: ");
                        costoC = Interfaz.Leer_getfloat("Ingrese el costo componente: ");
                        costoMO = Interfaz.Leer_getfloat("Ingrese el costo Manu de obra: ");
                        detalle = Interfaz.Leer_getString("Ingrese el detalle: ");
                        RAM = Interfaz.Leer_getuint("Ingrese la RAM: ");
                        Frecuencia = Interfaz.Leer_getfloat("Ingrese la Frecuencia: ");
                        MarcaPlaca = Interfaz.LeerMarcaPlaca();
                        if (controlador.agregar_placa(numSerie, detalle, costoC, costoMO, RAM, Frecuencia, MarcaPlaca))
                        {
                            Interfaz.LeerString("Se añadio correctamente");
                        }
                        else
                        {
                            Interfaz.LeerString("Error");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        numSerie = Interfaz.Leer_getulong("Ingrese el numero de serie: ");
                        costoC = Interfaz.Leer_getfloat("Ingrese el costo componente: ");
                        costoMO = Interfaz.Leer_getfloat("Ingrese el costo Manu de obra: ");
                        detalle = Interfaz.Leer_getString("Ingrese el detalle: ");
                        FrecuenciaReloj = Interfaz.Leer_getfloat("Ingrese la Frecuencia de reloj: ");
                        CantidadDeNucleos = Interfaz.Leer_getuint("Ingrese la cantidad de nucleos");
                        marcaProcesador = Interfaz.LeerMarcaProcesador();
                        if (controlador.agregasCPU(numSerie, detalle, costoC, costoMO, FrecuenciaReloj, CantidadDeNucleos, marcaProcesador)) 
                        {
                            Interfaz.LeerString("Se añadio correctamente");
                        }
                        else
                        {
                            Interfaz.LeerString("Error");
                        }
                        Console.ReadLine();
                        break;
                    case 4:
                        numSerie = Interfaz.Leer_getulong("Ingrese el numero de serie: ");
                        if (controlador.quitar_componente(numSerie))
                        {
                            Interfaz.LeerString("Se quito correctamente");
                        }
                        else
                        {
                            Interfaz.LeerString("No se encontro el componente");
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        numSerie = Interfaz.Leer_getulong("Ingrese el numero de serie: ");
                        FrecuenciaReloj = Interfaz.Leer_getfloat("Ingrese la Frecuencia de reloj: ");
                        CantidadDeNucleos = Interfaz.Leer_getuint("Ingrese la cantidad de nucleos");
                        marcaProcesador = Interfaz.LeerMarcaProcesador();
                        if(controlador.modificar_micro(numSerie,FrecuenciaReloj,CantidadDeNucleos,marcaProcesador))
                        {
                            Interfaz.LeerString("Se Modifico correctamente");
                        }
                        else
                        {
                            Interfaz.LeerString("No se encontro el componente");
                        }
                        Console.ReadLine();
                        break;
                    case 6:
                        numSerie = Interfaz.Leer_getulong("Ingrese el numero de serie: ");
                        RAM = Interfaz.Leer_getuint("Ingrese la RAM: ");
                        Frecuencia = Interfaz.Leer_getfloat("Ingrese la Frecuencia: ");
                        MarcaPlaca = Interfaz.LeerMarcaPlaca();
                        if(controlador.modificar_placa(numSerie,RAM,Frecuencia,MarcaPlaca))
                        {
                            Interfaz.LeerString("Se Modifico correctamente");
                        }
                        else
                        {
                            Interfaz.LeerString("No se encontro el componente");
                        }
                        Console.ReadLine();
                        break;
                    case 7:
                        Interfaz.LeerString(controlador.mostrarDatosLista());
                        Console.ReadLine();
                        break;
                    case 8:
                        Interfaz.LeerString(controlador.CargarArchivoPlaca("listaPlacas.csv"));
                        Interfaz.LeerString(controlador.CargarArchivoCPU("listaCPUs.csv"));
                        Console.ReadLine();
                        break;
                    case 9:
                        Interfaz.LeerString(controlador.GuardarArchivoP("listasPlacas.csv"));
                        Console.ReadLine();
                        break;
                }

            } while (opcion != 10);

        }
    }
}