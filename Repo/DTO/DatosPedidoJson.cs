using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Repo.DTO
{
    public class Pedido
    {
        public string Procedencia { get; set; }
        public string Destino { get; set; }
        public int Dist_KM { get; set; }
        public string Empresa { get; set; }
        public string MedioTrans { get; set; }
        public string FechaPedido { get; set; }
    }

    public class DatosPedidosJson
    {
        public List<Pedido> Pedidos { get; set; }
    }
}
