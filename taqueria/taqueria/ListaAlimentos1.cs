using System;
using System.Collections.Generic;
using System.Text;

namespace taqueria
{
    public class ListaAlimentos1
    {
        public List<Taco1> Tacos1 { get; set; }
        public List<Tortas1> Tortas1 { get; set; }
        public List<Taco> Tacos { get; set; }
        public List<Torta> Tortas { get; set; }
        public ListaAlimentos1()
        {
            Tacos1 = new Taco1().ObtenerTacos1();
            Tortas1 = new Tortas1().ObtenerTortas1();
            Tacos = new Taco().ObtenerTacos();
            Tortas = new Torta().ObtenerTortas();
        }
    }
}

