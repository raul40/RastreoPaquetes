using RastreoPaquetes.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Transporte
{
    public class Tren : ITransporte
    {
        public decimal dCostoKm { get; set; }
        public decimal dVelocidadEntrega { get; set; }

        public Tren()
        {
            this.dCostoKm = 5;
            this.dVelocidadEntrega = 80;
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
