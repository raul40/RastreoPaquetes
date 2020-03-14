using RastreoPaquetes.Adapter.Interfaces;
using RastreoPaquetes.Repo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Adapter
{
    public class PedidosJsonAdapter : iPedidosAdapter
    {
        public List<DatosPedido> ObtenerDatosPedido(DatosPedidosJson _lstDatosJson)
        {
            List<DatosPedido> lstDatosPedidos = new List<DatosPedido>();

            if (_lstDatosJson.Pedidos != null)
            {
                foreach (var item in _lstDatosJson.Pedidos)
                {
                    DatosPedido entDatos = new DatosPedido();
                    entDatos.cDestino = item.Destino;
                    entDatos.cOrigen = item.Procedencia;
                    entDatos.cMedioTransporte = item.MedioTrans;
                    entDatos.cPaqueteria = item.Empresa;
                    entDatos.dDistancia = item.Dist_KM;
                    //entDatos.dtFechaPedido = DateTime.ParseExact(item.FechaPedido, "dd-MM-yyyy HH:mm tt", null);
                    entDatos.dtFechaPedido = DateTime.Parse(item.FechaPedido);

                    lstDatosPedidos.Add(entDatos);
                }
            }
            

            return lstDatosPedidos;
        }
    }
}
