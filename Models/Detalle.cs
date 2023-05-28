using System;
using System.Collections.Generic;

namespace Proyecto_Inventario.Models;

public partial class Detalle
{
    public int Id { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Precio { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
