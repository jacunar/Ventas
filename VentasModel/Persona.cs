using System;
using System.Collections.Generic;

namespace VentasModel
{
    public partial class Persona
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
            Venta = new HashSet<Venta>();
        }

        public int IdPersona { get; set; }
        public string TipoPersona { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? TipoDocumento { get; set; }
        public string? NumDocumento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
