using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Strategy
{
    public class RecuperarMensajeAnios : IRecuperarMensajeTiempoStrategy
    {
        private readonly TimeSpan tsTiempoTraslado;

        public RecuperarMensajeAnios(TimeSpan _tsTiempoTraslado)
        {
            tsTiempoTraslado = _tsTiempoTraslado;
        }

        public string ObtenerMensaje()
        {
            var iValor = (tsTiempoTraslado.Days / 31) / 12;
            return iValor.ToString() + " " + ((iValor > 1) ? "Año" : "Años");
        }
    }
}
