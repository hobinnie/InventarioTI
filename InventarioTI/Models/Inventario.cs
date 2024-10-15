using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class Inventario
    {
        public int Clave { get; set; }
        public string? Descripcion { get; set; }
        public string? Tipo { get; set; }
        public string? Linea { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Serie { get; set; }
        public string? Hdd { get; set; }
        public string? MemoriaRam { get; set; }
        public string? Procesador { get; set; }
        public string? SistemaOp { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaC { get; set; }
        public DateTime? FechaReasignacion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaA { get; set; }
        public string? PrecioUnitario { get; set; }
        public string? PrecioTotal { get; set; }
        public int? IdEmpresaKf { get; set; }
        public int? IdMarcaKf { get; set; }
        public int? IdZonaKf { get; set; }

        public virtual CatalogoEmpresa? IdEmpresaKfNavigation { get; set; }
        public virtual CatalogoMarca? IdMarcaKfNavigation { get; set; }
        public virtual CatalogoZona? IdZonaKfNavigation { get; set; }
    }
}
