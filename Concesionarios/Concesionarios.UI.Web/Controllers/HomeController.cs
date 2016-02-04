using Concesionarios.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concesionarios.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientesService _clientesService;

        public HomeController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        public ActionResult Index()
        {
            var clientes = _clientesService.ListadoClientes();
            return View(clientes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}