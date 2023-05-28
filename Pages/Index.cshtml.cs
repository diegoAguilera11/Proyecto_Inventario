using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Inventario.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;
namespace Proyecto_Inventario.Pages;

public class IndexModel : PageModel
{
    JsonSerializerSettings settings = new JsonSerializerSettings
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };

    private readonly ILogger<IndexModel> _logger;

    public List<Sucursal> Sucursales;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }


    public void CargadeLista()
    {

        Console.WriteLine("Generando archivo de inventario"); // Impresion por consola
        InventarioContext context = new InventarioContext(); //Creacion del contexto
        
        Sucursales = context.Sucursals.Include(x => x.ProductoSucursals).ThenInclude(x => x.IdProductoNavigation).ToList(); //Navegacion desde sucursal a productos

        //Obtencion de datos a traves del recorrido de Sucursales
        foreach (var i in Sucursales)
        {
            List<Producto> inventario = new List<Producto>(); //Creacion de lista inventario
            Sucursal sucursal = new Sucursal() { Id = i.Id, Nombre = i.Nombre }; //Creacion de una sucursal

            //Obtencion de datos a traves del recorrido de ProductoSucursales

            foreach (var j in i.ProductoSucursals)
            {
                Producto producto = new Producto()
                {
                    Id = j.IdProducto,
                    Nombre = j.IdProductoNavigation.Nombre,
                    Codigo = j.IdProductoNavigation.Codigo,
                    Descripcion = j.IdProductoNavigation.Descripcion,
                    Precio = j.IdProductoNavigation.Precio
                }; //Creacion de un objeto auxiliar inventario para guardar la informacion que necesitaremos
                inventario.Add(producto); //Se agrega a la lista inventario el objeto inventario con los datos que necesitamos
            }
            string nSucursal = sucursal.Nombre;

            //Crear el archivo
            CreacionArchivo(inventario, nSucursal);
        }

    }

    //Creacion del archivo de texto

    public bool CreacionArchivo(List<Producto> lista, string nSucursal)
    {
        // string datosInventario = JsonConvert.Serialize(lista); //Serializacion de la lista para transformarlo en formato json
        string datosInventario = JsonConvert.SerializeObject(lista, Formatting.Indented, settings);

        using (StreamWriter archivo = new StreamWriter($"..\\Datos\\{nSucursal}.json")) //Creacion del archivo inventario.txt en la carpeta Datos
        {
            archivo.Write(datosInventario); //Transcribe los datos del formato json al archivo txt 
            return true;
        }
    }

    //Metodo para realizar solicitud 
    public void OnGet()
    {
        CargadeLista(); //Se guarda la lista en una variable lista por buenas practicas.
    }
}
