using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

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
                    Clients.All.addNewMessageToPage("SYSTEM", "The Chat has just been cleared by admin");
                    SaveMessage("SYSTEM", "The Chat has just been cleared by admin");
                }
            }
            else
            {

                SaveMessage(name, message);

                // Call the addNewMessageToPage method to update clients.
                Clients.All.addNewMessageToPage(name, message);
            }
        }
        private void SaveMessage(string name, string message)
        {
            using (var context = new MessagesContext())
            {
                Random rand = new Random();
                var messageVar = new Message
                {
                    sender_name = name,
                    message1 = message,
                    created_at = DateTime.Now

                };
                context.Messages.Add(messageVar);
                context.SaveChanges();

            }
        }
        private void ClearMessages()
        {
            using (var context = new MessagesContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Messages]");
            }
        }

    }
}