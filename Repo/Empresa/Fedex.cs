using RastreoPaquetes.Repo.Interfaces;
using RastreoPaquetes.Repo.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Empresa
{
    public class Fedex : EmpresaAbstract
    {
        public ITransporte entTransporte { get; set; }
        public decimal dMargenUtilidad { get; set; }

        public Fedex(ITransporte entTransporte, decimal _dDistancia, DateTime _dtFechaActual)
        {
            this.entTransporte = entTransporte;
            ValidaTransporte();
            base.dDistancia = _dDistancia;
            base.dtFechaActual = _dtFechaActual;
            this.dMargenUtilidad = 50;
        }

        private void ValidaTransporte()
        {
            if (entTransporte.GetType() != new Barco().GetType())
            {
                throw new Exception("");
            }
        }
    }
}
