using RastreoPaquetes.Repo.DTO;
using RastreoPaquetes.Repo.Interfaces;
using RastreoPaquetes.Repo.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Empresa
{
    public class DHL : EmpresaAbstract
    {
        private readonly Paqueterias entPaqueteria;
        private readonly decimal dDistancia;

        public ITransporte entTransporte { get; set; }
        public decimal dMargenUtilidad { get; set; }

        public DHL(ITransporte entTransporte, decimal _dDistancia, DateTime _dtFechaActual, Paqueterias _entPaqueteria)
        {
            this.entTransporte = entTransporte;
            this.entPaqueteria = _entPaqueteria;
            ValidaTransporte();
            base.dDistancia = _dDistancia;
            base.dtFechaActual = _dtFechaActual;
            this.dMargenUtilidad = _entPaqueteria.MargenUtilidad;
        }

        private void ValidaTransporte()
        {
            if (!entPaqueteria.Medios.Where(w => w.Medio == entTransporte.cNombreTransporte).Any())
            {
                throw new Exception("El transporte no existe para esta paqueteria");
            }
        }
    }
}
