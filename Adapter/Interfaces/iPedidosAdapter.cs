using RastreoPaquetes.Repo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Adapter.Interfaces
{
    public interface iPedidosAdapter
    {
        List<DatosPedido> ObtenerDatosPedido(DatosPedidosJson _lstDatosJson);
    }
}
