using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase4_ejercicio_Viaje
{
    internal class viaje
    {
        private static ushort Kilometraje_min;
        private static float Costo_Kilometro;
        ushort Distancia_Recorrida;
        string Dominio;

        public static void setCosto(float costo)
        {
            Costo_Kilometro = costo;
        }
        public static float getCosto()
        {
            return Costo_Kilometro;
        }
        public static void setMin(ushort min)
        {
            Kilometraje_min = min;
        }
        public static ushort getMin()
        {
            return Kilometraje_min;
        }
        public viaje()
        {
            Dominio = "Sin Establecer";
        }
        public viaje(string Dominio, ushort Distancia_Recorrida)
        {
            this.Dominio = Dominio;
            this.Distancia_Recorrida = Distancia_Recorrida;
        }
        public void setDominio(string Dominio)
        {
            this.Dominio = Dominio;
        }
        public string getDominio()
        {
            return Dominio;
        }
        public ushort Kilometraje{ get { return Distancia_Recorrida; }set { Distancia_Recorrida = value; } }
        public float DarCostoViaje()
        {
            if(Distancia_Recorrida>Kilometraje_min)
            {
                return Distancia_Recorrida * Costo_Kilometro;
            }
            else
            {
                return Kilometraje_min * Costo_Kilometro;
            }
        }

        public float DarCostoViaje(float peaje)
        {
            return DarCostoViaje() + peaje;
        }

        public string DarDatos()
        {
            return "\nDOMINIO:" + Dominio + "\nDistancia_Recorrida: " + Distancia_Recorrida +
                "\nCosto: " + DarCostoViaje();
        }

        public static float CostoMayor(viaje viaje1, viaje viaje2)
        {
            if(viaje1.DarCostoViaje()>viaje2.DarCostoViaje())
            {
                return viaje1.DarCostoViaje();
            }
            else
            {
                return viaje2.DarCostoViaje();
            }
        }
    }
}
