using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Interfaces
{
    public interface IEmpresa
    {
        ITransporte entTransporte { get; set; }
        decimal dMargenUtilidad { get; set; }

        DateTime ObtenerFechaEntrega();

        decimal ObtenerCostoEnvio();
    }
}
