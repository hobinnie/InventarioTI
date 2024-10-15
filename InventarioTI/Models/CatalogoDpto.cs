using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class CatalogoDpto
    {
        public CatalogoDpto()
        {
            CatalogoPuestos = new HashSet<CatalogoPuesto>();
        }

        public int IdDpto { get; set; }
        public string? Departamento { get; set; }

        public virtual ICollection<CatalogoPuesto> CatalogoPuestos { get; set; }
    }
}
