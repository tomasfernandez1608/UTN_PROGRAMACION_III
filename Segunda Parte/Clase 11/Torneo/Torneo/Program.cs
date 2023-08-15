using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo
{
    class Program
    {
        public static void Main()
        {
            Controladora controladora = new Controladora();
            Interfaz.mostrarMensaje("Bienvenido");
            int resultado; string nombre,apellido,codEquipo, dni,contacto,codigo;
            Posicion posicion;
            Interfaz.mostrarMenu();
            resultado = Interfaz.leerInt("Ingrese una opcion");
            while (resultado!= 7)
            {
                switch (resultado)
                {
                    case 1:
                         codigo = Interfaz.leerString("Ingrese el codigo");
                        nombre = Interfaz.leerString("Ingrese el nombre");
                        if (controladora.registrarEquipo(codigo, nombre)) { Interfaz.mostrarMensaje("Equipo registrado"); }
                        else { Interfaz.mostrarMensaje("No se pudo registrar el equipo"); }
                        break;
                    case 2:
                        dni = Interfaz.leerString("Ingrese el DNI");
                        nombre = Interfaz.leerString("Ingrese el nombre");
                        apellido = Interfaz.leerString("Ingrese el apellido");
                        posicion = Interfaz.leerPosicion("Ingrese la posicion");
                        Equipo equipoJugador = controladora.buscarEquipo(Interfaz.leerString("Ingrese el codigo de equipo"));
                        if(equipoJugador!= null && controladora.registrarJugador(dni, nombre, apellido, posicion, equipoJugador) == true)
                        {
                            Interfaz.mostrarMensaje("Se registro al jugador con exito");
                        }
                        else
                        {
                            Interfaz.mostrarMensaje("No se pudo registrar al jugador");
                        }
                        break;
                    case 3:
                        dni = Interfaz.leerString("Ingrese el DNI");
                        nombre = Interfaz.leerString("Ingrese el nombre");
                        apellido = Interfaz.leerString("Ingrese el apellido");
                        contacto = Interfaz.leerString("Ingrese el contacto");
                        Equipo equipoEntrenador = controladora.buscarEquipo(Interfaz.leerString("Ingrese el codigo de equipo"));
                        if (equipoEntrenador != null && controladora.registrarEntrenador(dni, nombre, apellido, contacto, equipoEntrenador) == true)
                        {
                            Interfaz.mostrarMensaje("Se registro al entrenador con exito");
                        }
                        else
                        {
                            Interfaz.mostrarMensaje("No se pudo registrar al entrenador");
                        }
                        break ;
                    case 4:
                        controladora.listarEquipos();
                        break;
                    case 5:
                        codigo = Interfaz.leerString("ingrese el codigo de equipo a buscar");
                        controladora.listarJugadoresDeEquipo(codigo);
                        break;
                    case 6:
                        dni = Interfaz.leerString("Ingrese el dni de socio a remover");
                        if (controladora.removerSocio(dni))
                        {
                            Interfaz.mostrarMensaje("Se removio al socio con exito");
                        }
                        else
                        {
                            Interfaz.mostrarMensaje("No se remover al socio");
                        }
                        break;
                }

                Interfaz.mostrarMenu();
                resultado = Interfaz.leerInt("Ingrese una opcion");
            }
            Interfaz.salir();
            
        }
        
    }
}
