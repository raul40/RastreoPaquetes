using RastreoPaquetes.LectorArchivo;
using RastreoPaquetes.LectorArchivo.Interfaces;
using RastreoPaquetes.Repo.DTO;
using RastreoPaquetes.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes
{
    class Program
    {
        static void Main(string[] args)
        {
            Init(args);
        }

        private static void Init(string[] _args)
        {
            try
            {
                string cRuta = @"..\..\";
                string cRutaConfiguracion = AppDomain.CurrentDomain.BaseDirectory + @"..\..\Config.json";
                List<DatosPedido> lstDatosPedido = new List<DatosPedido>();
                if (_args[1].ToUpper() == "JSON")
                {
                    iLectorArchivo lectorArchivoTexto = new LectorArchivoJson();
                    lstDatosPedido = lectorArchivoTexto.LeerArchivo(cRuta);
                }
                else
                {
                    iLectorArchivo lectorArchivoTexto = new LectorArchivoTexto();
                    lstDatosPedido = lectorArchivoTexto.LeerArchivo(cRuta);
                }

                iLectorConfiguracion lectorConfig = new LectorConfiguracionJson();
                var datosCofig = lectorConfig.LeerConfiguracion(cRutaConfiguracion);
                AlmacenadorDatosService srvAlmacenadorDatos = new AlmacenadorDatosService();
                srvAlmacenadorDatos.CrearDirectorioDatos();
                EmpresaTransporteService srvEmpresaTransporte = new EmpresaTransporteService(lstDatosPedido, datosCofig);
                srvEmpresaTransporte.ObtenerResultado();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            

        }
    }
}
