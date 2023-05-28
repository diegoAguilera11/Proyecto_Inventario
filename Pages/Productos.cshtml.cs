using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Inventario.Models;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
namespace Proyecto_Inventario.Pages;

public class ProductosModel : PageModel
{
    private readonly ILogger<ProductosModel> _logger;

    public List<Producto> Productos;

    public ProductosModel(ILogger<ProductosModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        InventarioContext context = new InventarioContext();
        Productos = context.Productos.ToList();
    }

    // public IActionResult OnPostActualizarStock()
    // {
    //     InventarioContext context = new InventarioContext();
    //     Console.WriteLine("Presionaste");
    //      // Leer el archivo JSON de ventas

    //         string archivoVentas = @"C:\Users\diego\Desktop\Pr_des_inte\ventas.json";
    //         string ventas = System.IO.File.ReadAllText(archivoVentas);

    //         List<Ventum> ventasActualizadas = JsonConvert.DeserializeObject<List<Ventum>>(ventas);
    //         // Actualizar el stock de productos en base a las ventas

    //         {
    //             foreach (var venta in ventasActualizadas)
    //             {

    //                 // Productos = context.Productos.ToList();
    //                 Ventum nuevaVenta = new Ventum {
    //                     Correlativo = venta.Correlativo,
    //                     Fecha = venta.Fecha,
    //                     Hora = venta.Hora,
    //                     RutCliente = venta.RutCliente,
    //                     IdSucursal = venta.IdSucursal
    //                 };
    //                 context.Venta.Add(nuevaVenta);
    //             }

    //         }

    //         context.SaveChanges();
    //     return RedirectToPage();
    // }
}

