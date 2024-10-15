using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPuesto { get; set; }
        public string? Puesto { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
