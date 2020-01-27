using RastreoPaquetes.LectorArchivo.Interfaces;
using RastreoPaquetes.Repo.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.LectorArchivo
{
    public class LectorArchivoTexto : iLectorArchivo
    {
        public string[] DatosArchivo;

        public List<DatosPedido> LeerArchivo(string _cRuta)
        {
            if (File.Exists(_cRuta))
            {
                DatosArchivo = File.ReadAllLines(_cRuta);
                return ConvertirDatosToDTO(DatosArchivo);
            }
            else
                throw new Exception("El archivo no existe");

        }

        private List<DatosPedido> ConvertirDatosToDTO(string[] _DatosArchivo)
        {
            List<DatosPedido> lstDatosPedidos = new List<DatosPedido>();
            foreach (var item in _DatosArchivo)
            {
                var datosSplit = item.Split(',');
                DatosPedido entDatos = new DatosPedido();
                entDatos.cOrigen = datosSplit[0];
                entDatos.cDestino = datosSplit[1];
                entDatos.dDistancia = decimal.Parse(datosSplit[2]);
                entDatos.cPaqueteria = datosSplit[3];
                entDatos.cMedioTransporte = datosSplit[4];
                entDatos.dtFechaPedido = DateTime.Parse(datosSplit[5]);
                lstDatosPedidos.Add(entDatos);
            }

            return lstDatosPedidos;
        }
    }
}
