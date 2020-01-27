using RastreoPaquetes.Generador.Interfaces;
using RastreoPaquetes.Repo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Generador
{
    public class GeneradorMensajeFuturo : IGeneradorMensaje
    {
        private readonly DatosPedido datos;
        private readonly string cMensajeTiempoTranscurrido;

        public GeneradorMensajeFuturo(DatosPedido _Datos, string _cMensajeTiempoTranscurrido)
        {
            datos = _Datos;
            cMensajeTiempoTranscurrido = _cMensajeTiempoTranscurrido;
        }

        public string ObtenerMensaje()
        {

            return string.Format("Tu paquete ha salido de {0} y llegará a {1} dentro de {2} y tendrá un costo de {3}(Cualquier reclamación con {4}).", datos.cOrigen, datos.cDestino, cMensajeTiempoTranscurrido, datos.dCostoEnvio.ToString(), datos.cPaqueteria);
        }
    }
}
