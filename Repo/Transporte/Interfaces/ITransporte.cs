using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Interfaces
{
    public interface ITransporte
    {
        decimal dCostoKm { get; set; }

        decimal dVelocidadEntrega { get; set; }

        TimeSpan ObtenerTiempoTraslado(decimal _dDistancia);
    }
}
