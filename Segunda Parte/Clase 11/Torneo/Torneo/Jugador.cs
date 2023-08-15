using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo
{
    internal class Jugador:Socio, IEquatable<Jugador>
    {
        Posicion posicion;
        public Posicion Posicion { get => posicion; set => posicion = value; }
        public Jugador(string dNI, string apellido, string nombre, Posicion posicion, Equipo equipo) : base(dNI, apellido, nombre,equipo)
        {
            this.Posicion = posicion;

        }
        public Jugador(string dNI) : base(dNI)
        {
        }
        public override string mostrarDatos()
        {
            return base.mostrarDatos() + " Posicion: " + posicion.GetType().Name;
        }

        public bool Equals(Jugador? other)
        {
            return DNI == other.DNI;
        }
    }
}
