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
        public EmpresaAbstract Empresa;
        public EmpresaFactory(ITransporte _Transporte, DatosPedido _Datos)
        {
            Transporte = _Transporte;
            DatosPedido = _Datos;
        }

        public EmpresaAbstract ObtenerEmpresa(string _cEmpresa)
        {
            switch (_cEmpresa.ToUpper())
            {
                case "FEDEX":
                    Empresa = new Fedex(Transporte, DatosPedido.dDistancia, DatosPedido.dtFechaActual);
                    break;
                case "DHL":
                    Empresa = new DHL(Transporte, DatosPedido.dDistancia, DatosPedido.dtFechaActual);
                    break;
                case "ESTAFETA":
                    Empresa = new Estafeta(Transporte, DatosPedido.dDistancia, DatosPedido.dtFechaActual);
                    break;
                default:
                    throw new Exception(string.Format("La paquetería: {0} no se encuentra registrada en nuestra red de distribución", DatosPedido.cPaqueteria));
            }
            Empresa.entTransporte = Transporte;
            return Empresa;
        }
    }
}
