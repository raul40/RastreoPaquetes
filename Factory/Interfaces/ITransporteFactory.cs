using RastreoPaquetes.Repo.DTO;
using RastreoPaquetes.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Factory.Interfaces
{
    public interface ITransporteFactory
    {
        ITransporte ObtenerTransporte(string _cTransporte);
    }
}
