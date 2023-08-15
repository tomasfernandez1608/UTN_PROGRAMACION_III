using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componentes
{
    internal class PlacaDeVideo:Componente
    {
        uint RAM;
        float Frecuencia;
        MarcaPlaca MarcaPlaca;

        //Constructor
        public PlacaDeVideo(uint RAM,float Frecuencia, MarcaPlaca MarcaPlaca,ulong numSerie,string detalle
            ,float costoC, float costoMO) : base(numSerie,detalle,costoC,costoMO)
        {
            this.RAM = RAM;
            this.Frecuencia = Frecuencia;
            this.MarcaPlaca = MarcaPlaca;
        }
        public uint getRAM()
        {
            return this.RAM;
        }
        public float getFrecuencia()
        {
            return Frecuencia;
        }
        public MarcaPlaca GetMarcaPlaca()
        {
            return MarcaPlaca;
        }
        public override string darDatos()
        {
            return base.darDatos() +
                "\n\t\t RAM: " + this.RAM
                + "\n\t\t Frecuencia: " + this.Frecuencia
                + "\n\t\t MarcaPlaca: " + this.MarcaPlaca.ToString();
        }
        public void setRAM(uint RAM)
        {
            this.RAM = RAM;
        }
        public void setFrecuencia(float frecuencia)
        {
            this.Frecuencia = frecuencia;
        }
        public void setMarcaPlaca(MarcaPlaca marcaPlaca)
        {
            this.MarcaPlaca = marcaPlaca;
        }
    }
}
