using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_bancariaBien
{
    internal class ControladorCuentas
    {

        private List<Cuenta> listadoCuentas;

        public ControladorCuentas()
        {
            this.listadoCuentas = new List<Cuenta>();
        }

        public Cuenta buscar(ulong CBU)
        {
            int indice = listadoCuentas.IndexOf(new Cuenta(CBU, " "));
            if(indice == -1)
            {
                return null;
            }
            else
            {
                return listadoCuentas[indice];
            }
            /*
           foreach(Cuenta cuenta in this.listadoCuentas)
            {
                if (cuenta.getCBU() == CBU)
                {
                    return cuenta;
                }
            }
            return null;
            */
        }
        public bool crearCuenta(ulong CBU, string nombre, float saldoInicial)
        {
            if(this.buscar(CBU) == null) //o sea, no se encuentra una cuenta con ese CBU
            {
                this.listadoCuentas.Add(new Cuenta(CBU,nombre,saldoInicial));
                return true;
            }
            return false;
        }

        public bool extraer(ulong CBU, float monto)
        {
            Cuenta cuenta = this.buscar(CBU);
            if(cuenta == null)
            {
                return false;
            }
            else
            {
                return cuenta.extraer(monto);
            }
        }

       public bool depositar(ulong CBU,float monto)
        {
            Cuenta cuenta = this.buscar(CBU);
            if(cuenta == null)
            {
                return false;
            }
            else
            {
                return cuenta.depositar(monto);
            }
        }
        
        public string mostrarDatosCuenta(ulong CBU)
        {
            Cuenta cuenta = this.buscar(CBU);
            if( cuenta == null)
            {
                return "No existe la cuenta buscada.";
            }
            else
            {
                return cuenta.darDatos();
            }
        }

        public string mostrarListado()
        {
            string listado = "";
            this.listadoCuentas.Sort();
            //this.listadoCuentas.Reverse();
            foreach(Cuenta cuenta in this.listadoCuentas)
            {
                listado += cuenta.darDatos() + "\n";
            }
            return listado;
        }

        public bool eliminarCuenta(ulong CBU)
        {
            Cuenta cuenta = this.buscar(CBU);
            if(cuenta!= null)
            {
                this.listadoCuentas.Remove(cuenta);
                return true;
            }
            return false;
        }

        public float simularIntereses(int meses,ulong CBU)
        {
            Cuenta cuenta = this.buscar(CBU);
            if(cuenta != null)
            {
                Console.WriteLine(cuenta.darDatos());
                Console.WriteLine(cuenta.simularInteres(meses));
                return cuenta.simularInteres(meses);

            }
            else
            {
                return -1;
            }
        }

    }
}
