using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureChatApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(string name)
        {
            if (name == "") return View("Login");
            else
            {
                TempData["name"] = name;

                return RedirectToAction("Chat");
            }
        }
        public ActionResult Chat()
        {
            ViewBag.name = (string)TempData["name"];

            using (var context = new MessagesContext())
            {
                List<Message> messages = context.Messages.ToList();

                //TempData["model"] = messages;
                return View("Chat", messages);
            }            
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