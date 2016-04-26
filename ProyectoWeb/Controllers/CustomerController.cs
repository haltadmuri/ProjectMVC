using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Infraestructura;
using Logica;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            if (null == service)
            {
                throw new ArgumentNullException("service");
            }
            _service = service;


        }
        //Post /Customer/

        //public ActionResult Create ()

        // GET: /MantenimientoCliente/

        public ActionResult Index()
        {
            return View(_service.GetAlls().ToList());
        }

        //
        // GET: /Customer2/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Customer customer = _service.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer2/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _service.Update(customer.Id, customer);
                return RedirectToAction("Index", "Customer");
            }
            return View(_service.GetAlls().ToList());
        }

        // GET: /Customer2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Customer customer = _service.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer2/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                //Customer c = _service.Get(cus.Id);

                _service.Delete(id);
                return RedirectToAction("Index", "Customer");
            }
            return View(_service.GetAlls().ToList());

        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _service.Add(cust);
                return RedirectToAction("Index", "Customer");
            }
            return View(cust);
        }

        // GET: /Customer/

        public ActionResult Customer(string name)
        {
            var customers = _service.GetAll(name);
            return View(customers);
        }


        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }



        public ActionResult Details(int id)
        {
            Customer customer = _service.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


    }
}




