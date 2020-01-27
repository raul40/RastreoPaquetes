using RastreoPaquetes.Repo.Interfaces;
using RastreoPaquetes.Repo.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Empresa
{
    public class Estafeta : EmpresaAbstract
    {
        private readonly decimal dDistancia;

        public ITransporte entTransporte { get; set; }
        public decimal dMargenUtilidad { get; set; }

        public Estafeta(ITransporte entTransporte, decimal _dDistancia, DateTime _dtFechaActual)
        {
            this.entTransporte = entTransporte;
            ValidaTransporte();
            base.dDistancia = _dDistancia;
            base.dtFechaActual = _dtFechaActual;
            this.dMargenUtilidad = 40;
        }

        private void ValidaTransporte()
        {
            if (entTransporte.GetType() != new Tren().GetType())
            {
                throw new Exception("");
            }
        }
    }
}
