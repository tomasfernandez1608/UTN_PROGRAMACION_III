using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasBancarias
{
    internal class CuentaCorriente:Cuenta
    {
        static float montoDescubierto;
        float interesDescubierto;


        //Constructores
        public CuentaCorriente(ulong CBU, string cliente, float saldo, float interesDescubierto)
            : base(CBU,cliente,saldo)
        {
            this.interesDescubierto = interesDescubierto;
        }
        public CuentaCorriente(ulong CBU, string cliente)
        {
            this.interesDescubierto = 0;
        }
        // Getters y Setters

        public void setinteresDescubierto(float interesDescubierto)
        {
            this.interesDescubierto = interesDescubierto;
        }
        public float getinteresDescubierto()
        {
            return this.interesDescubierto;
        }
        public static void setmontoDescubierto(float montodescubierto)
        {
            montoDescubierto = montodescubierto;
        }
        public static float getmontoDescubierto()
        {
            return montoDescubierto;
        }

        //DEPOSITAR

        public override bool depositar(float monto)
        {
            if (monto > 0)
            {
                float saldo = getSaldo();
                if(saldo<0)
                {
                    monto -= saldo * interesDescubierto;
                    setSaldo(saldo + monto);
                    return true;
                }
                else 
                {
                    setSaldo(saldo + monto);
                    return true;
                }
            }
            return false;
        }
        public override bool extraer(float monto)
        {
            if(monto > 0 && monto <= (getSaldo() + montoDescubierto))
            {
                setSaldo(getSaldo() - monto);
                return true;
            }
            return false;
        }
        public override string darDatos()
        {
            return base.darDatos()
                + "\n\t Interese en descubierto: " + this.interesDescubierto;
        }
    }
}
