using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Xml;
using System.IO;


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

        public string guardarEnArchivo(string archivo)
        {
            string separador = ";";
            StringBuilder salida = new StringBuilder();
            String[] encabezados = { "CBU", "cliente", "saldo", "interes mensual" };
            salida.AppendLine(string.Join(separador,encabezados));
            foreach(Cuenta cuenta in listadoCuentas)
            {
                string[] linea = { cuenta.getCBU().ToString(), cuenta.getCliente(), cuenta.getSaldo().ToString(), Cuenta.InteresMensual.ToString() };
                salida.AppendLine(string.Join(separador, linea));
            }
            try
            {
                File.WriteAllText(archivo, salida.ToString());
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string guardarEnXML(string archivo)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);

                XmlElement rootElement = xmlDoc.CreateElement("Cuentas");
                xmlDoc.AppendChild(rootElement);

                foreach (Cuenta cuenta in listadoCuentas)
                {
                    XmlElement cuentaElement = xmlDoc.CreateElement("Cuenta");

                    XmlElement cbuElement = xmlDoc.CreateElement("CBU");
                    cbuElement.InnerText = cuenta.getCBU().ToString();
                    cuentaElement.AppendChild(cbuElement);

                    XmlElement clienteElement = xmlDoc.CreateElement("Cliente");
                    clienteElement.InnerText = cuenta.getCliente();
                    cuentaElement.AppendChild(clienteElement);

                    XmlElement saldoElement = xmlDoc.CreateElement("Saldo");
                    saldoElement.InnerText = cuenta.getSaldo().ToString();
                    cuentaElement.AppendChild(saldoElement);

                    XmlElement interesElement = xmlDoc.CreateElement("InteresMensual");
                    interesElement.InnerText = Cuenta.InteresMensual.ToString();
                    cuentaElement.AppendChild(interesElement);

                    rootElement.AppendChild(cuentaElement);
                }

                xmlDoc.Save(archivo);
                return "ok";
            }
            catch (Exception ex)
            {
                
                return ex.Message;
            }
        }

        public string leerXML(string archivo)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(archivo);

                XmlNodeList cuentaNodes = xmlDoc.SelectNodes("//Cuenta");
                List<Cuenta> listadoCuentas = new List<Cuenta>();

                foreach (XmlNode cuentaNode in cuentaNodes)
                {
                    ulong CBU = System.Convert.ToUInt64(cuentaNode.SelectSingleNode("CBU").InnerText);
                    string cliente = cuentaNode.SelectSingleNode("Cliente").InnerText;
                    float saldo = float.Parse(cuentaNode.SelectSingleNode("Saldo").InnerText);

                    this.crearCuenta(CBU,cliente,saldo);
                }

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string leerCSV(string archivo)
        {
            try
            {
                List<Cuenta> listadoCuentas = new List<Cuenta>();

                using (StreamReader reader = new StreamReader(archivo))
                {
                    string encabezado = reader.ReadLine(); // Leer la línea de encabezado si existe

                    while (!reader.EndOfStream)
                    {
                        string linea = reader.ReadLine();
                        string[] valores = linea.Split(';'); // Separar los valores por el separador adecuado

                        if (valores.Length == 4)
                        {
                            ulong CBU = System.Convert.ToUInt64(valores[0]);
                            string cliente = valores[1];
                            float saldo = float.Parse(valores[2]);
                            this.crearCuenta(CBU ,cliente,saldo);
                        }
                    }
                }

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
