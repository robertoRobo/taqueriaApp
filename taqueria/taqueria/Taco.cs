using System;
using System.Collections.Generic;
using System.Text;

namespace taqueria
{
    public class Taco
    {
        public string Indice { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public List<Taco> ObtenerTacos()
        {
            List<Taco> tacos = new List<Taco>()
            {
                new Taco()
                {
                    Tipo="Bebida",
                    Nombre ="Refresco",
                    Imagen="coca.jpg",
                    Precio="$15.00",
                    Descripcion="Variedad de Refrescos de la familia coca cola 600ml"
                },
                new Taco()
                {
                    Tipo="Bebida",
                    Nombre ="Agua Fresca",
                    Imagen="fresca.jpg",
                    Precio="$10.00",
                    Descripcion="Agua fresca casera 1lt variedad de sabores"
                },
                new Taco()
                {
                    Tipo="Bebida",
                    Nombre ="Cerveza",
                    Imagen="cerveza.jpg",
                    Precio="$25.00",
                    Descripcion="Variedad de cervezas nacionales (media)"
                }
                /*
                new Taco()
                {
                    Tipo="Postre",
                    Nombre ="Pastel",
                    Imagen="pastel.jpg",
                    Precio="$45.00",
                    Descripcion="Delicioso pastel casero de frutos silvestres con leche"
                },
                new Taco()
                {
                    Tipo="Postre",
                    Nombre ="Tiramisú",
                    Imagen="Tiramisu.jpg",
                    Precio="$31.50",
                    Descripcion="Deliciosa rebanada de Tiramisú"
                },
                new Taco()
                {
                    Tipo="Postre",
                    Nombre ="Waffles",
                    Imagen="wafles.jpg",
                    Precio="$50",
                    Descripcion="Orden de Waffles caseros con miel"
                }
                
                new Taco()
                {
                    Tipo="Taco",
                    Nombre ="Tripa",
                    Imagen="tripa.jpg",
                    Precio="$30.00",
                    Descripcion="Delicioso taco de tripa con variedad de salsas y verduras"
                },
                new Taco()
                {
                    Tipo="Taco",
                    Nombre ="Pastor",
                    Imagen="vegano.jpg",
                    Precio="$23.50",
                    Descripcion="Delicioso taco de pastor 100% vegano con variedad de salsas veganas y verduras"
                },
                new Taco()
                {
                    Tipo="Taco",
                    Nombre ="Cabeza",
                    Imagen="cabeza.jpg",
                    Precio="$20.50",
                    Descripcion="Delicioso taco de cabeza de res con variedad de salsas y verduras"
                },
                new Taco()
                {
                    Tipo="Taco",
                    Nombre ="Adobada",
                    Imagen="adobada.jpg",
                    Precio="$10.50",
                    Descripcion="Delicioso taco de adobada con variedad de salsas y verduras"
                },
                new Taco()
                {
                    Tipo="Taco",
                    Nombre ="Camarón",
                    Imagen="camaron.jpg",
                    Precio="$25.50",
                    Descripcion="Delicioso taco de camarón con variedad de salsas y verduras"
                },
                new Taco()
                {
                    Tipo="Taco",
                    Nombre ="Nopal",
                    Imagen="nopal.jpg",
                    Precio="$7.50",
                    Descripcion="Delicioso taco de nopales guisados con jitomate y cebolla"
                }
                */
            };
            return tacos;
        }
    }
}
