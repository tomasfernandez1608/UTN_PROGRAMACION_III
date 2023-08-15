using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTables;

namespace HashTables
{
    internal class Controlador
    {
        Hashtable diccionario;
       
        public Controlador()
        { 
            diccionario = new Hashtable();
        }

        public bool buscar(string palabra)
        {
            if(diccionario.ContainsKey(palabra))
            {
                return true;
            }
            
            return false;
        }
        public string buscarDefinicion(string palabra)
        {
            if(buscar(palabra))
            {
                return "" + diccionario[palabra];
            }
            return "No existe";
        }
        public bool agregarDefinicion(string palabra, string definicion)
        {
            if(buscar(palabra))
            {
                return false;
            }
            else
            {
                diccionario.Add(palabra, definicion);
                return true;
            }
        }
        public bool modificarDefinicion(string palabra, string definicion)
        {

            if (buscar(palabra))
            {
                diccionario[palabra] = definicion;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool eliminar(string palabra)
        {
            if (buscar(palabra))
            {
                diccionario.Remove(palabra);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
