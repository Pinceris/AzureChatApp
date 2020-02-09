using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureChatApp.Repository;
using Microsoft.AspNet.SignalR;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using AzureChatApp.Controllers;
using SignalRChat;

namespace AzureChatApp
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            if (message == "CLEAR DB NOW")
            {
                if (name == "admin")
                {
                    ClearMessages();
                    SaveMessageAndSend("SYSTEM", "The Chat has just been cleared by admin <a href='/'>Click here to reload chat</a>");
                }
            }
            else
            {
                SaveMessageAndSend(name, message);
            }
        }
        private void SaveMessageAndSend(string name, string message)
        {
            Message messageVar = new Message
            {
                sender_name = name,
                message1 = message,
                created_at = DateTime.Now
            };

            if (name == "SYSTEM")
            {
                messageVar.message1 = "The Chat has just been cleared by admin";
                Startup.ChatRepository.Store(messageVar);
                Clients.All.addNewMessageToPage(messageVar.sender_name, message, messageVar.created_at.ToString());
            }
            else
            {
                Startup.ChatRepository.Store(messageVar);

                Clients.All.addNewMessageToPage(messageVar.sender_name, messageVar.message1, messageVar.created_at.ToString());
            }       
        }
        private void ClearMessages()
        {
            IList<Message> messages = Startup.ChatRepository.GetAll();

            foreach (Message msg in messages)
            {
                Startup.ChatRepository.Delete(msg.Id);
            }
        }

    }
}