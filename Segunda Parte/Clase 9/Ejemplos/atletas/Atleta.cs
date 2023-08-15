using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atletas
{
    class Atleta:IComparable, IEquatable<Atleta>
    {
        int numero;
        String nombre;
        String nacionalidad;
        float mejorTiempo;



        public Atleta(int numero, string nombre, string nacionalidad, float mejorTiempo)
        {
            this.Numero = numero;
            this.Nombre = nombre;
            this.nacionalidad = nacionalidad;
            this.MejorTiempo = mejorTiempo;
        }

        public float MejorTiempo { get => mejorTiempo; set => mejorTiempo = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Numero { get => numero; set => numero = value; }

        public int CompareTo(object obj)
        {
            if (obj is Atleta)
            {
                Atleta aux = (Atleta)obj;
                if (this.mejorTiempo < aux.mejorTiempo)
                {
                    return 1;
                }
                else
                {
                    if (this.mejorTiempo > aux.mejorTiempo) return -1;
                    else return 0;
                }
            }
            else
                return int.MaxValue;
        }


        public string DarDatos()
        {
            return "Atleta nro:" + numero.ToString() + " nombre:" + nombre + " nacionalidad:" + Nacionalidad  + " mejor tiempo: " + mejorTiempo.ToString() + " segundos";
        }

        public bool Equals(Atleta other)
        {
            if (this.numero == other.numero)
            {
                return true;
            }
            return false;
        }

    }
}
