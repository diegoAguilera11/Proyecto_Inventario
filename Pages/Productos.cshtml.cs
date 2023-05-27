using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Inventario.Models;
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

    public void OnGet()
    {
        InventarioContext context = new InventarioContext(); 
        Productos = context.Productos.ToList();
    }
}

