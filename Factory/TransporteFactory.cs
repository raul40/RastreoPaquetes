using RastreoPaquetes.Factory.Interfaces;
using RastreoPaquetes.Repo.DTO;
using RastreoPaquetes.Repo.Interfaces;
using RastreoPaquetes.Repo.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Factory
{
    public class TransporteFactory : ITransporteFactory
    {
        public ITransporte ObtenerTransporte(string _cTransporte)
        {
            ITransporte Transporte;
            switch (_cTransporte.ToUpper())
            {
                case "BARCO":
                    Transporte = new Barco();
                    break;
                case "TREN":
                    Transporte = new Tren();
                    break;
                case "AVION":
                    Transporte = new Avion();
                    break;
                default:
                    throw new Exception("");
            }

            return Transporte;
        }
    }
}
