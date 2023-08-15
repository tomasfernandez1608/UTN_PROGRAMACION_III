using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componentes
{
    internal class Componente:IEquatable<Componente>
    {
        ulong numSerie;
        string detalle;
        float costoC;
        float costoMO;

        // Constructor
        public Componente()
        {
            detalle = "A definir";
        }
        public Componente(ulong numSerie, string detalle, float costoC, float costoMO)
        {
            this.numSerie = numSerie;
            this.detalle = detalle;
            this.costoC = costoC;
            this.costoMO = costoMO;
        }
        // Setters y getters
        public void setNumSerie(ulong numSerie)
        {
            this.numSerie = numSerie;
        }
        public void setDetalle(string detalle)
        {
            this.detalle = detalle;
        }
        public void setCostoC(float costoC)
        {
            this.costoC = costoC;
        }
        public void setCostoMO(float costoMO)
        {
            this.costoMO = costoMO;
        }
        public ulong getNumSerie()
        {
            return this.numSerie;
        }
        public string getdetalle()
        {
            return this.detalle;
        }
        public float getCostoC()
        {
            return this.costoC;
        }
        public float getCostoMO()
        {
            return this.costoMO;
        }
        
        public float darPrecio()
        {
            return getCostoC() + getCostoMO();
        }

        public virtual string darDatos()
        {
            return "\t Datos:"
                + "\n\t\t NumSerie: " + this.numSerie
                + "\n\t\t Detalle: " + this.detalle
                + "\n\t\t costoC: " + this.costoC
                + "\n\t\t costoMO:" + this.costoMO
                + "\n\t\t Precio Final: " + darPrecio();
        }

        public bool Equals(Componente other)
        {
            if (this.numSerie == other.getNumSerie()) { return true;  }
            return false;
        }

    }
}
