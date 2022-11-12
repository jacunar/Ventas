using System;
using System.Collections.Generic;

namespace VentasModel
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Ingresos = new HashSet<Ingreso>();
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Contacto { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
