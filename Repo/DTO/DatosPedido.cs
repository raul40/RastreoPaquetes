using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.DTO
{
    public class DatosPedido
    {
        public string cOrigen { get; set; }
        public string cDestino { get; set; }
        public decimal dDistancia { get; set; }
        public string cPaqueteria { get; set; }
        public string cMedioTransporte { get; set; }
        public DateTime dtFechaPedido { get; set; }
        public TimeSpan tsTiempoTraslado { get; set; }
        public DateTime dtFechaActual { get; set; }
        public DateTime dtFechaEntrega { get; set; }
        public decimal dCostoEnvio { get; set; }
        public string cMensaje { get; set; }
    }
}
