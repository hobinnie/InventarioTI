using System;
using System.Collections.Generic;

namespace InventarioTI.Models
{
    public partial class CatalogoPuesto
    {
        public int IdEmpleado { get; set; }
        public string? Puesto { get; set; }
        public int? FkIdDpto { get; set; }

        public virtual CatalogoDpto? FkIdDptoNavigation { get; set; }
    }
}
