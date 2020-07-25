using System;
using System.Collections.Generic;
using System.Text;

namespace Tiendita.models
{
    class Detalle
    {
        public uint Id { get; set; }
        public uint ProductoId { get; set; }
        public Producto producto { get; set; }
        public uint VentaId { get; set; }
        public Venta Venta { get; set; }
        public decimal Subtotal { get; set; }
    }
}
