using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Productos
    {
        int id;
        string nombreProducto, cantidadProducto, precioProducto;

        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string CantidadProducto { get => cantidadProducto; set => cantidadProducto = value; }
        public string PrecioProducto { get => precioProducto; set => precioProducto = value; }

        public int Id { get => id; set => id = value; }

    }
}
