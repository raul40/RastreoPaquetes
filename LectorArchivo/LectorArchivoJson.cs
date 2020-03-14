using Newtonsoft.Json;
using RastreoPaquetes.Adapter;
using RastreoPaquetes.Adapter.Interfaces;
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
    public class LectorArchivoJson : iLectorArchivo
    {
        public List<DatosPedido> LeerArchivo(string _cRuta)
        {
            _cRuta += "Pedidos.json";
            if (File.Exists(_cRuta))
            {
                using (StreamReader r = new StreamReader(_cRuta))
                {
                    string json = r.ReadToEnd();
                    DatosPedidosJson items = JsonConvert.DeserializeObject<DatosPedidosJson>(json);
                    iPedidosAdapter PedidosAdapter = new PedidosJsonAdapter();
                    var lstDatos = PedidosAdapter.ObtenerDatosPedido(items);
                    return lstDatos;
                }
            }
            else
                throw new Exception("El archivo de datos no existe");
        }
    }
}
