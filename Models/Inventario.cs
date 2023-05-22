using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Inventario.Models;


public class Inventario
{

    public int Id { get; set; }

    public int? Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Precio { get; set; }

    public int IdSucursal { get; set; }

    public string? nombreSucursal { get; set; }

}