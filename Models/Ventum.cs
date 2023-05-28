using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Proyecto_Inventario.Models;

public partial class Ventum
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int Id { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Correlativo { get; set; } = null!;

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTime Fecha { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public TimeSpan Hora { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string RutCliente { get; set; } = null!;

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int IdSucursal { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
