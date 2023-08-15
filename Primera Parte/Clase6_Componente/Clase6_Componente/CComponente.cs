using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6_Componente
{
    internal class CComponente
    {
        ulong numSerie;
        string detalle;
        float costoC;
        float costoMO;

        public CComponente()
        {
            detalle = "A Definir";
        }

        public void setnumSerie(ulong numSerie)
        {
            this.numSerie = numSerie;
        }
        public ulong getnumSerie()
        {
            return numSerie;
        }
        public void setDetalle(string detalle)
        {
            this.detalle = detalle;
        }
        public string getdetalle()
        {
            return detalle;
        }
        public void setcostoC(float costoC)
        {
            this.costoC = costoC;
        }   
        public float getcostoC()
        {
            return costoC;
        }
        public void setcostoMO(float costoMO)
        {
            this.costoMO = costoMO;
        }
        public float setcostoMO()
        {
            return costoMO;
        }
        public float darPrecio()
        {
            return costoMO + costoC;
        }
        public string darDatos()
        {
            return "\n\t Numero de serie: " + numSerie +
                "\n\t Detalle: " + detalle + 
                "\n\t Costo C: " + costoC +
                "\n\t Costo MO: " + costoMO +
                "\n\t Precio a abonar: " + darPrecio();
        }

    }
}
