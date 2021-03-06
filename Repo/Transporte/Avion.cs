﻿using RastreoPaquetes.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.Transporte
{
    public class Avion : ITransporte
    {
        public string cNombreTransporte { get; set; }
        public decimal dCostoKm { get; set; }
        public decimal dVelocidadEntrega { get; set; }

        public Avion()
        {
            this.dCostoKm = 10;
            this.dVelocidadEntrega = 600;
            this.cNombreTransporte = "Aéreo";
        }

        public Avion(decimal _dCostoKm, decimal _dVelocidad)
        {
            this.dCostoKm = _dCostoKm;
            this.dVelocidadEntrega = _dVelocidad;
            this.cNombreTransporte = "Aéreo";
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
