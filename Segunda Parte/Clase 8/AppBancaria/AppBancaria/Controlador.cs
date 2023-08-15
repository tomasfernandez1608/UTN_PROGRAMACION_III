using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancaria
{
    internal class Controlador
    {
        private List<Cuenta> Listadocuentas;
        public Controlador()
        {
            Listadocuentas = new List<Cuenta>();
        }
        public Cuenta Buscar(ulong CBU)
        {
            int indice = Listadocuentas.IndexOf(new Cuenta(CBU, " "));
            if (indice == -1)
            {
                return null;
            }
            else
            {
                return Listadocuentas[indice];
            }
            /*
            foreach (Cuenta cuenta in Listadocuentas)
            {
                if(cuenta.getCBU()==CBU)
                {
                    return cuenta;
                }
            }
            return null;*/
        }
        public bool agregarCuenta(ulong CBU, string Cliente, float Saldo)
        {
            if(Buscar(CBU)==null)
            {
                Listadocuentas.Add( new Cuenta(CBU,Cliente,Saldo));
                return true;
            }
            return false;
        }
        public bool deposito(ulong CBU,float depositar)
        {
            Cuenta CuentaEncontrada = Buscar(CBU);
            if(CuentaEncontrada!=null)
            {
                CuentaEncontrada.depositar(depositar);
                return true;
            }
            return false;
        }
        public bool extraccion(ulong CBU, float extraccion)
        {
            Cuenta CuentaEncontrada = Buscar(CBU);
            if(CuentaEncontrada != null)
            {
                CuentaEncontrada.extraer(extraccion); return true;
            }
            return false;
        }
        public string darDatosCBU (ulong CBU)
        {
            Cuenta CuentaEncontrada = Buscar(CBU);
            if (CuentaEncontrada != null)
            {
                return CuentaEncontrada.darDatos();
            }
            return "NO SE ENCONTRO LA CUENTA CON CBU = " + CBU;
        }
        public string darDatosTodos()
        {
            string str="";
            this.Listadocuentas.Sort(); 
            int I = 1;
            foreach(Cuenta cuenta in Listadocuentas)
            {
                str += "\n Cuenta "+ I + " :\n\t" + cuenta.darDatos();
                I++;
            }
            return str;
        }
        public bool eliminarCuenta(ulong CBU)
        {
            Cuenta cuentaEncontrada=Buscar(CBU) ;
            if(cuentaEncontrada != null)
            {
                Listadocuentas.Remove(cuentaEncontrada);
                return true;
            }
            return false;
        }
        public void setInteresMensual(float interesM)
        {
            Cuenta.setinteresMensual(interesM);
        }

        public string getSaldoFinal(ulong CBU, int meses)
        {
            float saldofinal;
            Cuenta cuentaencontrada = Buscar(CBU);
            if(cuentaencontrada!=null)
            {
                saldofinal = cuentaencontrada.getSaldo() + ( Cuenta.getinteresMensual() * cuentaencontrada.getSaldo() ) * meses;
                return "SaldoFinal:" + saldofinal;
            }
            else
            {
                return "No se encontro la cuenta " + CBU + "\n Verifique si el cbu fue ingresado correctamente";
            }

        }

    }
}
