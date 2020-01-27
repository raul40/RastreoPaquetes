using RastreoPaquetes.Factory;
using RastreoPaquetes.Factory.Interfaces;
using RastreoPaquetes.Interfaz;
using RastreoPaquetes.Interfaz.Interfaces;
using RastreoPaquetes.Repo.DTO;
using RastreoPaquetes.Repo.Empresa;
using RastreoPaquetes.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Servicios
{
    public class EmpresaTransporteService
    {
        private readonly List<DatosPedido> lstDatosPedido;

        public EmpresaTransporteService(List<DatosPedido> _lstDatosPedido)
        {
            lstDatosPedido = _lstDatosPedido;
        }

        public void ObtenerResultado()
        {
            EmpresaFactory FabricaEmpresa;
            MensajesService srvMensajes;
            ITransporteFactory FabricaTransporte = new TransporteFactory();
            IColorTexto colorTextoError = new TextoRojo();
            foreach (var item in lstDatosPedido)
            {
                try
                {
                    item.dtFechaActual = DateTime.Now;
                    ITransporte entTransporte = FabricaTransporte.ObtenerTransporte(item.cMedioTransporte);
                    FabricaEmpresa = new EmpresaFactory(entTransporte, item);
                    EmpresaAbstract Empresa = FabricaEmpresa.ObtenerEmpresa(item.cPaqueteria);
                    item.dtFechaEntrega = Empresa.ObtenerFechaEntrega(item.dtFechaPedido);
                    item.tsTiempoTraslado = Empresa.tsTiempoTraslado;
                    item.dCostoEnvio = Empresa.ObtenerCostoEnvio();
                    srvMensajes = new MensajesService(item);
                    srvMensajes.GenerarMensaje();
                }
                catch (Exception ex)
                {
                    colorTextoError.ObtenerColor();
                    if (string.IsNullOrWhiteSpace(ex.Message))
                    {
                        Console.WriteLine(string.Format("{0} no ofrece el servicio de transporte {1}, te recomendamos cotizar en otra empresa", item.cPaqueteria, item.cMedioTransporte));
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                
            }
        }
    }
}
