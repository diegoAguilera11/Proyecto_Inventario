using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Proyecto_Inventario.Models;

public class Ventas
{
    public int Idventa { get; set; }

    public int Correlativo { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? Hora { get; set; }

    public string? RutCliente { get; set; }

   // public Venta objVenta { get; set; }

    public virtual ICollection<Detalle> VentaProductos { get; set; } = new List<Detalle>();
}
