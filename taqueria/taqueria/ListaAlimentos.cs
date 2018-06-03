using System;
using System.Collections.Generic;
using System.Text;

namespace taqueria
{
    public class ListaAlimentos
    {
        public List<Taco> Tacos { get; set; }
        public List<Torta> Tortas { get; set; }
        public ListaAlimentos()
        {
            Tacos = new Taco().ObtenerTacos();
            Tortas = new Torta().ObtenerTortas();
        }
    }
}
