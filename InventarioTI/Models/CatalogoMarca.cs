using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class CatalogoMarca
    {
        public CatalogoMarca()
        {
            CatalogoEmpresas = new HashSet<CatalogoEmpresa>();
            Inventarios = new HashSet<Inventario>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdMarca { get; set; }
        public string? Marca { get; set; }

        public virtual ICollection<CatalogoEmpresa> CatalogoEmpresas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
