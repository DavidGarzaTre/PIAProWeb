using Microsoft.AspNetCore.Mvc;
using PIAProWeb.Models;
using PIAProWeb.Models.dbModels;
using System.Diagnostics;

namespace PIAProWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PIAProWebContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(PIAProWebContext context, IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("[controller]/Componentes/{IdCategoria?}")]
        public IActionResult Componentes(int? IdCategoria =null)
        {
            List<Producto> ListaProducto = null;
            if(IdCategoria == null)
            {
                ListaProducto = _context.Productos.ToList();
            }
            else
            {
                ListaProducto = _context.Productos.Where(x=>x.IdCategoria== IdCategoria).ToList();
            }

            return View(ListaProducto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}