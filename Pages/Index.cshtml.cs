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


    public List<Inventario> CargadeLista()
    {

        Console.WriteLine("Generando archivo de inventario"); // Impresion por consola
        InventarioContext context = new InventarioContext(); //Creacion del contexto
        Sucursales = context.Sucursals.Include(x => x.ProductoSucursals).ThenInclude(x => x.IdProductoNavigation).ToList(); //Navegacion desde sucursal a productos
        List<Inventario> lista1 = new List<Inventario>(); //Creacion de lista inventario

        //Obtencion de datos a traves del recorrido de Sucursales

        foreach (var i in Sucursales)
        {

            Sucursal sucursal = new Sucursal() { Id = i.Id, Nombre = i.Nombre }; //Creacion de una sucursal

            //Obtencion de datos a traves del recorrido de ProductoSucursales

            foreach (var j in i.ProductoSucursals)
            {
                Inventario inventario = new Inventario() { Id = j.IdProducto, Nombre = j.IdProductoNavigation.Nombre, Codigo = j.IdProductoNavigation.Codigo, Descripcion = j.IdProductoNavigation.Descripcion, 
                Precio = j.IdProductoNavigation.Precio, IdSucursal = sucursal.Id, nombreSucursal = sucursal.Nombre }; //Creacion de un objeto auxiliar inventario para guardar la informacion que necesitaremos
                lista1.Add(inventario); //Se agrega a la lista inventario el objeto inventario con los datos que necesitamos
            }
        }
        return lista1;

    }

    //Creacion del archivo de texto

    public bool CreacionArchivo(List<Inventario> lista)
    {
        string datosInventario = JsonSerializer.Serialize(lista); //Serializacion de la lista para transformarlo en formato json

        using (StreamWriter archivo = new StreamWriter("..\\Datos\\inventario.json")) //Creacion del archivo inventario.txt en la carpeta Datos
        {
            archivo.Write(datosInventario); //Transcribe los datos del formato json al archivo txt 
            return true;
        }
    }

    //Metodo para realizar solicitud 
    public void OnGet()
    {
        
        List<Inventario> ArchivoInventario = CargadeLista(); //Se guarda la lista en una variable lista por buenas practicas.
        CreacionArchivo(ArchivoInventario ); // Metodo al cual se le entrega una lista y este lo despliega en un archivo txt en formato json.

    }
}
