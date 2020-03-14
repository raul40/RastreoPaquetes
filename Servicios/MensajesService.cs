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
            string cTipoTiempo = string.Empty;
            string cTiempoEntrega = string.Empty;
            AlmacenadorDatosService srvAlmacenador = new AlmacenadorDatosService();
            IRecuperarMensajeTiempoStrategy RecuperadorMensajeTiempoStrategy;
            IGeneradorMensaje GeneradorMensaje;
            if (Datos.tsTiempoTraslado.Days / 31 > 12)
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeAnios(Datos.tsTiempoTraslado);
                cTipoTiempo = "Años";
            }
            if (Datos.tsTiempoTraslado.Days / 31 > 2 && Datos.tsTiempoTraslado.Days / 31 < 12)
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeBimestre(Datos.tsTiempoTraslado);
                cTipoTiempo = "Bimestre";
            }
            if (Datos.tsTiempoTraslado.Days / 31 > 0 && Datos.tsTiempoTraslado.Days / 31 < 2)
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeMeses(Datos.tsTiempoTraslado);
                cTipoTiempo = "Meses";
            }
            else if (Datos.tsTiempoTraslado.Days > 0)
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeDias(Datos.tsTiempoTraslado);
                cTipoTiempo = "Dias";
            }
            else if (Datos.tsTiempoTraslado.Hours > 0)
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeHoras(Datos.tsTiempoTraslado);
                cTipoTiempo = "Horas";
            }
            else
            {
                RecuperadorMensajeTiempoStrategy = new RecuperarMensajeMinutos(Datos.tsTiempoTraslado);
                cTipoTiempo = "Minutos";
            }

            string cMensajeTiempo = RecuperadorMensajeTiempoStrategy.ObtenerMensaje();

            if (Datos.dtFechaEntrega < Datos.dtFechaActual)
            {
                GeneradorMensaje = new GeneradorMensajePasado(Datos, cMensajeTiempo);
                new TextoVerde().ObtenerColor();
                cTiempoEntrega = "Entregados";
            }
            else
            {
                GeneradorMensaje = new GeneradorMensajeFuturo(Datos, cMensajeTiempo);
                new TextoAmarillo().ObtenerColor();
                cTiempoEntrega = "Pendientes";
            }

            cMensaje = GeneradorMensaje.ObtenerMensaje();
            srvAlmacenador.AlmacenarDatosArchivo(cMensaje, cTipoTiempo, cTiempoEntrega, Datos.cPaqueteria);
            Console.WriteLine(cMensaje);
        }
    }
}
