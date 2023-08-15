using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancaria
{
    class Cuenta: IComparable, IEquatable<Cuenta>
    {
        static float interesMensual;
        ulong CBU;
        string cliente;
        float saldo;

        public static void setinteresMensual(float interesmensual)
        {
            interesMensual=interesmensual/100;
        }
        public static float getinteresMensual()
        {
            return interesMensual;
        }

        /*CONSTUCTORES*/
        public Cuenta(ulong CBU, string cliente, float saldo)
        {
            this.CBU = CBU;
            this.cliente = cliente;
            this.saldo = saldo;
        }

        public Cuenta(ulong CBU, string cliente)
        {
            this.cliente = cliente;
            this.CBU = CBU;
            this.saldo = 0.0F;
        }
        public Cuenta()
        {
            cliente = "";
            CBU = 0;
            saldo = 0;
        }

        /*getters y setters*/
        public void setCBU(ulong CBU)
        {
            if (CBU >= 100 && CBU < 100000)
            {
                this.CBU = CBU;
            }
            else
            {
                this.CBU = 0;
            }
        }
        public void setCliente(string nombre)
        {
            cliente = nombre;
        }

        public void setSaldo(float saldo)
        {
            this.saldo = saldo;
        }

        public ulong getCBU()
        {
            return this.CBU;
        }
        public string getCliente()
        {
            return this.cliente;
        }
        public float getSaldo()
        {
            return this.saldo;
        }


        public virtual bool depositar(float monto)
        {
            if (monto <= 0)
            {
                return false;
            }
            else
            {
                this.saldo += monto;
            }
            return true;
        }

        public virtual bool extraer(float monto)
        {
            if (saldo < monto)
            {
                return false;
            }
            else
            {
                this.saldo -= monto;
                return true;
            }

        }

        public virtual string darDatos()
        {
            return "Nombre: " + this.cliente + ", CBU: " + this.CBU.ToString() + ", Saldo en cuenta: " + this.saldo.ToString();
        }

        public int CompareTo(object? obj)
        {
            if (obj is Cuenta)
            {
                Cuenta cuenta = (Cuenta)obj;
                if (this.CBU==cuenta.getCBU())
                {
                    return 0;
                }
                else
                {
                    if (this.CBU > cuenta.getCBU())// Para que muestre de mayor a menor "<" y para que muestre de menor a mayor ">"
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                return int.MaxValue;
            }
        }

        public bool Equals(Cuenta? other)
        {
            if (other != null && other.CBU == this.CBU)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
