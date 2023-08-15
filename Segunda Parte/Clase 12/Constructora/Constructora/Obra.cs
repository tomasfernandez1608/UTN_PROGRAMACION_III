using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    internal class Obra
    {
        string codigo;
        Direccion direccion;
        Capataz capataz;
        List<Obrero> obreros;

        public Obra(string codigo, string calle, string provincia, string localidad,
            uint numero)
        {
            this.codigo = codigo;
            this.direccion = new Direccion(calle, localidad, provincia, numero);
            this.obreros = new List<Obrero>();
            this.capataz=new Capataz();
        }

        public string getCodigo()
        {
            return this.codigo;
        }

        public bool buscarO(string DNI)
        {
            foreach(Obrero obrero in obreros)
            {
                if(obrero.getDNI()==DNI)
                {
                    return true;
                }

            }
            return false;
        }

        public bool asignar(Obrero obrero)
        {
            if(obrero is Obrero && !buscarO(obrero.getDNI()))
            {
                obreros.Add( new Obrero (obrero.GetEspecialidad(),obrero.getDNI()
                    ,obrero.getNombre(),obrero.getApellido(),obrero.getEstado()));
                return true;
            }
            return false;
        }
        public bool asignar(Capataz capataz)
        {
            if(capataz is Capataz)
            {
                this.capataz = capataz;
                return true;
            }
            return false;
        }

        public string darDatos()
        {
            return "\n Datos Obra[" + this.codigo + "] :"
                + "\n\t Dirrecion: " + direccion.darDatos()
                + "\n\t Capataz: " + capataz.darDatos();
                
        }

        public string listarObreros()
        {
            string str = "";
            int I = 1;
            obreros.Sort();
            foreach(Obrero obrero in obreros)
            {
                str += "\n Obrero[" + I + "]" + obrero.darDatos();
                I++;
            }
            return str;
        }

        public bool remover(string DNI)
        {
            foreach (Obrero obrero in obreros)
            {
                if(obrero.getDNI()==DNI)
                {
                    obreros.Remove(obrero);
                    obrero.setEstado(0);
                    return true;
                }
            }
            return false;
        }

    }
}
