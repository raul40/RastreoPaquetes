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
            Init();
        }

        private static void Init()
        {
            string cRuta = @"..\..\DatosPedidos.txt";
            iLectorArchivo lectorArchivoTexto = new LectorArchivoTexto();
            List<DatosPedido> lstDatosPedido = lectorArchivoTexto.LeerArchivo(cRuta);

            EmpresaTransporteService srvEmpresaTransporte = new EmpresaTransporteService(lstDatosPedido);
            srvEmpresaTransporte.ObtenerResultado();
            Console.ReadLine();

        }
    }
}
