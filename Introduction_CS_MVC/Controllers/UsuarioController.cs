using Introduction_CS_MVC.Models;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc;

namespace Introduction_CS_MVC.Controllers
{
    public class UsuarioController : Controller
    {


        public ActionResult Usuario()
        {
            Var user = new Usuario();
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(Usuario user)
        {
            if (ModelState.IsValid)
            {
                return View("Result",user); 
            }
            return View(user);
        }
        public ActionResult Result(Usuario user)
        {
            return View(user);
        }
    }
}  