using System;
using System.Collections.Generic;

namespace VentasModel
{
    public partial class Articulo
    {
        public Articulo()
        {
            DetalleIngresos = new HashSet<DetalleIngreso>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int IdArticulo { get; set; }
        public int IdCategoria { get; set; }
        public string? Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<DetalleIngreso> DetalleIngresos { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
