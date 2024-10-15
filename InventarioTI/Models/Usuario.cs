using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contraseña { get; set; }
        public string? Rol {  get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdMarca { get; set; }
        public int? IdPuesto { get; set; }
        //public string? Rol { get; set; }//

        public virtual CatalogoEmpresa? IdEmpresaNavigation { get; set; }
        public virtual CatalogoMarca? IdMarcaNavigation { get; set; }
        public virtual Empleado? IdPuestoNavigation { get; set; }
    }
}
