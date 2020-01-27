using RastreoPaquetes.Repo.Empresa;
using RastreoPaquetes.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Factory.Interfaces
{
    public interface IEmpresaFactory
    {
        EmpresaAbstract ObtenerEmpresa(string _cEmpresa);
    }
}
