using System;

namespace Constructora // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Controlador controlador = new Controlador();
            int opcion;
            string DNI, apellido, nombre, codigo;
            int estado;

            do
            {
                opcion = Interfaz.Menu();
                switch(opcion)
                {
                    case 1:
                        DNI = Interfaz.LeerString_getString("Ingrese el DNI: ");
                        apellido = Interfaz.LeerString_getString("Ingresar El apellido: ");
                        nombre = Interfaz.LeerString_getString("Ingresar El nombre: ");
                        estado = 0;
                        string tipo = Interfaz.LeerString_getString("[1] Obrero \n [2] Capataz\n\n Opcion:");
                        if(tipo=="1")//Empleado-Obrero
                        {
                            int espe = Interfaz.LeerEspecialidad();
                            Especialidad especialidad = new Especialidad();
                            switch(espe)
                            {
                                case 1:
                                    especialidad = Especialidad.Albañil;
                                    break;
                                case 2:
                                    especialidad = Especialidad.Pintor;
                                    break;
                                case 3:
                                    especialidad = Especialidad.Plomero;
                                    break;
                                case 4:
                                    especialidad = Especialidad.Herrero;
                                    break;
                                case 5:
                                    especialidad = Especialidad.Electricista;
                                    break;
                            }
                            if(controlador.añadirEmpleado(DNI, nombre, apellido, estado, especialidad))
                            {
                                  Interfaz.LeerString("Obrero Cargado");
                            }
                            else
                            {
                                Interfaz.LeerString("Obrero NO Cargado, ya existe ese DNI");
                            }
                        }
                        else if(tipo=="2")//Empleado Capataz
                        {
                            uint matricula=Interfaz.LeerString_getuint("Ingrese la Matricula: ");
                            if(controlador.añadirEmpleado(DNI, nombre, apellido, estado, matricula))
                            {
                                Interfaz.LeerString("Capataz Cargado");
                            }
                            else
                            {
                                Interfaz.LeerString("Capataz NO Cargado, ya existe ese DNI");
                            }
                        }
                        else
                        {
                            Interfaz.LeerString("Error al cargar empleado");
                        }
                        Console.ReadKey();
                        break;
                    case 2://Registrar Obra
                        codigo = Interfaz.LeerString_getString("Ingrese el codigo de la obra: ");
                        string calle = Interfaz.LeerString_getString("Ingrese la calle de la obra: ");
                        string provincia = Interfaz.LeerString_getString("Ingrese la provincia de la obra: ");
                        string localidad = Interfaz.LeerString_getString("Ingrese la localidad de la obra: ");
                        uint numero = Interfaz.LeerString_getuint("Ingrese el numero de la obra: ");
                        if(controlador.añadirObra(codigo, calle, provincia, localidad, numero))
                        {
                            Interfaz.LeerString("Obra ingresada correctamente");
                        }
                        else
                        {
                            Interfaz.LeerString("Obra ya existente");
                        }
                        Console.ReadKey();
                        break;
                    case 3://Remover empleado
                        DNI = Interfaz.LeerString_getString("Ingrese el DNI: ");
                        if(controlador.removerEmpleado(DNI))
                        {
                            Interfaz.LeerString("Empleado Despedido");
                        }
                        else
                        {
                            Interfaz.LeerString("No se encontro el empleado con DNI: " + DNI);
                        }
                        Console.ReadKey();
                        break;
                    case 4://Remover Obrero
                        DNI = Interfaz.LeerString_getString("Ingrese el DNI: ");
                        codigo = Interfaz.LeerString_getString("Ingrese el codigo de la obra: ");
                        if(controlador.removerObrero(codigo,DNI))
                        {
                            Interfaz.LeerString("Obrero Removido");
                        }
                        else
                        {
                            Interfaz.LeerString("No se podido realizar la operacion, verifique el DNI y codigo");
                        }
                        Console.ReadKey();
                        break;
                    case 5://dar datos obra
                        Interfaz.LeerString(controlador.listarObras());                        
                        Console.ReadKey();
                        break;
                    case 6:
                        codigo = Interfaz.LeerString_getString("Ingrese el codigo de la obra: ");
                        Interfaz.LeerString(controlador.listarObreroObra(codigo));
                        Console.ReadKey();
                        break;
                    case 7:
                        Interfaz.LeerString(controlador.listarEmpleados());
                        Console.ReadKey();
                        break;
                    case 8:
                        codigo = Interfaz.LeerString_getString("Ingrese el codigo de la obra: ");
                        DNI = Interfaz.LeerString_getString("Ingrese el DNI: ");
                        if(controlador.asignarObrero(codigo, DNI))
                        {
                            Interfaz.LeerString("Obrero Asignado");
                        }
                        else
                        {
                            Interfaz.LeerString("Obrero No encontrado");
                        }
                        Console.ReadKey();
                        break;
                    case 9:
                        codigo = Interfaz.LeerString_getString("Ingrese el codigo de la obra: ");
                        DNI = Interfaz.LeerString_getString("Ingrese el DNI: ");
                        if(controlador.asignarCapataz(codigo,DNI))
                        {
                            Interfaz.LeerString("Capataz Asignado");
                        }
                        else
                        {
                            Interfaz.LeerString("Capataz NO encontrado");
                        }
                        Console.ReadKey();
                        break;
                    case 10:
                        Interfaz.LeerString(controlador.leerCSV("ListaCliente"));
                        Console.ReadKey();
                        break;
                    case 11:
                        Interfaz.LeerString(controlador.guardarArchivo("ListaCliente"));
                        Console.ReadKey();
                        break;
                    
                }
            } while (opcion != 12);
        }
    }
}