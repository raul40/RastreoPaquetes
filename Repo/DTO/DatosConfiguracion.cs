using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.DTO
{
    public class DatosConfiguracion
    {
        public List<MediosTransporte> MediosTransporte { get; set; }
        public List<Paqueterias> Paqueterias { get; set; }
    }

    public class MediosTransporte
    {
        public string Medio { get; set; }
        public decimal Velocidad { get; set; }
        public decimal CostoPorKilometro { get; set; }
    }

    public class Medios
    {
        public string Medio { get; set; }
    }

    public class Paqueterias
    {
        public string Paqueteria { get; set; }
        public decimal MargenUtilidad { get; set; }
        public List<Medios> Medios { get; set; }
    }
}
