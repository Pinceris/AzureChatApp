using AzureChatApp.Repository;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureChatApp.Controllers
{
    public class HomeController : Controller
    {
        public static readonly ChatRepo ChatRepository = new ChatRepo(new RedisClient("localhost"));

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
            Session["username"] = name;

            return RedirectToAction("Chat");
        }
        public ActionResult Chat()
        {
            var name = Session["username"];

            if (name == null)
            {
                return View("Login");
            }

            ViewBag.name = name.ToString();

            ViewBag.online = MvcApplication.Sessions.Count;

            IList<Message> messages = ChatRepository.GetAll();
            if (messages != null)
            {
                return View("Chat", messages);
            }

            return View("Chat");
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