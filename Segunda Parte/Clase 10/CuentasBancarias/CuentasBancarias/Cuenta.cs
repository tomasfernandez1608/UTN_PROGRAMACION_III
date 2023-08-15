using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasBancarias
{
    internal class Cuenta: IComparable, IEquatable<Cuenta>
    {
        ulong CBU;
        string cliente;
        float saldo;
        
        public Cuenta(ulong CBU, string cliente, float saldo)
        {
            this.CBU = CBU;
            this.cliente = cliente; 
            this.saldo = saldo;
        }
        public Cuenta()
        {
            CBU = 0;
            cliente = "";
            saldo = 0;
        }
        // Getters y Setters
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
            if (monto > 0)
            {
                saldo += monto;
            }
            return false;
        }
        public virtual bool extraer(float monto)
        {
            if(monto>saldo)
            {
                return false;
            }
            else
            {
                saldo -= monto;
                return true;
            }
        }
        public virtual string darDatos()
        {
            return "\n Datos:"
                + "\n\t CBU: " + this.CBU
                + "\n\t Cliente: " + this.cliente
                + "\n\t Saldo: " + this.saldo;
        }
        public int CompareTo(object other)
        {
            if(other is Cuenta)
            {
                Cuenta cuenta= (Cuenta)other;
                if (this.saldo == cuenta.getSaldo()) return -1;
                if (this.saldo > cuenta.getSaldo()) return 1;
                if(this.saldo>cuenta.getSaldo()) return 0;
            }
            return int.MaxValue;
        }
        public bool Equals(Cuenta other)
        {
            if(this.getCBU() == other.getCBU()) return true;
            return false;
        }
    }
}
