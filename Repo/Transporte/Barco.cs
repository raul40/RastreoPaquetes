using RastreoPaquetes.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Transporte
{
    public class Barco : ITransporte
    {
        public string cNombreTransporte { get; set; }
        public decimal dCostoKm { get; set; }
        public decimal dVelocidadEntrega { get; set; }
        
        public Barco()
        {
            this.dCostoKm = 1;
            this.dVelocidadEntrega = 46;
            this.cNombreTransporte = "Marítimo";
        }

        public Barco(decimal _dCostoKm, decimal _dVelocidad)
        {
            this.dCostoKm = _dCostoKm;
            this.dVelocidadEntrega = _dVelocidad;
            this.cNombreTransporte = "Marítimo";
        }

        public TimeSpan ObtenerTiempoTraslado(decimal _dDistancia)
        {
            TimeSpan tsTiempoTraslado;

            string cTiempo = (_dDistancia / dVelocidadEntrega).ToString();
            tsTiempoTraslado = TimeSpan.FromHours(double.Parse(cTiempo));

            return tsTiempoTraslado;
        }
    }
}
