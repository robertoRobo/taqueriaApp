using System;
using System.Collections.Generic;
using System.Text;

namespace taqueria
{
    public class Tortas1
    {
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Cantidad { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }

        public List<Tortas1> ObtenerTortas1()
        {
            List<Tortas1> tortas1 = new List<Tortas1>()
            {
                new Tortas1()
                {
                    Tipo="Torta",
                    Nombre ="Ahogada",
                    Imagen="ahogada.jpg",
                    Precio="25.00",
                    Descripcion="Deliciosa torta ahogada estilo Jalisco",
                    Indice ="3",
                    Cantidad = "0"

                },
                new Tortas1()
                {
                    Tipo="Torta",
                    Nombre ="Cubana",
                    Imagen="cubana.jpg",
                    Precio="35.00",
                    Descripcion="Deliciosa torta cubana de salchicha, pierna y chorizo",
                    Indice ="4",
                    Cantidad = "0"

                },
                new Tortas1()
                {
                    Tipo="Torta",
                    Nombre ="De la Barda",
                    Imagen="barda.jpg",
                    Precio="45.00",
                    Descripcion="Deliciosa torta de la barda estilo Tamaulipas",
                    Indice ="5",
                    Cantidad = "0"
                }
            };
            return tortas1;
        }
    }
}

