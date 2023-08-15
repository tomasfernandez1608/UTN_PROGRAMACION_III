using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_bancariaBien
{
    class Cuenta:IComparable,IEquatable<Cuenta>
    {
        ulong CBU;
        string cliente;
        float saldo;
        static float interesMensual;
        public static float InteresMensual { get { return interesMensual; } set { interesMensual = value / 100; } }
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

         
        public bool depositar(float monto){
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

        public bool extraer(float monto)
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

        public string darDatos()
        {
            return "Nombre: " + this.cliente + ", CBU: " + this.CBU.ToString() + ", Saldo en cuenta: " + this.saldo.ToString(); 
        }

        public float simularInteres(int meses)
        {
            if ( InteresMensual !=0)
            {
                return saldo + InteresMensual * meses * saldo;
            }

            return 0;
        }

        public int CompareTo(object? obj)
        {
            if(obj is Cuenta)
            {
                Cuenta cuenta = (Cuenta)obj;
                if(this.saldo == cuenta.saldo)
                {
                    return 0;
                }
                else
                {
                    if (this.saldo>cuenta.saldo)
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
                if(other != null && other.CBU == this.CBU)
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
