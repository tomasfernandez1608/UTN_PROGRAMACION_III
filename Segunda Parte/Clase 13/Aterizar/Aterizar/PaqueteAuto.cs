using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aterizar
{
    internal class PaqueteAuto:Paquete
    {
        string Patente;
        bool ContraraSeguro;
        float CostoSeguro;
        uint CantidadDias;
        float CostoPorDia;

        public PaqueteAuto(string patente, bool contraraSeguro, float costoSeguro, uint cantidadDias, float costoPorDia
            , string codigo, string origen, string destino, float Precio) : base(codigo,origen,destino,Precio)
        {
            Patente = patente;
            ContraraSeguro = contraraSeguro;
            CostoSeguro = costoSeguro;
            CantidadDias = cantidadDias;
            CostoPorDia = costoPorDia;
        }

        public void setPatente(string Patente)
        {
            this.Patente = Patente;
        }
        public void setContratarSeguro(bool ContratarSeguro)
        {
            this.ContraraSeguro = ContraraSeguro;
        }
        public void setCostoSeguro(float CostoSeguro)
        {
            this.CostoSeguro = CostoSeguro;
        }
        public void setCantidadDias(uint CantidadDias)
        {
            this.CantidadDias = CantidadDias;
        }
        public void setCostoPorDia(float CostoPorDia)
        {
            this.CostoPorDia = CostoPorDia;
        }
        public string getPatente()
        {
            return this.Patente;
        }
        public bool getContrataSeguro()
        {
            return this.ContraraSeguro;
        }
        public float getCostoSeguro()
        {
            return this.CostoSeguro;
        }
        public uint getCantidadDeDias()
        {
            return this.CantidadDias;
        }
        public float getCostoPorDia()
        {
            return this.CostoPorDia;
        }
        public override string darDatos()
        {
            return base.darDatos()
                + "\n\t Patente:" +this.Patente
                + "\n\t Contrata seguro: " + this.ContraraSeguro
                + "\n\t Precion de seguro: " + this.CostoSeguro
                + "\n\t CantidadDias: " + this.CantidadDias
                + "\n\t Costo por dia: " + this.CostoPorDia;
        }
        public override float darPrecio(int cuotas)
        {
            float PrecioFinal=0;
            if(ContraraSeguro)
            {
                PrecioFinal += CostoSeguro;
            }
            PrecioFinal += CostoPorDia * CantidadDias;
            return base.darPrecio(cuotas) + PrecioFinal;
        }
    }
}
