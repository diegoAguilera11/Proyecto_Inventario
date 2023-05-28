using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Inventario.Models;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
namespace Proyecto_Inventario.Pages;

public class ProductosModel : PageModel
{
    private readonly ILogger<ProductosModel> _logger;

    public List<Producto> Productos;

    public ProductosModel(ILogger<ProductosModel> logger)
    {
        _logger = logger;
    }

    public List<Sucursal> Sucursales;
    public void OnGet()
    {
        InventarioContext context = new InventarioContext();
        Productos = context.Productos.ToList();
    }

    public IActionResult OnPostActualizarStock()
    {

        InventarioContext context = new InventarioContext();

        // var entityUpdate = context.Productos.Find(1);
        // entityUpdate.Nombre = "Diego Leon";
        // context.Update(entityUpdate);
        // context.SaveChanges();
        // return RedirectToPage();
        // ventasDia_2352023

        string archivoVentas = @"C:\Users\diego\Desktop\Pr_des_inte\Datos\ventasDia_2352023.json";
        string ventas = System.IO.File.ReadAllText(archivoVentas);

        List<Ventas> ventasActualizadas = JsonConvert.DeserializeObject<List<Ventas>>(ventas);

        // List<ProductoInvenario> productosActualizados = JsonConvert.DeserializeObject<List<ProductoInvenario>>(inventario);

        foreach (var v in ventasActualizadas)
        {
            // Agregar Ventas
            Console.WriteLine(v.RutCliente);
            context.Venta.Add(new Ventum
            {
                Correlativo = v.Correlativo,
                Fecha = DateTime.Parse(v.Fecha.ToString()),
                Hora = TimeSpan.Parse(v.Hora.ToString()),
                RutCliente = v.RutCliente,
                IdSucursal = 1,
                // Pendiente

            });
            context.SaveChanges();
        }


        foreach (var v in ventasActualizadas)
        {
            var detail = context.Venta.FirstOrDefault(c => c.Correlativo == v.Correlativo);

            Console.WriteLine("--Detalle--");
            foreach (var d in v.VentaProductos)
            {
                context.Detalles.Add(new Detalle
                {
                    IdVenta = detail.Id,
                    IdProducto = d.IdProducto,
                    Precio = d.Precio,
                    Cantidad = d.Cantidad
                });
                Console.WriteLine(d.IdProducto);
                Console.WriteLine(d.Cantidad);

                Sucursales = context.Sucursals.Include(x => x.ProductoSucursals).ThenInclude(x => x.IdProductoNavigation).ToList();

                foreach (var s in Sucursales)
                {
                    foreach (var ps in s.ProductoSucursals)
                    {
                        if (d.IdProducto == ps.IdProducto)
                        {
                            ps.Stock -= d.Cantidad;
                            context.Update(ps);
                            context.SaveChanges();
                        }
                    }
                }
            }
            context.SaveChanges();
        }
        return RedirectToPage();
    }

}

