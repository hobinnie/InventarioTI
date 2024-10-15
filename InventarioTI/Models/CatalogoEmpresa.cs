using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class CatalogoEmpresa
    {
        public CatalogoEmpresa()
        {
            Inventarios = new HashSet<Inventario>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEmpresa { get; set; }
        public string? Clave { get; set; }
        public string? Descripcion { get; set; }
        public int? FkIdMarca { get; set; }
        public int? FkIdZona { get; set; }

        public virtual CatalogoMarca? FkIdMarcaNavigation { get; set; }
        public virtual CatalogoZona? FkIdZonaNavigation { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
