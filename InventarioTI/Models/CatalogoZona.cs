using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class CatalogoZona
    {
        public CatalogoZona()
        {
            CatalogoEmpresas = new HashSet<CatalogoEmpresa>();
            Inventarios = new HashSet<Inventario>();
        }

        public int IdZona { get; set; }
        public string? Zona { get; set; }

        public virtual ICollection<CatalogoEmpresa> CatalogoEmpresas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
