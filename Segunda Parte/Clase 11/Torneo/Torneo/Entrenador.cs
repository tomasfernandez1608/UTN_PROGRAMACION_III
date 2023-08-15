using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo
{
    internal class Entrenador:Socio,IEquatable<Entrenador>
    {
        string telefonoContacto;

        public Entrenador(string dNI) : base(dNI)
        {
        }

        public Entrenador(string dNI, string apellido, string nombre, string telefonoContacto, Equipo equipo) : base(dNI, apellido, nombre,equipo)
        {
            this.TelefonoContacto = telefonoContacto;
        }

        public string TelefonoContacto { get => telefonoContacto; set => telefonoContacto = value; }

        public bool Equals(Entrenador? other)
        {
            return this.DNI == other.DNI;
        }

        public override string mostrarDatos()
        {
            return base.mostrarDatos() + " contacto: " + telefonoContacto.ToString();
        }
    }
}
