using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase5_Ejercicio3_Productos
{
    class Producto
    {
        string ID;
        string Descripcion;
        float PrecioUnitario;
        bool EnPromocion;
        float DescuentoPromocion;

        public Producto(string ID, string Descripcion, float Precio)
        {
            this.ID = ID;
            this.Descripcion = Descripcion;
            PrecioUnitario = Precio;
            this.EnPromocion = false;
            this.DescuentoPromocion = 0;
        }

        public Producto()
        {
            this.ID = "";
            this.Descripcion = "";
            PrecioUnitario = 0;
            this.EnPromocion = false;
            this.DescuentoPromocion = 0;
        }

        public string getID()
        {
            return ID;
        }
        public string getDescripcion()
        {
            return Descripcion;
        }
        public float getPrecioUnitario()
        {
            return PrecioUnitario;
        }
        public bool getEnPromocion()
        {
            return EnPromocion;
        }
        public float getDescuentoPromocion()
        {
            return DescuentoPromocion;
        }

        public void setID(string ID)
        {
            this.ID = ID;
        }
        public void setDescripcion(string Descripcion)
        {
            this.Descripcion = Descripcion;
        }
        public void setEnPromocion(bool promocion)
        {
            this.EnPromocion = promocion;
        }
        public void setDescuentoPromocion(float descuento)
        {
            this.DescuentoPromocion = descuento / 100;
        }

        public void ConfigurarPromocion(float descuento) //30 o 0.30??
        {
            if (EnPromocion == false)
            {
                EnPromocion = true;
            }
            this.DescuentoPromocion = descuento / 100;

        }

        public float DarPrecioFinal(int cantidad)
        {
            float precioFinal = PrecioUnitario * cantidad;
            if (EnPromocion == true)
            {
                precioFinal = precioFinal - calcularDescuento(precioFinal);
            }
            return precioFinal;

        }

        public float calcularDescuento(float precio)
        {
            return precio * this.DescuentoPromocion;
        }

        public string mostrarDatos()
        {
            if (EnPromocion == true)
            {
                return "ID " + ID + ". Descripcion " + Descripcion + ". Precio unitario " + PrecioUnitario.ToString() + ". Descuento " + DescuentoPromocion.ToString();
            }
            else
            {
                return "ID " + ID + ". Descripcion " + Descripcion + ". Precio unitario " + PrecioUnitario.ToString() + ". No esta en promocion";
            }
        }

        public int compararCon(Producto n)
        {
            if (this.PrecioUnitario > n.PrecioUnitario)
            {
                return 1;
            }
            if (this.PrecioUnitario < n.PrecioUnitario)
            {
                return -1;
            }
            return 0;
        }
    }
}
