using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6_Aterrizar
{
    internal class Viaje
    {
        string Codigo, Origen, Destino;
        float Precio;
        public Viaje(string codigo, string origen, string destino, float precio)
        {
            Codigo = codigo;
            Origen = origen;
            Destino = destino;
            Precio = precio;
        }
        public Viaje() 
        {
            
        }
        public string GetOrigen()
        {
            return Origen;
        }
        public string GetDestino()
        {
            return Destino;
        }
        public string GetCodigo()
        {
            return Codigo;
        }
        public float PrecioViaje { get { return Precio; } set { Precio = value; } }

        public float darPrecio(int cuotas)
        {

            switch(cuotas)
            {
                case 0:
                    return Precio;
                case 3:
                    return Precio + Precio * 0.1F;
                case 6:
                    return Precio + Precio * 0.2f;
                case 12:
                    return Precio + Precio * 0.4f;
                
            }
            return -1;
        }
        public string darDatos()
        {
            return "\n\t Codigo:" + Codigo + "\n\t Origen: " + Origen
                + "\n\t Destino: " + Destino + "\n\t Precio: " + Precio;
        }
    }
}
