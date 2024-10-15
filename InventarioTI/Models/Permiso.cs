using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class Permiso
    {
        public int? FkIdUsuario { get; set; }
        public int? FkIdEmpresa { get; set; }
        public int? IdMarcaFk { get; set; }
        public int? IdZonaFk { get; set; }

        public virtual CatalogoEmpresa? FkIdEmpresaNavigation { get; set; }
        public virtual Usuario? FkIdUsuarioNavigation { get; set; }
        public virtual CatalogoMarca? IdMarcaFkNavigation { get; set; }
        public virtual CatalogoZona? IdZonaFkNavigation { get; set; }
    }
}
