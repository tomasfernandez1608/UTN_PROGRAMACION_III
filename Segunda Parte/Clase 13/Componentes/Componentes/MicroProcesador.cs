using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componentes
{
    internal class MicroProcesador:Componente
    {
        float FrecuenciaReloj;
        uint CantidadDeNucleos;
        MarcaProcesador marcaProcesador;

        // CC
        public MicroProcesador(float FrecuenciaReloj, uint CantidadDeNucleos, MarcaProcesador marcaProcesador
            , ulong numSerie, string detalle, float costoC, float costoMO) : base(numSerie, detalle, costoC, costoMO)
        {
            this.FrecuenciaReloj = FrecuenciaReloj;
            this.CantidadDeNucleos = CantidadDeNucleos;
            this.marcaProcesador=marcaProcesador;
        }
        public override string darDatos()
        {
            return base.darDatos() + 
                "\n\t\t FrecuenciaReloj: " + this.FrecuenciaReloj
                + "\n\t\t CantidadDeNucleos: " + this.CantidadDeNucleos
                + "\n\t\t MarcaProcesador: " + this.marcaProcesador.ToString();
        }

        public float getFrecuenciaReloj()
        {
            return this.FrecuenciaReloj;
        }
        public uint getCantidadDeNucleos()
        {
            return CantidadDeNucleos;
        }
        public MarcaProcesador getMarcaProcesador()
        {
            return marcaProcesador;
        }

        public void setFrecuenciaReloj(float FrecuenciaReloj)
        {
            this.FrecuenciaReloj = FrecuenciaReloj;
        }
        public void setCantidadDeNucleos(uint CantidadDeNucleos)
        {
            this.CantidadDeNucleos = CantidadDeNucleos;
        }
        public void setMarcaProcesador(MarcaProcesador marcaProcesador)
        {
            this.marcaProcesador = marcaProcesador;
        }

    }
}
