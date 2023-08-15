using AppBancaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancaria
{
    internal class CajaAhorro:Cuenta
    {
        static float interesRetorno;
        string planCuenta;
        ulong tarjetaVinculada;

        public CajaAhorro(ulong CBU, string cliente, float saldo, string planCuenta, ulong tarjetaVinculada)
            : base(CBU,cliente,saldo)
        {
            this.planCuenta = planCuenta;
            this.tarjetaVinculada = tarjetaVinculada;
        }
        public CajaAhorro(ulong CBU, string cliente)
        {
            setCBU(CBU);
            setCliente(cliente);
        }

        //Setters y Getters

        public static void setinteresRetorno(float interesretorno)
        {
            interesRetorno = interesretorno;
        }
        public static float getinteresRetorno()
        {
            return interesRetorno;
        }

        public void setplanCuenta(string planCuenta)
        {
            this.planCuenta = planCuenta;
        }
        public string getplanCuenta()
        {
            return this.planCuenta;
        }

        public void settarjetaVinculada(ulong tarjetaVinculada)
        {
            this.tarjetaVinculada = tarjetaVinculada;
        }
        public ulong gettarjetaVinculada()
        {
            return tarjetaVinculada;
        }

        // Metodos_:

        public override string darDatos()
        {
            return base.darDatos()
                + "\n\t Plan de cuenta: " + planCuenta
                + "\n\t Tarjeta: " + tarjetaVinculada;
        }

        public float simularInteres(int meses)
        {
            return getSaldo() + getSaldo() * interesRetorno * meses;
        }
        
    }
}
