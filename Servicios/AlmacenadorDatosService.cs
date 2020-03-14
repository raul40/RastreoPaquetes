using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Servicios
{
    public class AlmacenadorDatosService
    {
        public void CrearDirectorioDatos()
        {
            string cRuta = AppDomain.CurrentDomain.BaseDirectory + @"..\..\Datos";
            EliminarDirectorioDatos(cRuta);
            CrearDirectorio(cRuta);
        }

        public void AlmacenarDatosArchivo(string _cMensaje, string _cTipoTiempo, string _cTiempoEntrega, string _cPaqueteria)
        {
            string cRuta = AppDomain.CurrentDomain.BaseDirectory + @"..\..\";
            cRuta += @"Datos\" + _cPaqueteria;
            CrearDirectorio(cRuta);

            cRuta += @"\" + _cTiempoEntrega;
            CrearDirectorio(cRuta);

            cRuta += @"\" + _cTipoTiempo + ".txt";
            CrearActualizarArchivo(cRuta, _cMensaje);
        }

        private void CrearActualizarArchivo(string _cRuta, string _cMensaje)
        {
            if (!File.Exists(_cRuta))
            {
                File.Create(_cRuta);
            }

            using (System.IO.StreamWriter archivo = new System.IO.StreamWriter(_cRuta))
            {
                archivo.WriteLine(_cMensaje);
            }
        }

        private void CrearDirectorio(string _cRuta)
        {
            if (!Directory.Exists(_cRuta))
            {
                Directory.CreateDirectory(_cRuta);
            }
        }

        private void EliminarDirectorioDatos(string _cRuta)
        {
            if (Directory.Exists(_cRuta) && Directory.GetFiles(_cRuta).Any())
            {
                Directory.GetFiles(_cRuta);
            }
        }
    }
}
