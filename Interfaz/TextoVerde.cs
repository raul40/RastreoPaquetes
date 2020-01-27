using RastreoPaquetes.Interfaz.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreoPaquetes.Interfaz
{
    public class TextoVerde : IColorTexto
    {
        public void ObtenerColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
