using Newtonsoft.Json;
using RastreoPaquetes.LectorArchivo.Interfaces;
using RastreoPaquetes.Repo.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.LectorArchivo
{
    public class LectorConfiguracionJson : iLectorConfiguracion
    {
        public DatosConfiguracion LeerConfiguracion(string _cRuta)
        {
            if (File.Exists(_cRuta))
            {
                using (StreamReader r = new StreamReader(_cRuta))
                {
                    string cJson = r.ReadToEnd();
                    //List<DatosConfiguracion> prueba = JsonConvert.DeserializeObject<List<DatosConfiguracion>>(cJson);
                    DatosConfiguracion entConfiguracion = JsonConvert.DeserializeObject<DatosConfiguracion>(cJson);
                    return entConfiguracion;
                }
            }
            else
                throw new Exception("No se encontro el archivo de configuración");
        }
    }
}
