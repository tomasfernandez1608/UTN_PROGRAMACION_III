using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    internal class Capataz:Empleado
    {
        uint matricula;

        public Capataz(uint matricula, string DNI, string apellido, string nombre,int estado)
            : base(DNI,apellido, nombre,estado)
        {
            this.matricula = matricula;
        }
        public Capataz() : base()
        {
            matricula = 000;
        }

        // Setters y getters

        public void setMatricula(uint matricula)
        {
            this.matricula = matricula;
        }
        public uint getMatricula()
        {
            return this.matricula;
        }

        //Dardatos

        public override string darDatos()
        {
            return base.darDatos()
                + "\n\t Matricula: " + this.matricula ;
        }



    }
}
