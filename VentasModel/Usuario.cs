using System;
using System.Collections.Generic;

namespace VentasModel
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ingresos = new HashSet<Ingreso>();
            Venta = new HashSet<Venta>();
        }

        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdPersona { get; set; }
        public string Login { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public bool? Activo { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual Role IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Ingreso> Ingresos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
