﻿using System;
using System.Collections.Generic;

namespace VentasModel
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}