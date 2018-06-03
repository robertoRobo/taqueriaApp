using System;
using System.Collections.Generic;
using System.Text;

namespace scanner.cuerpos
{
    class orden
    {
        public int num_orden { get; set; }
        public string id_usuario { get; set; }
        public int id_sucursal { get; set; }
        public string descripcion { get; set; }
        public int total { get; set; }
        public string codigo { get; set; }
        public DateTime fecha { get; set; }
        public int realizada { get; set; }
        public string cantidad { get; set; }
        public Boolean exists { get; set; }
    }
    
}
