using System;
using System.Collections.Generic;

namespace VentasModel
{
    public partial class Categoria
    {
        public Categoria()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
