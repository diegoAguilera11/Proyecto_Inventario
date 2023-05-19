using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Inventario.Models;
using Microsoft.EntityFrameworkCore;
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

    }
}
