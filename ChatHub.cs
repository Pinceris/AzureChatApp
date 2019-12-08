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
            SaveMessage(name, message);

            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
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

    }
}