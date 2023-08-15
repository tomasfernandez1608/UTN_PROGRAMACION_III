using Aterizar;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controlador controlador = new Controlador();
            Paquete.setInteres(Interfaz.Leer_getfloat("Ingrese El Interes por Cuota: "));
            uint Programa = Interfaz.Leer_getuint("\n\t [1] Para Usar el programa con una Lista" +
                "\n\t [2] Para usar el programa con dos lista separadas ");
            string Codigo, Destino, Origen, NombreHotel, Patente;
            uint CantidadNoches, CantidadDias;
            bool ContraraSeguro;
            float Precio, CostoHabitacion, CostoPorDia, CostoSeguro=0;
            int opcion;
            if (Programa==1)
            {
                do
                {
                    opcion = Interfaz.Menu();
                    switch(opcion)
                    {
                        case 1://Agregar Paquete Auto
                            Codigo = Interfaz.Leer_getString("Ingrese El codigo del paquete: ");
                            Origen = Interfaz.Leer_getString("Ingrese el origen: ");
                            Destino = Interfaz.Leer_getString("Ingrese El Destino: ");
                            Precio = Interfaz.Leer_getfloat("Ingrese el Precio del paquete: ");
                            Patente = Interfaz.Leer_getString("Ingrese La Patente del auto: ");
                            ContraraSeguro = Interfaz.Leer_getBool("Desea contratar Seguro?");
                            if(ContraraSeguro)
                            {
                                CostoSeguro = Interfaz.Leer_getfloat("Ingrese el costo del seguro: ");
                            }
                            CantidadDias = Interfaz.Leer_getuint("Ingrese la cantidad de dias: ");
                            CostoPorDia = Interfaz.Leer_getfloat("Ingrese el costo por dia: ");
                            if (controlador.agregarPaquete(Codigo, Origen, Destino, Precio, Patente, ContraraSeguro,
                                CostoSeguro, CantidadDias, CostoPorDia))
                            {
                                Interfaz.LeerString("Paquete agregado correctamente");
                            }
                            else
                            {
                                Interfaz.LeerString("Paquete No agregado, pruebe nuevamente");
                            }
                            Console.ReadKey();
                            break;
                        case 2://Agregar Paquete Estadia
                            Codigo = Interfaz.Leer_getString("Ingrese El codigo del paquete: ");
                            Origen = Interfaz.Leer_getString("Ingrese el origen: ");
                            Destino = Interfaz.Leer_getString("Ingrese El Destino: ");
                            Precio = Interfaz.Leer_getfloat("Ingrese el Precio del paquete: ");
                            NombreHotel = Interfaz.Leer_getString("Ingrese El nombre del Hotel:");
                            CantidadNoches = Interfaz.Leer_getuint("Ingrese la cantidad de noches:");
                            CostoHabitacion = Interfaz.Leer_getfloat("Ingrese el costo de la Habitacion:");
                            if (controlador.agregarPaquete(Codigo, Origen, Destino, Precio,NombreHotel,CantidadNoches,CostoHabitacion))
                            {
                                Interfaz.LeerString("Paquete agregado correctamente");
                            }
                            else
                            {
                                Interfaz.LeerString("Paquete No agregado, pruebe nuevamente");
                            }
                            Console.ReadKey();
                            break;
                        case 3://listar lista paquete
                            Interfaz.LeerString(controlador.ListarPaquetes());
                            //Console.ReadKey();
                            break;  
                    }
                }while(opcion!=0);
            }
            else
            {
                do
                {
                    opcion = Interfaz.Menu();
                    switch (opcion)
                    {
                        case 1://Agregar Paquete Auto

                            Console.ReadKey();
                            break;
                        case 2://Agregar Paquete Estadia

                            Console.ReadKey();
                            break;
                        case 3://listar lista paquete

                            Console.ReadKey();
                            break;
                    }
                } while (opcion != 0);
            }
        }
    }
}