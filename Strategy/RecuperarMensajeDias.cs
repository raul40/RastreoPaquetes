using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Strategy
{
    public class RecuperarMensajeDias : IRecuperarMensajeTiempoStrategy
    {
        private readonly TimeSpan tsTiempoTraslado;

        public RecuperarMensajeDias(TimeSpan _tsTiempoTraslado)
        {
            tsTiempoTraslado = _tsTiempoTraslado;
        }

        public string ObtenerMensaje()
        {
            var iValor = tsTiempoTraslado.Days;
            return iValor.ToString() + " " + ((iValor > 1) ? "dias" : "dia");
        }
    }
}
