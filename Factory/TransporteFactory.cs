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
        public ITransporte ObtenerTransporte(string _cTransporte, DatosConfiguracion _entDatosConfig)
        {
            ITransporte Transporte;
            MediosTransporte datosMedios;
            switch (_cTransporte)
            {
                case "Marítimo":
                    datosMedios = _entDatosConfig.MediosTransporte.Where(w => w.Medio == "Marítimo").FirstOrDefault();
                    Transporte = new Barco(datosMedios.CostoPorKilometro, datosMedios.Velocidad);
                    break;
                case "Terrestre":
                    datosMedios = _entDatosConfig.MediosTransporte.Where(w => w.Medio == "Terrestre").FirstOrDefault();
                    Transporte = new Tren(datosMedios.CostoPorKilometro, datosMedios.Velocidad);
                    break;
                case "Aéreo":
                    datosMedios = _entDatosConfig.MediosTransporte.Where(w => w.Medio == "Aéreo").FirstOrDefault();
                    Transporte = new Avion(datosMedios.CostoPorKilometro, datosMedios.Velocidad);
                    break;
                default:
                    throw new Exception("No existe el transporte solicitado");
            }

            return Transporte;
        }
    }
}
