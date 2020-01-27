using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Strategy
{
    public class RecuperarMensajeHoras : IRecuperarMensajeTiempoStrategy
    {
        private readonly TimeSpan tsTiempoTraslado;

        public RecuperarMensajeHoras(TimeSpan _tsTiempoTraslado)
        {
            tsTiempoTraslado = _tsTiempoTraslado;
        }

        public string ObtenerMensaje()
        {
            var iValor = tsTiempoTraslado.Hours;
            return iValor.ToString() + " " + ((iValor > 1) ? "horas" : "hora");
        }
    }
}
