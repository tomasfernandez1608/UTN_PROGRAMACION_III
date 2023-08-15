using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    internal class Obrero : Empleado
    {
        Especialidad especialidad;

        public Obrero(Especialidad especialidad, string DNI, string nombre, string apellido, int estado)
            : base(DNI, apellido, nombre, estado)
        {
            this.especialidad = especialidad;
        }

        public Obrero() : base()
        {

        }
        
        public void setEspecialidad(Especialidad especialidad)
        {
            this.especialidad = especialidad;
        }
        public Especialidad GetEspecialidad()
        {
            return this.especialidad;
        }

        public override string darDatos()
        {
            return base.darDatos()
                + "\n\t Especialidad: " + especialidad;
        }

    }
}
