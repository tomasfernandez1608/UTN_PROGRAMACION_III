using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo
{
    internal class Socio: IEquatable<Socio>
    {
        string dni, apellido, nombre;
        Equipo equipo;

        public string DNI { get => dni; set => dni = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        internal Equipo Equipo { get => equipo; set => equipo = value; }

        public Socio(string dNI, string apellido, string nombre, Equipo equipo)
        {
            DNI = dNI;
            this.apellido = apellido;
            this.nombre = nombre;
            this.Equipo = equipo;
        }

        public Socio(string dNI)
        {
            DNI = dNI;
        }

        public bool Equals(Socio? other)
        {
            return dni == other.DNI;
        }
        public virtual string mostrarDatos()
        {
            return "DNI: " + dni + " nombre y apellido: " + nombre + " " + apellido + " equipo: " + equipo.Nombre;
        }

    }
}
