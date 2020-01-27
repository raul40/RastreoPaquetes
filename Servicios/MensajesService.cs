using RastreoPaquetes.Generador;
using RastreoPaquetes.Generador.Interfaces;
using RastreoPaquetes.Interfaz;
using RastreoPaquetes.Interfaz.Interfaces;
using RastreoPaquetes.Repo.DTO;
using RastreoPaquetes.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Servicios
{
    public class MensajesService
    {
        private readonly DatosPedido Datos;

        public MensajesService(DatosPedido _Datos)
        {
            Datos = _Datos;
        }

        public void GenerarMensaje()
        {
            string cMensaje = string.Empty;
            IRecuperarMensajeTiempoStrategy RecuperadorMensajeTiempoStrategy;
            IGeneradorMensaje GeneradorMensaje;
            if (Datos.tsTiempoTraslado.Days / 31 > 0)
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeMeses(Datos.tsTiempoTraslado);
            }
            else if (Datos.tsTiempoTraslado.Days > 0)
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeDias(Datos.tsTiempoTraslado);
            }
            else if (Datos.tsTiempoTraslado.Hours > 0)
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeHoras(Datos.tsTiempoTraslado);
            }
            else
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeMinutos(Datos.tsTiempoTraslado);
            }

            string cMensajeTiempo = RecuperadorMensajeTiempoStrategy.ObtenerMensaje();

            if (Datos.dtFechaEntrega < Datos.dtFechaActual)
            {
                GeneradorMensaje = new GeneradorMensajePasado(Datos, cMensajeTiempo);
                new TextoVerde().ObtenerColor();
            }
            else
            {
                GeneradorMensaje = new GeneradorMensajeFuturo(Datos, cMensajeTiempo);
                new TextoAmarillo().ObtenerColor();
            }

            cMensaje = GeneradorMensaje.ObtenerMensaje();
            Console.WriteLine(cMensaje);
        }
    }
}
