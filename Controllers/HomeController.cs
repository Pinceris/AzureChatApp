﻿using AzureChatApp.Models;
using AzureChatApp.Repository;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using SignalRChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureChatApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            if(Session["username"] != null)
            {
                return RedirectToAction("Chat");
            }

            return View("Login");
        }

        [ValidateAntiForgeryToken]
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

            ChatViewModel chatModel = BuildModel(name.ToString());

            return View("Chat", chatModel);
        }
        //helper methods
        private ChatViewModel BuildModel(string name)
        {
            ChatViewModel chatModel = new ChatViewModel();

            var msg = Startup.ChatRepository.GetAll();
            if (msg != null)
            {
                IList<Message> sortedMessages = msg.OrderBy(q => q.created_at).ToList();
                chatModel.Messages = sortedMessages;
            }

            if (!Startup.ActiveSessionPairs.ContainsKey(Session.SessionID))
            {
                Startup.ActiveSessionPairs.Add(Session.SessionID, name);
            }

            chatModel.SessionNicks = Startup.ActiveSessionPairs;

            return chatModel;
        }
    }
}