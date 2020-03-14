using RastreoPaquetes.Factory.Interfaces;
using RastreoPaquetes.Repo.DTO;
using RastreoPaquetes.Repo.Empresa;
using RastreoPaquetes.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Factory
{
    public class EmpresaFactory : IEmpresaFactory
    {
        private readonly ITransporte Transporte;
        private readonly DatosPedido DatosPedido;
        private readonly DatosConfiguracion entDatosConfig;
        public EmpresaAbstract Empresa;
        public EmpresaFactory(ITransporte _Transporte, DatosPedido _Datos, DatosConfiguracion _entDatosConfig)
        {
            Transporte = _Transporte;
            DatosPedido = _Datos;
            entDatosConfig = _entDatosConfig;
        }

        public EmpresaAbstract ObtenerEmpresa(string _cEmpresa)
        {
            Paqueterias entPaqueteria;
            switch (_cEmpresa.ToUpper())
            {
                case "FEDEX":
                    entPaqueteria = entDatosConfig.Paqueterias.Where(w => w.Paqueteria.ToUpper() == "FEDEX").FirstOrDefault();
                    Empresa = new Fedex(Transporte, DatosPedido.dDistancia, DatosPedido.dtFechaActual, entPaqueteria);
                    break;
                case "DHL":
                    entPaqueteria = entDatosConfig.Paqueterias.Where(w => w.Paqueteria.ToUpper() == "DHL").FirstOrDefault();
                    Empresa = new DHL(Transporte, DatosPedido.dDistancia, DatosPedido.dtFechaActual, entPaqueteria);
                    break;
                case "ESTAFETA":
                    entPaqueteria = entDatosConfig.Paqueterias.Where(w => w.Paqueteria.ToUpper() == "ESTAFETA").FirstOrDefault();
                    Empresa = new Estafeta(Transporte, DatosPedido.dDistancia, DatosPedido.dtFechaActual, entPaqueteria);
                    break;
                default:
                    throw new Exception(string.Format("La paquetería: {0} no se encuentra registrada en nuestra red de distribución", DatosPedido.cPaqueteria));
            }
            Empresa.entTransporte = Transporte;
            return Empresa;
        }
    }
}
