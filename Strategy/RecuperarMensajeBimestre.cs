using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Strategy
{
    public class RecuperarMensajeBimestre : IRecuperarMensajeTiempoStrategy
    {
        private readonly TimeSpan tsTiempoTraslado;

        public RecuperarMensajeBimestre(TimeSpan _tsTiempoTraslado)
        {
            tsTiempoTraslado = _tsTiempoTraslado;
        }

        public string ObtenerMensaje()
        {
            var iValor = (tsTiempoTraslado.Days / 31) / 2;
            return iValor.ToString() + " " + ((iValor > 1) ? "Bimestre" : "Bimestres");
        }
    }
}
