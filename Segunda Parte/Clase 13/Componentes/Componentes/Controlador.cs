using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Componentes
{
    internal class Controlador
    {
        List<Componente> ListaComponentes;

        public Controlador()
        {
            ListaComponentes=new List<Componente>();
        }

        public Componente buscar(ulong numSerie)
        {
            foreach(Componente componente in ListaComponentes)
            {
                if(componente.getNumSerie() == numSerie)
                {
                    return componente;
                }
            }
            return null;
        }
        public bool agregar_placa(ulong numSerie, string detalle, float costoC, float costoMO
            ,uint RAM, float Frecuencia, MarcaPlaca marcaPlaca)
        {
            if(buscar(numSerie)==null)
            {
                ListaComponentes.Add(new PlacaDeVideo(RAM, Frecuencia, marcaPlaca, numSerie
                    , detalle, costoC, costoMO));
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool agregasCPU(ulong numSerie, string detalle, float costoC, float costoMO
            ,float FrecuenciaReloj, uint CantidadDeNucleos, MarcaProcesador marcaProcesador )
        {
            if(buscar(numSerie)==null)
            {
                ListaComponentes.Add(new MicroProcesador(FrecuenciaReloj, CantidadDeNucleos, marcaProcesador
                    , numSerie, detalle, costoC, costoMO));
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool quitar_componente(ulong numSerie)
        {

            foreach(Componente componente in ListaComponentes)
            {
                if(numSerie==componente.getNumSerie())
                {
                    ListaComponentes.Remove(componente);
                    return true;
                }
            }
            return false;
        }
        public bool modificar_micro(ulong numSerie, float FrecuenciaReloj, uint CantidadDeNucleos, MarcaProcesador marcaProcesador)
        {
            Componente componente = buscar(numSerie);
            if(componente is MicroProcesador)
            {
                MicroProcesador micro = (MicroProcesador)componente;
                micro.setCantidadDeNucleos(CantidadDeNucleos);
                micro.setMarcaProcesador(marcaProcesador);
                micro.setFrecuenciaReloj(FrecuenciaReloj);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool modificar_placa(ulong numSerie, uint RAM, float Frecuencia, MarcaPlaca marcaPlaca)
        {
            Componente componente = buscar(numSerie);
            if(componente is PlacaDeVideo)
            {
                PlacaDeVideo Placa = (PlacaDeVideo)componente;
                Placa.setMarcaPlaca(marcaPlaca);
                Placa.setFrecuencia(Frecuencia);
                Placa.setRAM(RAM);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string mostrarDatosLista()
        {
            string str = "Lista de Componente:";
            int I = 1;
            foreach(Componente componente in ListaComponentes)
            {
                if(componente is MicroProcesador)
                {
                    MicroProcesador microProcesador = (MicroProcesador)componente;
                    str += "\n\t Componente [" + I + "]"+ microProcesador.darDatos();
                    I++;
                }
                if(componente is PlacaDeVideo)
                {
                    PlacaDeVideo placaDeVideo = (PlacaDeVideo)componente;
                    str += "\n\t Componente [" + I + "]" + placaDeVideo.darDatos();
                    I++;
                }
            }
            return str;
        }
        public string CargarArchivoCPU(string archivo)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string encabezado = reader.ReadLine();

                    while(!reader.EndOfStream)
                    {
                        string linea = reader.ReadLine();
                        string[] valores = linea.Split(';');
                        if(valores.Length==7)
                        {
                            string numSerie = valores[0];
                            string detalle = valores[1];
                            string costo_componente = valores[2];
                            string costoMO = valores[3];
                            string FrecuenciaReloj = valores[4];
                            string nucleos = valores[5];
                            string marca_procesador = valores[6];
                            MarcaProcesador marcaProcesador = new MarcaProcesador();
                            switch(marca_procesador)
                            {
                                case "Intel":
                                    marcaProcesador = MarcaProcesador.Intel;
                                    break;
                                case "AMD":
                                    marcaProcesador = MarcaProcesador.AMD;
                                    break;
                            }
                            ListaComponentes.Add(new MicroProcesador(float.Parse(FrecuenciaReloj), uint.Parse(nucleos), marcaProcesador
                                , ulong.Parse(numSerie), detalle, float.Parse(costo_componente),float.Parse( costoMO)));
                        }
                    }
                }
                return "ok";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string CargarArchivoPlaca(string archivo)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string encabezado = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string linea = reader.ReadLine();
                        string[] valores = linea.Split(';');
                        if (valores.Length == 7)
                        {
                            string numSerie = valores[0];
                            string detalle = valores[1];
                            string costo_componente = valores[2];
                            string costoMO = valores[3];
                            string RAM = valores[4];
                            string Frecuencia = valores[5];
                            MarcaPlaca marcaPlaca = new MarcaPlaca();
                            switch(valores[6])
                            {
                                case "ATI":
                                    marcaPlaca = MarcaPlaca.ATI;
                                    break;
                                case "Nvidia":
                                    marcaPlaca = MarcaPlaca.Nvidia;
                                    break;
                            }
                            ListaComponentes.Add(new PlacaDeVideo(uint.Parse(RAM), float.Parse(Frecuencia)
                                , marcaPlaca, ulong.Parse(numSerie), detalle, float.Parse(costo_componente), float.Parse(costoMO)));
                        }
                    }
                }
                return "ok";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        
        public string GuardarArchivoP(string archivo)
        {
            string separador = ";";
            StringBuilder salida = new StringBuilder();
            String[] encabezados = { "Num_serie", "detalle", "costo_componente" , "costo_mano_de_obra" ,"ram_dedicada", "frecuencia", "marca_placa" };
            salida.AppendLine(string.Join(separador, encabezados));
            foreach(Componente componente in ListaComponentes)
            {

                if(componente is PlacaDeVideo)
                {
                    PlacaDeVideo placaDeVideo = (PlacaDeVideo)componente;
                    string[] linea = { placaDeVideo.getNumSerie().ToString(), placaDeVideo.getdetalle().ToString(), placaDeVideo.getCostoC().ToString(), 
                    placaDeVideo.getCostoMO().ToString(),  placaDeVideo.getRAM().ToString(), placaDeVideo.getFrecuencia().ToString(), placaDeVideo.GetMarcaPlaca().ToString()};
                    salida.AppendLine(string.Join(separador, linea));
                }
            }
            try
            {
                File.WriteAllText(archivo, salida.ToString());
                return "ok";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
     }
}
