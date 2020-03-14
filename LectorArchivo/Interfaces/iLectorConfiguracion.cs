using RastreoPaquetes.Repo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.LectorArchivo.Interfaces
{
    public interface iLectorConfiguracion
    {
        DatosConfiguracion LeerConfiguracion(string _cRuta);
    }
}
