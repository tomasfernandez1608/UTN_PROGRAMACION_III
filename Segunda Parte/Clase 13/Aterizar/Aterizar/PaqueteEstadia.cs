using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aterizar
{
    internal class PaqueteEstadia:Paquete
    {
        string NombreHotel;
        uint CantidadNoches;
        float CostoHabitacion;

        public PaqueteEstadia(string nombreHotel, uint cantidadNoches, float costoHabitacion, string Codigo,
            string Origen, string destino, float Precio) : base(Codigo, Origen, destino,Precio)
        {
            NombreHotel = nombreHotel;
            CantidadNoches = cantidadNoches;
            CostoHabitacion = costoHabitacion;
        }

        public void setNombreHotel(string NombreHotel)
        {
            this.NombreHotel = NombreHotel;
        }
        public void setCantidadNoches(uint CantidadNoches)
        {
            this.CantidadNoches = CantidadNoches;
        }
        public void setCostoHabitacion(float CostoHabitacion)
        {
            this.CostoHabitacion = CostoHabitacion;
        }
        public string getNombreHotel()
        {
            return this.NombreHotel;
        }
        public uint getCantidadNoches()
        {
            return this.CantidadNoches;
        }
        public float getCostoHabitacion()
        {
            return this.CostoHabitacion;
        }
        public override float darPrecio(int cuotas)
        {
            return base.darPrecio(cuotas) + CostoHabitacion*CantidadNoches;
        }
        public override string darDatos()
        {
            return base.darDatos()
                + "\n\t Nombre Hotel: " + this.NombreHotel
                + "\n\t Cantidad Noches: " + this.CantidadNoches
                + "\n\t Costo Habitacion: " + this.CostoHabitacion;
        }
    }
}
