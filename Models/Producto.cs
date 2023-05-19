using System;
using System.Collections.Generic;

namespace Proyecto_Inventario.Models;

public partial class Producto
{
    public int Id { get; set; }

    public int? Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Precio { get; set; }

    public virtual ICollection<ProductoSucursal> ProductoSucursals { get; set; } = new List<ProductoSucursal>();
}
