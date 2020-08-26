using Introduction_CS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Introduction_CS_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var person = new Pessoa
            {
                PersonID = 1,
                Name = "Fabricio Almeida",
                Type = "TI"

        };



            return View(person); 
        }

        public ActionResult Contatos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Lista(Pessoa person)
        {
            ViewData["PersonID"] = person.PersonID;
            ViewData["Name"] = person.Name;
            ViewData["Type"] = person.Type;

            return View();
        }
    }
}