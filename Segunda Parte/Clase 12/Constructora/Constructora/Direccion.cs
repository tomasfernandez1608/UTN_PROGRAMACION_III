using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    internal class Direccion
    {
        string calle;
        string localidad;
        string provincia;
        uint numero;

        public Direccion(string calle, string localidad, string provincia, uint numero)
        {
            this.calle = calle;
            this.localidad = localidad;
            this.provincia = provincia;
            this.numero = numero;
        }

        public string darDatos()
        {
            return "\n"
                + "\n\t Calle: " + this.calle
                + "\n\t Localidad" + this.localidad
                + "\n\t Provincia" + this.provincia
                + "\n\t Numero: " +this.numero;
        }

    }
}
