using Concesionarios.Services.Contracts;
using Concesionarios.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concesionarios.UI.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = _clientesService.ListadoClientes();
            //better use a viewmodel
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clientesService.BuscarCliente(id);
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ClienteDTO cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientesService.AltaCliente(cliente);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clientesService.BuscarCliente(id);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClienteDTO cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cliente.Id = id;
                    _clientesService.ActualizarDatosCliente(cliente);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clientesService.BuscarCliente(id);
            return View(id);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _clientesService.BajaCliente(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
