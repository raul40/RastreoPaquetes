using RastreoPaquetes.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Empresa
{
    public abstract class EmpresaAbstract
    {
        public decimal dDistancia;
        public DateTime dtFechaActual;
        public TimeSpan tsTiempoTraslado;
        public ITransporte entTransporte;
        decimal dMargenUtilidad { get; set; }

        public DateTime ObtenerFechaEntrega(DateTime _dtFechaPedido)
        {
            tsTiempoTraslado = entTransporte.ObtenerTiempoTraslado(dDistancia);
            var dtFechaEntrega = _dtFechaPedido.Add(tsTiempoTraslado);

            return dtFechaEntrega;
        }

        public decimal ObtenerCostoEnvio()
        {
            var dCostoEnvio = (entTransporte.dCostoKm * dDistancia) * (1 + (dMargenUtilidad / 100));
            return dCostoEnvio;
        }
    }
}
