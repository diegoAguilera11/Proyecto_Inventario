using System;
using System.Collections.Generic;

namespace Proyecto_Inventario.Models;

public partial class Ventum
{
    public int Id { get; set; }

    public string Correlativo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public string RutCliente { get; set; } = null!;

    public int IdSucursal { get; set; }

    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
