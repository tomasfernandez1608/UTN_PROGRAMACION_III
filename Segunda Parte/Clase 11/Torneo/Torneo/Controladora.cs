using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo
{
    internal class Controladora
    {
        List<Jugador> jugadores;
        List<Equipo> equipos;
        List<Entrenador> entrenadores;

        public Controladora()
        {
            this.jugadores = new List<Jugador>();
            this.equipos = new List<Equipo>();
            this.entrenadores = new List<Entrenador>();
        }

        public Jugador buscarJugador(string DNI)
        {
           int indice = jugadores.IndexOf(new Jugador(DNI));
            if (indice < 0)
            {
                return null;
            }
            return jugadores[indice];
        }
        public Equipo buscarEquipo(string codigo)
        {
            int indice = equipos.IndexOf(new Equipo(codigo));
            if(indice < 0) return null;
            return equipos[indice];
        }
        
        public Entrenador buscarEntrenador(string DNI)
        {
            int indice = entrenadores.IndexOf(new Entrenador(DNI));
            if( indice == -1) return null;
            return entrenadores[indice];
        }

        public bool registrarJugador(string DNI, string nombre, string apellido, Posicion posicion, Equipo equipo)
        {
            if (buscarJugador(DNI) != null)
            {
                Console.WriteLine("asd");
                return false;
            }
            Jugador nuevo = new Jugador(DNI, nombre, apellido, posicion,equipo);
            jugadores.Add(nuevo);
            return true;
        }
        public bool registrarEquipo(string codigo,string nombre)
        {
            if(buscarEquipo(codigo) != null) return false;
            Equipo equipo = new Equipo(codigo, nombre);
            equipos.Add(equipo);
            return true;
        }
        public bool registrarEntrenador(string DNI, string nombre, string apellido, string contacto, Equipo equipo)
        {
            if(buscarEntrenador(DNI)!=null) return false;
            Entrenador entrenador = new Entrenador(DNI, apellido, nombre, contacto, equipo);
            entrenadores.Add(entrenador);
            return true;
        }
        public void listarEquipos()
        {
            foreach(Equipo equipo in equipos)
            {
                Interfaz.mostrarMensaje(equipo.mostrarDatos());
                foreach(Entrenador entrenador in entrenadores)
                {
                    if(entrenador.Equipo == equipo)
                    {
                        Interfaz.mostrarMensaje(entrenador.mostrarDatos());
                    }
                }
            }
        }
        public void listarJugadoresDeEquipo(string codigo)
        {
            Equipo equipo = buscarEquipo(codigo);
            if (equipo != null)
            {
                foreach(Jugador jugador in jugadores)
                {
                    if(jugador.Equipo == equipo)
                    {
                        Interfaz.mostrarMensaje(jugador.mostrarDatos());
                    }
                }
            }
            else
            {
                Interfaz.mostrarMensaje("No se encontro el equipo");
            }
        }
        public bool removerSocio(string DNI)
        {
            Jugador jugador = buscarJugador(DNI);
            Entrenador entrenador = buscarEntrenador(DNI);
            if (jugador != null)
            {

                jugadores.Remove(jugador);
             
                return true;
            }
            else
            {
             
                if(entrenador != null)
                {
             

                    entrenadores.Remove(entrenador);
                    return true;
                }
            }

            return false;
        }
    }
}
