using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo
{
    internal class Equipo:IEquatable<Equipo>
    {
        string codigo;
        string nombre;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Equipo(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }

        public Equipo(string codigo)
        {
            this.codigo = codigo;
        }

        public bool Equals(Equipo? other)
        {
            return this.codigo == other.codigo;
        }
        public string mostrarDatos()
        {
            return "codigo: " + codigo + "nombre: " + nombre;
        }
    }
}
