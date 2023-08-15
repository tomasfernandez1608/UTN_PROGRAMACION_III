using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    internal class Empleado:IComparable<Empleado>
    {
        string DNI;
        string apellido;
        string nombre;
        string estado;//0 Desocupado / 1 Ocupado


        //Constructores

        public Empleado (string DNI, string apellido, string nombre, int estado)
        {
            this.DNI = DNI;
            this.nombre = nombre;
            this.apellido = apellido;
            if (estado == 0) this.estado = "Desocupado";
            if (estado == 1) this.estado = "Ocupado";
        }
        public Empleado()
        {
            DNI = "Sin asignar";
            apellido = "NN";
            nombre = "NN";
        }

        //Setters y Getters 

        public void setDNI(string DNI)
        {
            this.DNI = DNI;
        }
        public string getDNI()
        {
            return this.DNI;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;

        }
        public string getNombre()
        {
            return this.nombre;
        }
        public void setApellido(string apellido)
        {
            this.apellido = apellido;
        }
        public string getApellido()
        {
            return this.apellido;
        }
        public void setEstado(int estado)
        {
            if (estado == 0) this.estado = "Desocupado";
            if (estado == 1) this.estado = "Ocupado";
        }
        public int getEstado()
        {
            if (this.estado == "Desocupado") return 0;
            else return 1;
        }
        //Icomparable
        public int CompareTo(Empleado empleado)
        {

            return this.DNI.CompareTo(((Empleado)empleado).getDNI());
        }

        public virtual string darDatos()
        {
            return "\nDatos:"
                + "\n\t DNI: " + this.DNI
                + "\n\t Nombre: " + this.nombre
                + "\n\t Apellido: " + this.apellido
                + "\n\t Estado:" + this.estado;
        }
    }
    
}
