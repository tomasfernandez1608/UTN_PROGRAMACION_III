using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aterizar
{
    internal class Controlador
    {
        List<Paquete> ListaPaquetes;
        List<PaqueteEstadia> ListaEstadia;
        List<PaqueteAuto> ListaAuto;

        public Controlador()
        {
            ListaPaquetes= new List<Paquete>();
            ListaAuto = new List<PaqueteAuto>();
            ListaEstadia = new List<PaqueteEstadia>();
        }

        public bool buscar(string codigo)
        {
            int indice=ListaPaquetes.IndexOf(new Paquete(codigo));
            if(indice==-1)
            {
                return false;
            }
            else
            {
                return true;
            }
            /*
            foreach(Paquete paquete in ListaPaquetes)
            {
                if(paquete.getCodigo()==codigo)
                {
                    return true;
                }
            }
            foreach(PaqueteAuto paqueteAuto in ListaAuto)
            {
                if(paqueteAuto.getCodigo()==codigo)
                {
                    return true;
                }
            }
            foreach(PaqueteEstadia paqueteEstadia in ListaEstadia)
            {
                if(paqueteEstadia.getCodigo()==codigo)
                {
                    return true;
                }
            }

            return false;*/
        }

        public bool agregarPaqueteAuto(string Codigo, string Origen, string Destino, float Precio,
            string Patente, bool ContrataraSeguro, float CostoSeguro,uint CantidadDias, float CostoPorDia)
        {
            if(!buscar(Codigo))
            {
                ListaAuto.Add(new PaqueteAuto(Patente, ContrataraSeguro, CostoSeguro, CantidadDias, CostoPorDia
                    , Codigo, Origen, Destino, Precio));
                return true;
            }

            return false;
        }
        public bool agregarPaqueteEstadia(string Codigo, string Origen, string Destino, float Precio,
            string NombreHotel, uint CantidadNoches,float CostoHabitacion)
        {
            if (!buscar(Codigo))
            {
                ListaEstadia.Add(new PaqueteEstadia(NombreHotel, CantidadNoches, CostoHabitacion, Codigo, Origen
                    , Destino, Precio));
                return true;
            }

            return false;
        }
        public bool agregarPaquete(string Codigo, string Origen, string Destino, float Precio,
            string Patente, bool ContrataraSeguro, float CostoSeguro, uint CantidadDias, float CostoPorDia)
        {
            if (!buscar(Codigo))
            {
                ListaPaquetes.Add(new PaqueteAuto(Patente, ContrataraSeguro, CostoSeguro, CantidadDias, CostoPorDia
                    , Codigo, Origen, Destino, Precio));
                return true;
            }

            return false;
        }
        public bool agregarPaquete(string Codigo, string Origen, string Destino, float Precio,
            string NombreHotel, uint CantidadNoches, float CostoHabitacion)
        {
            if (!buscar(Codigo))
            {
                ListaPaquetes.Add(new PaqueteEstadia(NombreHotel, CantidadNoches, CostoHabitacion, Codigo, Origen
                    , Destino, Precio));
                return true;
            }

            return false;
        }

        public string ListarPaquetes()
        {
            string str = "";
            uint cont=1;
            this.ListaPaquetes.Sort();
            foreach(Paquete paquete in this.ListaPaquetes)
            {
                str += "\n Paquete[" + cont + "]: "
                    + "\n";
                if(paquete is PaqueteAuto)
                {
                    PaqueteAuto paqueteAuto = (PaqueteAuto)paquete;
                    str += paqueteAuto.darDatos();
                }
                if(paquete is PaqueteEstadia)
                {
                    PaqueteEstadia paqueteEstadia = (PaqueteEstadia)paquete;
                    str += paqueteEstadia.darDatos();
                }
                cont++;
            }
            return str;
        }

    }
}
