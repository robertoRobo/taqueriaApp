using System;
using System.Collections.Generic;
using System.Text;

namespace taqueria
{
    public class Taco1
    {
        public string Indice { get; set; }
        public string Cantidad { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public List<Taco1> ObtenerTacos1()
        {
            List<Taco1> tacos1 = new List<Taco1>()
            {
                new Taco1()
                {
                    Tipo="Taco",
                    Nombre ="Pastor",
                    Imagen="pastor.jpg",
                    Precio="11.00",
                    Descripcion="Delicioso taco de pastor con variedad de salsas y verduras",
                    Indice ="0",
                    Cantidad = "0"
                },
                new Taco1()
                {
                    Tipo="Taco",
                    Nombre ="Chorizo",
                    Imagen="chorizo.jpg",
                    Precio="9.00",
                    Descripcion="Delicioso taco de chorizo con variedad de salsas y verduras",
                    Indice ="1",
                    Cantidad = "0"
                },
                new Taco1()
                {
                    Tipo="Taco",
                    Nombre ="Costilla",
                    Imagen="lengua.jpg",
                    Precio="10.00",
                    Descripcion="Delicioso taco de lengua con variedad de salsas y verduras",
                    Indice ="2",
                    Cantidad = "0"
                }

            };
            return tacos1;
        }
    }
}
