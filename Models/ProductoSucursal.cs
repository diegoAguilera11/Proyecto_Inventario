﻿using System;
using System.Collections.Generic;

namespace Proyecto_Inventario.Models;

public partial class ProductoSucursal
{
    public int Id { get; set; }

    public int IdProducto { get; set; }

    public int IdSucursal { get; set; }

    public int Stock { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
