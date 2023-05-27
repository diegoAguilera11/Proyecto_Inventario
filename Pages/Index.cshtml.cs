using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Inventario.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace Proyecto_Inventario.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public List<Sucursal> Sucursales;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Console.WriteLine("Desde Index CS");
         InventarioContext context = new InventarioContext();
        Sucursales = context.Sucursals.Include(x => x.ProductoSucursals).ThenInclude(x => x.IdProductoNavigation).ToList();

        List<Inventario> lista2 = new List<Inventario>();

        foreach (var i in Sucursales)
        {

            Sucursal sucursal = new Sucursal(){ Id= i.Id, Nombre=i.Nombre};

            foreach (var j in i.ProductoSucursals)
            {
                Inventario inventario = new Inventario(){Id = j.IdProducto, Nombre = j.IdProductoNavigation.Nombre, Codigo = j.IdProductoNavigation.Codigo, Descripcion = j.IdProductoNavigation.Descripcion, Precio = j.IdProductoNavigation.Precio, IdSucursal = sucursal.Id, nombreSucursal = sucursal.Nombre };
                lista2.Add(inventario);
                Console.WriteLine(inventario);
            }
        }

        string datosInventario = JsonSerializer.Serialize(lista2);

         using (StreamWriter archivo = new StreamWriter(@"/Users/dragoperic/Desktop/archivosPOS/inventario/inventario.json"))
        {
            archivo.Write(datosInventario);
        }
    }
}
