using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Constructora
{
    internal class Controlador
    {
        List<Empleado> ListaEmpleados;
        List<Obra> ListaObras;
        
        public Controlador()
        {
            ListaEmpleados = new List<Empleado>();
            ListaObras = new List<Obra>();
        }

        public bool añadirEmpleado(string DNI, string nombre, string apellido, int estado, Especialidad especialidad )
        {
            foreach(Empleado empleado in ListaEmpleados)
            {
                if(empleado.getDNI()==DNI)
                {
                    return false;
                }
            }
            ListaEmpleados.Add(new Obrero(especialidad, DNI, nombre, apellido, estado));
            return true;
        }
        public bool añadirEmpleado(string DNI, string nombre, string apellido, int estado, uint matricula)
        {
            foreach (Empleado empleado in ListaEmpleados)
            {
                if (empleado.getDNI() == DNI)
                {
                    return false;
                }
            }
            ListaEmpleados.Add(new Capataz(matricula, DNI, nombre, apellido, estado));
            return true;
        }

        public bool añadirObra(string codigo, string calle, string provincia, string localidad, uint numero)
        {
            foreach(Obra obra in ListaObras)
            {
                if(obra.getCodigo()==codigo)
                {
                    return false;
                }
            }
            ListaObras.Add(new Obra(codigo, calle, provincia, localidad, numero));
            return true;
        }

        public bool asignarObrero (string codigo, string DNI)
        {
            foreach(Obra obra in ListaObras)
            {
                if(obra.getCodigo()==codigo)
                {
                    foreach(Empleado empleado in ListaEmpleados)
                    {

                        if(empleado.getDNI()==DNI && empleado is Obrero)
                        {
                            Obrero obrero = (Obrero)empleado;
                            obra.asignar(obrero);
                            obrero.setEstado(1);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool asignarCapataz(string codigo, string DNI)
        {
            foreach (Obra obra in ListaObras)
            {
                if (obra.getCodigo() == codigo)
                {
                    foreach (Empleado empleado in ListaEmpleados)
                    {
                        if (empleado.getDNI() == DNI && empleado is Capataz)
                        {
                            Capataz capataz = (Capataz)empleado;
                            obra.asignar(capataz);
                            capataz.setEstado(1);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public string listarObras()
        {
            string str="";
            uint I=1;
            foreach(Obra obra in ListaObras)
            {
                str += "\n Obra[" + I + "]:" + obra.darDatos();
                I++;
            }
            return str;
        }

        public string listarObreroObra(string codigo)
        {
            foreach(Obra obra in ListaObras)
            {
                if(obra.getCodigo()==codigo)
                {
                    return obra.listarObreros();
                }
            }
            return "OBRA NO ENCONTRADA";
        }
        public bool removerObrero(string codigo, string DNI)
        {
            foreach(Obra obra in ListaObras)
            {
                if(obra.getCodigo()==codigo)
                {
                    return obra.remover(DNI);
                }
            }
            return false;
        }
        public bool removerEmpleado(string DNI)
        {
            foreach(Empleado empleado in ListaEmpleados)
            {
                if(empleado.getDNI()==DNI)
                {
                    ListaEmpleados.Remove(empleado);
                    foreach(Obra obra in ListaObras)
                    {
                        obra.remover(DNI);
                    }
                    return true;
                }
            }
            return false;
        }

        public string listarEmpleados()
        {
            string str = "\n Lista Empleados:";
            int I = 1;
            ListaEmpleados.Sort();
            foreach(Empleado empleado in ListaEmpleados)
            {
                if(empleado is Capataz)
                {
                    Capataz capataz=(Capataz)empleado;
                    str += capataz.darDatos();
                }
                if(empleado is Obrero)
                {
                    Obrero obrero = (Obrero)empleado;
                    str += obrero.darDatos();
                }
            }
            return str;
        }

        public string guardarArchivo(string archivo)
        {
            string separador=";";
            StringBuilder salida = new StringBuilder();//Nos permite crear un string de forma dinamica añadiendo linea por linea utilizando appendline
            String[] encabezados = { "DNI", "Nombre", "Apellido" , "Estado", "Matricula/Especialidad"};
            salida.AppendLine(string.Join(separador, encabezados));
            foreach (Empleado empleado in ListaEmpleados)//Recorro toda la lista de datos 
            {
                if (empleado is Capataz)
                {
                    Capataz capataz = (Capataz)empleado;
                    string Estado="";
                    if(capataz.getEstado() == 0) { Estado = "Desocupado"; } else { Estado = "Ocupado"; }
                    string[] linea = { capataz.getDNI(), capataz.getNombre(), capataz.getApellido(), Estado, capataz.getMatricula().ToString() }; 
                    salida.AppendLine(string.Join(separador, linea));
                }
                if (empleado is Obrero)
                {
                    Obrero obrero = (Obrero)empleado;
                    string Estado = "";
                    if (obrero.getEstado() == 0) { Estado = "Desocupado"; } else { Estado = "Ocupado"; }
                    string[] linea = { obrero.getDNI(), obrero.getNombre(), obrero.getApellido(), Estado, obrero.GetEspecialidad().ToString() };
                    salida.AppendLine(string.Join(separador, linea));
                }
            }
            try
            {
                File.WriteAllText(archivo, salida.ToString());// File se encarga de crear el archivo y escribir todo lo que contenga salida
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;//retorna el error
            }
        }

        public string leerCSV(string archivo)
        {
            try
            {
                using(StreamReader reader=new StreamReader(archivo))//StreamReader se encarga de abrir al archivo y iniciar su lectura mediar el uso de readline
                {
                    string encabezado = reader.ReadLine(); // Leer la linea de encabezado, si existe

                    while(!reader.EndOfStream)//EndOfStream Va a tomando linea por linea y retorna null cuando llega al final
                    {
                        string linea = reader.ReadLine();
                        string[] valores = linea.Split(";"); // Separar los valores por el separador adecuado
                        if(valores.Length == 5)//Cantidad de columnos(varriables tiene el archivo
                        {
                            string DNI = valores[0];
                            string nombre = valores[1];
                            string apellido = valores[2];
                            string estado = valores[3];
                            string tipo = valores[4];
                            int Estado;
                            if(estado=="Desocupado")
                            {
                                Estado = 0;
                            }
                            else
                            {
                                Estado = 1;
                            }
                            if(validar_uint(tipo))
                            {
                                this.añadirEmpleado(DNI, nombre, apellido, Estado, uint.Parse(tipo));
                            }
                            else
                            {

                                this.añadirEmpleado(DNI, nombre, apellido, Estado, validar_especialidad(tipo));
                            }
                        }
                    }
                }
                return "ok";
            }
            catch( Exception ex)
            {
                return ex.Message;//retorna el error
            }

        }
        public bool validar_uint(string dato)
        {
            uint valor;
            bool respuesta=uint.TryParse(dato, out valor);
            return respuesta;
        }
        
        public Especialidad validar_especialidad(string dato)
        {
            if(dato=="Electricista")
            {
                return Especialidad.Electricista;
            }
            if(dato=="Albañil")
            {
                return Especialidad.Albañil;
            }
            if( dato=="Plomero")
            {
                return Especialidad.Plomero;
            }
            if(dato=="Pintor")
            {
                return Especialidad.Pintor;
            }
            else
            {
                return Especialidad.Herrero;
            }
            
        }
    }
}
