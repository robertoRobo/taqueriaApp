using System;
using System.Collections.Generic;
using System.Text;

namespace taqueria
{
    public class Torta
    {
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Cantidad { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }

        public List<Torta> ObtenerTortas()
        {
            List<Torta> tortas = new List<Torta>()
            {
                new Torta()
                {
                    Tipo="Postre",
                    Nombre ="Pastel",
                    Imagen="pastel.jpg",
                    Precio="$45.00",
                    Descripcion="Delicioso pastel casero de frutos silvestres con leche"
                },
                new Torta()
                {
                    Tipo="Postre",
                    Nombre ="Tiramisú",
                    Imagen="tiramisu.jpg",
                    Precio="$31.00",
                    Descripcion="Deliciosa rebanada de Tiramisú"
                },
                new Torta()
                {
                    Tipo="Postre",
                    Nombre ="Waffles",
                    Imagen="wafles.jpg",
                    Precio="$50.00",
                    Descripcion="Orden de Waffles caseros con miel"
                }
                /*
                new Torta()
                {
                    Tipo="Torta",
                    Nombre ="Tripa",
                    Imagen="tripa.jpg",
                    Precio="$30.00",
                    Descripcion="Delicioso taco de tripa con variedad de salsas y verduras"
                },
                new Torta()
                {
                    Tipo="Torta",
                    Nombre ="Vegano",
                    Imagen="vegano.jpg",
                    Precio="$23.50",
                    Descripcion="Delicioso taco de pastor 100% vegano con variedad de salsas veganas y verduras"
                },
                new Torta()
                {
                    Tipo="Torta",
                    Nombre ="Cabeza",
                    Imagen="cabeza.jpg",
                    Precio="$20.50",
                    Descripcion="Delicioso taco de cabeza de res con variedad de salsas y verduras"
                },
                new Torta()
                {
                    Tipo="Torta",
                    Nombre ="Adobada",
                    Imagen="adobada.jpg",
                    Precio="$10.50",
                    Descripcion="Delicioso taco de adobada con variedad de salsas y verduras"
                },
                new Torta()
                {
                    Tipo="Torta",
                    Nombre ="Camarón",
                    Imagen="camaron.jpg",
                    Precio="$25.50",
                    Descripcion="Delicioso taco de camarón con variedad de salsas y verduras"
                },
                new Torta()
                {
                    Tipo="Torta",
                    Nombre ="Nopal",
                    Imagen="nopal.jpg",
                    Precio="$7.50",
                    Descripcion="Delicioso taco de nopales guisados con jitomate y cebolla"
                }*/

            };
            return tortas;
        }
    }
}

