using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Strategy
{
    public class RecuperarMensajeMinutos : IRecuperarMensajeTiempoStrategy
    {
        private readonly TimeSpan tsTiempoTraslado;

        public RecuperarMensajeMinutos(TimeSpan _tsTiempoTraslado)
        {
            tsTiempoTraslado = _tsTiempoTraslado;
        }

        public string ObtenerMensaje()
        {
            var iValor = tsTiempoTraslado.Minutes;
            return iValor.ToString() + " " + ((iValor > 1) ? "minutos" : "minuto");
        }
    }
}
