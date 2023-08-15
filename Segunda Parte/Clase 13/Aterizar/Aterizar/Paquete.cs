using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aterizar
{
    internal class Paquete:IComparable,IEquatable<Paquete>
    {
        static float Interes;
        string Codigo;
        string Origen;
        string Destino;
        float Precio;

        public Paquete(string Codigo)
        {
            this.Codigo=Codigo;
        }

        public Paquete (string codigo, string origen, string destino, float Precio)
        {
            Codigo = codigo;
            Origen = origen;
            Destino = destino;
            this.Precio = Precio;
        }
        public float PrecioViaje { get { return Precio; } set { Precio = value; } }

        public static void setInteres(float interes)
        {
            Interes = interes;
        }
        public static float getInteres()
        {
            return Interes;
        }
        public string getCodigo()
        {
            return this.Codigo;
        }
        public virtual float darPrecio(int cuotas)
        {
            return Precio + Precio * (Interes * cuotas);
        }
        public virtual string darDatos()
        {
            return "\n\t Codigo: " + this.Codigo +
                "\n\t Origen: " + this.Origen
                +"\n\t Destino: " +this.Destino
                +"\n\t Precio: "+ this.Precio;
        }
        public int CompareTo(object other)
        { 
            if(other is Paquete)
            {
                Paquete paquete = (Paquete)other;
                if(this.Codigo == paquete.Codigo)
                {
                    return 0;
                }
                else
                {// Para que muestre de mayor a menor "<" y para que muestre de menor a mayor ">"
                    if (int.Parse(this.Codigo) > int.Parse(paquete.Codigo))
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                
            }
            else
            {
                return int.MaxValue;
            }
        }
        public bool Equals(Paquete other)
        {
            if(this.Codigo == other.Codigo)
            {
                return true;
            }
            else { return false; }
        }
    }
}
