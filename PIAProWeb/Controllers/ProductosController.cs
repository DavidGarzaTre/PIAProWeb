using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIAProWeb.Models.dbModels;
using PIAProWeb.Models.DTO;

namespace PIAProWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductosController : Controller
    {
        private readonly PIAProWebContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductosController(PIAProWebContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var pIAProWebContext = _context.Productos.Include(p => p.IdCategoriaNavigation);
            return View(await pIAProWebContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoCreateDTO producto)
        {
            if (ModelState.IsValid)
            {
                string? fileName = await GuardarFotografiaProductoAsync(producto.ImagenProducto);
                Producto p = new Producto
                {
                    IdCategoria = producto.IdCategoria,
                    NombreProducto = producto.NombreProducto,
                    PrecioProducto = producto.PrecioProducto,
                    Descripcion = producto.Descripcion,
                    ImagenProducto = fileName,
                    StockProducto  = producto.StockProducto,
                };
                _context.Add(p);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "Nombre", producto.IdCategoria);
            return View(producto);
        }
        public async Task<string?> ReemplazarFotografiaAsync(IFormFile? file, string? fileToReplace)
        {
            if (file != null)
            {
                string? newFileName = await GuardarFotografiaProductoAsync(file);
                if (newFileName != null)
                {
                    BorrarFotografiaProducto(fileToReplace);
                    return newFileName;
                }
            }
            return null;
        }

        public async Task<string?> GuardarFotografiaProductoAsync(IFormFile? file)
        {
            if (file != null)
            {
                try
                {
                    string folder = "Fotos/Productos/";
                    string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder + fileName);

                    using (FileStream stream = new FileStream(serverFolder, FileMode.Create))
                    {
                        //Copies data from entity.file to stream
                        await file.CopyToAsync(stream);
                    }
                    return fileName;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public bool BorrarFotografiaProducto(string? fileName)
        {
            if (fileName != null)
            {
                try
                {
                    string folder = "Fotos/Productos/" + fileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    FileInfo fileInfo = new FileInfo(serverFolder);
                    fileInfo.Delete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ProductoUpdateDTO productoupdate = new ProductoUpdateDTO {
                IdProducto= producto.IdProducto,
                IdCategoria = producto.IdCategoria,
                NombreProducto = producto.NombreProducto,
                PrecioProducto = producto.PrecioProducto,
                Descripcion = producto.Descripcion,
                Imagen = producto.ImagenProducto,
                StockProducto = producto.StockProducto

            };
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "Nombre", producto.IdCategoria);
            return View(productoupdate);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoUpdateDTO producto)
        {

            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string? fileName = await ReemplazarFotografiaAsync(producto.ImagenProducto, producto.Imagen);
                    Producto p = new Producto
                    {
                        IdProducto = producto.IdProducto,   
                        IdCategoria = producto.IdCategoria,
                        NombreProducto = producto.NombreProducto,
                        PrecioProducto = producto.PrecioProducto,
                        Descripcion = producto.Descripcion,
                        ImagenProducto = fileName== null? producto.Imagen: fileName,
                        StockProducto = producto.StockProducto
                    };
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "Nombre", producto.IdCategoria);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'PIAProWebContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
